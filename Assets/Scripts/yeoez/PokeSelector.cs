using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PokeSelector : MonoBehaviour
{
    protected bool ColliderHandIsPointing(Collider collision)
    {
        GameObject hand = collision.gameObject.GetComponentInParent<OVRHand>().gameObject;
        GestureDetector gesture = hand.GetComponentInChildren<GestureDetector>();
        if (gesture)
        {
            return gesture.isPointing();
        }
        return false;
    }
}
