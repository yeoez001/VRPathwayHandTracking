using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class PathwayController : MonoBehaviour
{
    private NodeSelector[] pathwayNodes;
    private bool labelsActive;
    private bool allActive;

    private void Start()
    {
        pathwayNodes = GetComponentsInChildren<NodeSelector>();
        labelsActive = false;
        allActive = false;
    }

    public void ToggleNodesLabel()
    {
        foreach (var node in pathwayNodes)
        {
            if (node.NodeChildPhotonView() == null)
            {
                node.InstantiateNodeChild();
            }
            if (!labelsActive)
            {
                node.NodeChildPhotonView().RPC("ShowNodeText", RpcTarget.AllBuffered, true);                
            }
            else
            {
                node.NodeChildPhotonView().RPC("ShowNodeText", RpcTarget.AllBuffered, false);                
            }
        }

        if (!labelsActive)
        {
            labelsActive = true;
        } else
        {
            labelsActive = false;
        }
    }

    // TODO Bugged with mulitplayer
    //public void ToggleAll()
    //{
    //    foreach (var node in pathwayNodes)
    //    {
    //        if (node.NodeChildPhotonView() == null)
    //        {
    //            node.InstantiateNodeChild();
    //        }
    //        if (!allActive)
    //        {
    //            node.GetComponent<PhotonView>().RPC("SetShowing", RpcTarget.AllBuffered, true);
    //            node.NodeChildPhotonView().RPC("ShowAll", RpcTarget.AllBuffered, true, GameObject.Find("CenterEyeAnchor").transform.position.x, GameObject.Find("CenterEyeAnchor").transform.position.y, GameObject.Find("CenterEyeAnchor").transform.position.z);
    //        }
    //        else
    //        {
    //            node.GetComponent<PhotonView>().RPC("SetShowing", RpcTarget.AllBuffered, false);
    //            node.NodeChildPhotonView().RPC("ShowAll", RpcTarget.AllBuffered, false, GameObject.Find("CenterEyeAnchor").transform.position.x, GameObject.Find("CenterEyeAnchor").transform.position.y, GameObject.Find("CenterEyeAnchor").transform.position.z);
    //        }
    //    }

    //    if (!allActive)
    //    {
    //        allActive = true;
    //    }
    //    else
    //    {
    //        allActive = false;
    //    }
    //}
}
