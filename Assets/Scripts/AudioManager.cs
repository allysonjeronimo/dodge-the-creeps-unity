using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class AudioManager : MonoBehaviour
{
    private static AudioManager instance;

    [SerializeField]
    private Sound[] musics;
    [SerializeField]
    private Sound[] soundEffects;
    [SerializeField]
    private AudioSource musicSource;
    [SerializeField]
    private AudioSource soundEffectSource;

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

    public void PlayMusic(string name)
    {
        Sound sound = Array.Find(musics, s => s.Name == name);

        if(sound == null)
        {
            Debug.Log("Sound Not Found!");
        }
        else
        {
            musicSource.clip = sound.Clip;
            musicSource.Play();
        }
    }

    public void StopMusic()
    {
        musicSource.Stop();        
    }

    public void PlaySoundEffect(string name)
    {
        Sound sound = Array.Find(soundEffects, s => s.Name == name);

        if(sound == null)
        {
            Debug.Log("Sound Not Found!");
        }
        else
        {
            soundEffectSource.PlayOneShot(sound.Clip);
        }
    }

    public void ToggleMusic()
    {
        musicSource.mute = !musicSource.mute;
    }

    public void ToggleSoundEffects()
    {
        soundEffectSource.mute = !soundEffectSource.mute;
    }

    public void MusicVolume(float volume)
    {
        musicSource.volume = volume;
    }

    public void SoundEffectsVolume(float volume)
    {
        soundEffectSource.volume = volume;
    }
}
