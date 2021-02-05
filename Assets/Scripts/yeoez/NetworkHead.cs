/**
 * The player's head on the network.  Sets the head to the correct eye anchor. 
 * Author: Elyssa Yeo
 * Date: 5 Jan 2021
 */
using UnityEngine;
using System.Collections;
using Photon.Pun;
public class NetworkHead : MonoBehaviour
{
    public GameObject avatar;

    private Transform playerGlobal;
    private Transform playerLocal;

    void Start()
    {
        var photonView = GetComponent<PhotonView>();
        if (photonView.IsMine)
        {
            playerGlobal = GameObject.Find("OVRPlayerController").transform;
            playerLocal = playerGlobal.Find("OVRCameraRig/TrackingSpace/CenterEyeAnchor");

            this.transform.SetParent(playerLocal);
            this.transform.forward = playerLocal.forward;
            this.transform.localPosition = Vector3.zero;

            avatar.SetActive(false);
        }
    }
}