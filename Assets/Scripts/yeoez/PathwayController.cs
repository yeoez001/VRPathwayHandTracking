/**
 * Controls the state of all node labels in the pathway.  
 * Author: Elyssa Yeo
 * Date: 5 Jan 2021
 */
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
}
