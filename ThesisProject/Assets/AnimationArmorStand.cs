using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationArmorStand : MonoBehaviour, F_IInteractable
{
    public void Interact()
    {
        if(!GetComponent<Animation>().isPlaying) GetComponent<Animation>().Play();
    }
}
