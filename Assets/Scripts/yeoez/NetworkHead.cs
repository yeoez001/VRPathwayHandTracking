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
        Debug.Log("i'm instantiated");

        var photonView = GetComponent<PhotonView>();
        if (photonView.IsMine)
        {
            Debug.Log("player is mine");

            playerGlobal = GameObject.Find("OVRPlayerController").transform;
            playerLocal = playerGlobal.Find("OVRCameraRig/TrackingSpace/CenterEyeAnchor");

            this.transform.SetParent(playerLocal);
            this.transform.forward = playerLocal.forward;
            this.transform.localPosition = Vector3.zero;

            avatar.SetActive(false);
        }
    }

    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        if (stream.IsWriting)
        {
            stream.SendNext(playerLocal.position);
            stream.SendNext(playerLocal.rotation);
            stream.SendNext(playerLocal.position);
            stream.SendNext(playerLocal.rotation);
        }
        else
        {
            this.transform.position = (Vector3)stream.ReceiveNext();
            this.transform.rotation = (Quaternion)stream.ReceiveNext();
            avatar.transform.position = (Vector3)stream.ReceiveNext();
            avatar.transform.rotation = (Quaternion)stream.ReceiveNext();
        }
    }
}