using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    private static AudioManager instance;

    private AudioSource soundEffectsAudioSource;

    public static AudioManager Instance
    {
        get { 
            if(instance == null)
            {
                Debug.Log("AudioManager instance is null");
            }
            return instance;
        }
    }

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        this.soundEffectsAudioSource = GetComponent<AudioSource>();
    }

    public void Play(AudioClip clip)
    {
        if(soundEffectsAudioSource != null)
        {
            soundEffectsAudioSource.clip = clip;
            soundEffectsAudioSource.Play();
        }  
    }
}
