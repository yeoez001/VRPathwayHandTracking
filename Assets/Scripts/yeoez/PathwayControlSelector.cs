using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Photon.Pun;

public class PathwayControlSelector : PokeSelector
{
    [System.Serializable]
    public class ButtonEvent : UnityEvent { }

    public ButtonEvent pressedEvent;

    private void OnTriggerEnter(Collider collision)
    {
        if (Application.platform == RuntimePlatform.Android)
        {
            if (collision.name == "IndexTip" && ColliderHandIsPointing(collision))
            {
                pressedEvent?.Invoke();
            }
        }
    }
}

