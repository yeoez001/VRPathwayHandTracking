/**
 * Information components related to a metabolite. 
 * Author: Elyssa Yeo
 * Date: 5 Jan 2021
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class NodeComponents : MonoBehaviour
{
    public TextMesh nodeLabel;
    public GameObject image;
    public GameObject scatterplot;

    private Vector3 hmdCameraPos;
    [PunRPC]
    void ShowAll(bool active, float hmdX, float hmdY, float hmdZ)
    {
        hmdCameraPos = new Vector3(hmdX, hmdY, hmdZ);
        ShowNodeText(active);
        ShowImage(active);
        if (scatterplot)
        {
            ShowScatterplot(active);
        } 
    }

    [PunRPC]
    void SetNodeText(string text)
    {
        nodeLabel.text = text;         
    }

    [PunRPC]
    void ShowNodeText(bool active)
    {
        nodeLabel.transform.parent.gameObject.SetActive(active);        
    }

    [PunRPC]
    void SetImage(string path)
    {
        Sprite loadedImage = Resources.Load<Sprite>(path);
        if (!loadedImage) {

            loadedImage = Resources.Load<Sprite>("ChemicalStructures/NoData");
        }
        SpriteRenderer spriteRenderer = image.GetComponentInChildren<SpriteRenderer>();        
        spriteRenderer.sprite = loadedImage;
    }

    [PunRPC]
    void SetScatterplot(string path)
    {
        Sprite loadedImage = Resources.Load<Sprite>(path);
        if (!loadedImage)
        {
            ShowScatterplot(false);
            scatterplot = null;
        }
        else
        {
            SpriteRenderer spriteRenderer = scatterplot.GetComponentInChildren<SpriteRenderer>();
            spriteRenderer.sprite = loadedImage;
            scatterplot.transform.localPosition = new Vector3(0.2665f, -0.033f, 0.1514f);
        }
    }

    [PunRPC]
    void ShowImage(bool active)
    {
        image.SetActive(active);
        if (active)
        {
            OrientateToCamera(image);
        }
    }

    [PunRPC]
    void ShowScatterplot(bool active)
    {
        scatterplot.SetActive(active);
        if (active)
        {
            OrientateToCamera(scatterplot);
        }
    }
    
    private void OrientateToCamera(GameObject go)
    {
        Vector3 v = transform.position - hmdCameraPos;
        Quaternion q = Quaternion.LookRotation(v);
        go.transform.rotation = q;
    }
}
