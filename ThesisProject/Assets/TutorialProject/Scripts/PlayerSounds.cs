using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerSounds : MonoBehaviour
{
    private AudioSource audioSource;
    float whistleTimer = 0;
    int timeToWhistle = 5;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void FixedUpdate()
    {
        whistleTimer += Time.fixedDeltaTime;
        if (whistleTimer >= timeToWhistle)
        {
            int randomSound = Random.Range(0, 3);
            if (randomSound == 0)
            {
                // Playing step sound when movement input is registered
                if (audioSource.clip != SoundBank.instance.yawnAudio)
                {
                    audioSource.clip = SoundBank.instance.yawnAudio;
                   
                }
                // Preventing sound from starting over every time we press multiple buttons
                if (!audioSource.isPlaying) audioSource.Play();
            }
            else if (randomSound == 1)
            {
                // Playing step sound when movement input is registered
                if (audioSource.clip != SoundBank.instance.clearThroatAudio)
                {
                    audioSource.clip = SoundBank.instance.clearThroatAudio;

                }
                // Preventing sound from starting over every time we press multiple buttons
                if (!audioSource.isPlaying) audioSource.Play();
            }
            else if(randomSound == 2)
            {
                // Playing step sound when movement input is registered
                if (audioSource.clip != SoundBank.instance.sneezeAudio)
                {
                    audioSource.clip = SoundBank.instance.sneezeAudio;

                }
                // Preventing sound from starting over every time we press multiple buttons
                if (!audioSource.isPlaying) audioSource.Play();
            }
            whistleTimer = 0;
        }
        if(whistleTimer >= audioSource.clip.length && audioSource.clip != null)
        {
            audioSource.Stop();
        }
    }
    private void OnMovement(InputValue input)
    {
        // Playing step sound when movement input is registered
        if (audioSource.clip != SoundBank.instance.stepAudio)
        {
            audioSource.clip = SoundBank.instance.stepAudio;
            audioSource.loop = true;
        }
        // Preventing sound from starting over every time we press multiple buttons
        if (!audioSource.isPlaying) audioSource.Play();
        whistleTimer = 0;
    }
    private void OnMovementStop(InputValue input)
    {
        audioSource.Stop();
        
    }
}
