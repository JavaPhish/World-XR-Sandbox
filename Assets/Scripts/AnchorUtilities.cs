using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Threading.Tasks;

using Microsoft.Azure.SpatialAnchors;
using Microsoft.Azure.SpatialAnchors.Unity;

#if WINDOWS_UWP || UNITY_WSA
using UnityEngine.XR.WindowsMR;
#endif

#if UNITY_ANDROID || UNITY_IOS
using UnityEngine.XR.ARFoundation;
#endif


public class AnchorUtilities : MonoBehaviour
{
    public Slider progressBar = null;
    public Text debug = null;
    float createProgress = 0f;
    private SpatialAnchorManager cloudManager = null;

    void Start()
    {
        cloudManager = GetComponent<SpatialAnchorManager>();
        createSession();
    }

    // Update is called once per frame
    void Update()
    {
        createProgress = cloudManager.SessionStatus.RecommendedForCreateProgress;
        debug.text = createProgress.ToString();
        if (progressBar != null && createProgress <= 1f && cloudManager.SessionStatus != null)
        {
            createProgress = cloudManager.SessionStatus.RecommendedForCreateProgress;
            progressBar.value = createProgress;
        }
    }

    public async void createSession()
    {
        if (cloudManager.Session == null)
        {
            await cloudManager.CreateSessionAsync();
            await cloudManager.StartSessionAsync();

        }
    }
}
