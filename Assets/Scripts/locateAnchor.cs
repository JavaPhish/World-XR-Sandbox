using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Threading.Tasks;
using Photon.Pun;
using Photon.Realtime;
using Microsoft.Azure.SpatialAnchors;
using Microsoft.Azure.SpatialAnchors.Unity;

#if WINDOWS_UWP || UNITY_WSA
using UnityEngine.XR.WindowsMR;
#endif

#if UNITY_ANDROID || UNITY_IOS
using UnityEngine.XR.ARFoundation;
#endif


public class locateAnchor : MonoBehaviour
{
    public GameObject searchingUI;
    public GameObject interactUI;
    public GameObject sandbox;

    //
    public SpatialAnchorManager cloudManager = null;
    AnchorLocateCriteria anchorLocateCriteria = null;
    private CloudSpatialAnchorWatcher watcher;

    // Anchor instantiation (Probably delete)
    public GameObject anchorObject;
    public GameObject anchor;

    // Start is called before the first frame update
    void Awake()
    {
        PhotonNetwork.AutomaticallySyncScene = true;
    }

    string getAnchorID()
    {
        /* In the future this will pull the photon rooms associated spatial anchor ID.
        for now im just gonna use a known ID until i have an actual solution/PHOTON is setup */

        return (PhotonNetwork.CurrentRoom.CustomProperties["Anchor"].ToString());
    }

    public async void createWatcher()
    {
        /* Do this before doing anything.
        This is how azure accesses ARCore/Foundation stuff, 
        and gathers environment data and also initializes a watcher
        which searches for anchors of given ID */

        /* Initialize the anchor location criteria, and specify the rooms anchor identifier */
        anchorLocateCriteria = new AnchorLocateCriteria();

        // Tell the manager what to do when an anchor is detected
        GetComponent<SpatialAnchorManager>().AnchorLocated += CloudManager_AnchorLocated;

        // yes
        await Task.Delay(330);

        /* Create session so we can interface with arcore data */
        await cloudManager.CreateSessionAsync();
        await cloudManager.StartSessionAsync();

        // Initialize the watcher to look for the anchor associated with the room
        string id = getAnchorID();
        anchorLocateCriteria.Identifiers = new string[] {id};
        watcher = cloudManager.Session.CreateWatcher(anchorLocateCriteria);
    }

    private void CloudManager_AnchorLocated(object sender, AnchorLocatedEventArgs args)
    {
        // if status indicates an anchor was located
        if (args.Status == LocateAnchorStatus.Located)
        {
            // Create a new anchor based on the data in cloud and pose it to match the pose (transform/rotaion)
            CloudSpatialAnchor new_anchor = args.Anchor;
            Pose anchorPose = new_anchor.GetPose();

            // Instantiate a visual representation of the anchor
            /* TODO: Replace this with the play areas objects */
            sandbox.transform.SetPositionAndRotation(anchorPose.position, anchorPose.rotation);            
            //anchor.CreateNativeAnchor();

            /* just changes to the game UI rather than the searching UI,
            maybe clean this later */
            searchingUI.SetActive(false);
            interactUI.SetActive(true);
        }
    }
}
