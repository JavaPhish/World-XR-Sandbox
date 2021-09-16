using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Photon.Pun;
using Photon.Realtime;

public class ObjectManager : MonoBehaviour
{
    public Camera mainCam;
    public GameObject cubePrefab;

    public void spawnObject(string prefab_name)
    {


        Vector3 player_position = mainCam.transform.position;
        player_position.z += .5f;
        Quaternion player_rotation = mainCam.transform.rotation;
        Resources.Load(prefab_name);
        GameObject newAnchor = PhotonNetwork.Instantiate(prefab_name, player_position, player_rotation, 0);
    }
}
