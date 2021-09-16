using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.Threading.Tasks;

using Microsoft.Azure.SpatialAnchors;
using Microsoft.Azure.SpatialAnchors.Unity;

using Photon.Pun;
using Photon.Realtime;

#if WINDOWS_UWP || UNITY_WSA
using UnityEngine.XR.WindowsMR;
#endif

#if UNITY_ANDROID || UNITY_IOS
using UnityEngine.XR.ARFoundation;
#endif

using Hashtable = ExitGames.Client.Photon.Hashtable;


public class AnchorUtilities : MonoBehaviour
{
    /* its probably messy to have extra variables for a specific scene but time crunch.
     TODO: Find a more organized/cleaner way to implement this somewhere else as it doesnt
     really need to be here */
    public Slider progressBar = null;
    public float createProgress = 0f;

    // Reference to the SAM script (REQUIRED), also manages the session and watchers.
    public SpatialAnchorManager cloudManager;
    // The object that will visually represent a spatial anchor
    public GameObject anchorObject = null;

    private GameObject anchor = null;

    // Anchor location and searching stuff
    private AnchorLocateCriteria anchorLocateCriteria = null;
    private ARRaycastManager raycastManager;

    void Start()
    {
        raycastManager = FindObjectOfType<ARRaycastManager>();
    }

    // Update is called once per frame
    void Update()
    {
        /* This ensures we have the recommended amount of environment data to
        create a CloudSpatialAnchor (ASA), it also updates a progress bar so the
        user knows to map more of their environment */
        if (progressBar != null && createProgress <= 1f && cloudManager.SessionStatus != null)
        {
            createProgress = cloudManager.SessionStatus.RecommendedForCreateProgress;
            progressBar.value = createProgress;
        }
    }

    public async void createSession()
    {
        /* Do this before doing anything.
        This is how azure accesses ARCore/Foundation stuff, 
        and gathers environment data */
        if (cloudManager.Session == null)
        {
            await cloudManager.CreateSessionAsync();
            await cloudManager.StartSessionAsync();
        }
    }

    public async void createAnchor()
    {
        /* Create a ray to the center of the screen, and look for an AR Plane. Place the native anchor on it
        (Essentially a local anchor) */
        Vector3 screenCenter = Camera.current.ViewportToScreenPoint(new Vector3(0.5f, 0.5f));
        List<ARRaycastHit> hits = new List<ARRaycastHit>();
        raycastManager.Raycast(screenCenter, hits, UnityEngine.XR.ARSubsystems.TrackableType.PlaneWithinPolygon);
        // Copy the anchors post
        Pose anchorPose;

        /* If we hit something, instantiate an object to represent the anchor visually
         TODO:
         Add a fix for when a user tries to select an unmapped area. RIght now it will just let them do it
         and either crash or hang.
        */
        if (hits.Count > 0)
        {
            anchorPose = hits[0].pose;
            anchor = Instantiate(anchorObject);
            anchor.transform.SetPositionAndRotation(anchorPose.position, anchorPose.rotation);
        }

        /* add a cloud native anchor so it can be uploaded to azure,
           and reference it */
        /* TODO: Look more into why this needs to be in a try/catch */
        try
        {
            anchor.AddComponent<CloudNativeAnchor>();     
        }
        catch (Exception e)
        {
            Debug.LogError(e.ToString());
        }
         
        CloudNativeAnchor cna = anchor.GetComponent<CloudNativeAnchor>();

        /* Initialize all data that needs to be sent to the cloud 
            - expiration
            - pose (transform/rotation)

            and convert to cloud spatial anchor (need to look more into the difference between
            spatial and native anchor.)
        */
        
        cna.SetPose(anchor.transform.position, anchor.transform.rotation);

        if (cna.CloudAnchor == null)
            await cna.NativeToCloud();

        // Reference the newly converted spatial anchor
        CloudSpatialAnchor cloudAnchor = cna.CloudAnchor;

        // Add an expiration date to the cloud anchor
        cloudAnchor.Expiration = DateTimeOffset.Now.AddDays(7);

        await cloudManager.CreateAnchorAsync(cloudAnchor);

        //  !!! DO THIS SO WE CAN SEND THE ID TO OTHER USERS! !!!
        // TODO - SOMETHING LIKE THIS -> uploadAnchorIDtoPhoton(cloudAnchor.Identifier);

        Hashtable roomTable = new Hashtable();
        roomTable.Add("Anchor", cloudAnchor.Identifier);
        PhotonNetwork.CurrentRoom.SetCustomProperties(roomTable);
        PhotonNetwork.LoadLevel("Join");
    }
}
