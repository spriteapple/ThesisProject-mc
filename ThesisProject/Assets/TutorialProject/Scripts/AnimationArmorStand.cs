using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class AnimationArmorStand : MonoBehaviour,IInteractable
{
    public void Interact()
    {
        if (GetComponent<Animation>().isPlaying)
        {
            return;
        }
        GetComponent<Animation>().Play();
    }
}
