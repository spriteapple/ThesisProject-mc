using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundBank : MonoBehaviour
{
    public static SoundBank instance { get; private set; }
    public AudioClip stepAudio;
    public AudioClip yawnAudio;
    public AudioClip clearThroatAudio;
    public AudioClip sneezeAudio;

    void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this);
        }
        else
        {
            instance = this;
        }
    }
}
