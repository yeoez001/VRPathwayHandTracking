/**
 * The player's hand on the network. Sets the hand to attach to the correct hand anchor.  
 * Author: Elyssa Yeo
 * Date: 5 Jan 2021
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class NetworkHand : MonoBehaviour
{
    private Transform playerGlobal;
    private Transform playerLocal;
    private PhotonView photonView;
    private void Start()
    {
        photonView = GetComponent<PhotonView>();

        if (photonView.IsMine)
        {
            playerGlobal = GameObject.Find("OVRPlayerController").transform;
            if (GetComponent<OVRHand>().HandType == OVRHand.Hand.HandLeft)
            {
                playerLocal = playerGlobal.Find("OVRCameraRig/TrackingSpace/LeftHandAnchor");
            }

            if (GetComponent<OVRHand>().HandType == OVRHand.Hand.HandRight)
            {
                playerLocal = playerGlobal.Find("OVRCameraRig/TrackingSpace/RightHandAnchor");
            }

            this.transform.SetParent(playerLocal);
            this.transform.localPosition = Vector3.zero;
            this.transform.localRotation = Quaternion.identity;
        }
    }
}
