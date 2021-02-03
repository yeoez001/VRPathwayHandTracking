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

    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        if (stream.IsWriting)
        {
            stream.SendNext(playerLocal.position);
            stream.SendNext(playerLocal.rotation);
        }
        else
        {
            this.transform.position = (Vector3)stream.ReceiveNext();
            this.transform.rotation = (Quaternion)stream.ReceiveNext();
        }
    }
}
