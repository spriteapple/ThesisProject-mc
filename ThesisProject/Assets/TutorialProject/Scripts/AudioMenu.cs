using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Audio;

public class AudioMenu : MonoBehaviour
{
    AudioMixer audioMixer;
    //[SerializeField]TMP_Text master, sfx, ambiance;
    
    public void SetAmbienceVolume(float volume){
        int vol = (int)Mathf.Clamp(volume * 10,0,20);
        audioMixer.SetFloat("AmbienceVolume",Mathf.Log10(volume)*20);
    }
    public void SetMasterVolume(float volume){
        int vol = (int)Mathf.Clamp(volume * 10,0,20);
        audioMixer.SetFloat("MasterVolume",Mathf.Log10(volume)*20);
    }
        public void SetSFXVolume(float volume){
        int vol = (int)Mathf.Clamp(volume * 10,0,20);
        audioMixer.SetFloat("SFXVolume",Mathf.Log10(volume)*20);
    }
}
