using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    [Header("Background Audio")]
    public Sound[] background_sounds;

    [Header("Player Audio")]
    public Sound[] player_sounds;

    [Header("Eagle Audio")]
    public Sound[] eagle_sounds;

    [Header("Frog Audio")]
    public Sound[] frog_sounds;

    [Header("Opossum Audio")]
    public Sound[] opossum_sounds;

    
    // Start is called before the first frame update
    void Awake()
    {
        foreach (Sound s in background_sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();

            s.source.clip = s.clip;
            s.source.volume = s.volume;
            s.source.loop = s.loop;
        }

        foreach (Sound s in player_sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();

            s.source.clip = s.clip;
            s.source.volume = s.volume;
            s.source.loop = s.loop;
        }

        foreach (Sound s in eagle_sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();

            s.source.clip = s.clip;
            s.source.volume = s.volume;
            s.source.loop = s.loop;
        }

        foreach (Sound s in frog_sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();

            s.source.clip = s.clip;
            s.source.volume = s.volume;
            s.source.loop = s.loop;
        }

        foreach (Sound s in opossum_sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();

            s.source.clip = s.clip;
            s.source.volume = s.volume;
            s.source.loop = s.loop;
        }
    }

    // Update is called once per frame
    void Start()
    {
        //PlayBackground("MainTheme");
    }

    public void PlayBackground(string name)
    {
        Sound s = Array.Find(background_sounds, sound => sound.name == name);

        s.source.Play();
    }

    public void PlayPlayer(string name)
    {
        Sound s = Array.Find(player_sounds, sound => sound.name == name);
        
        s.source.Play();
    }

    public void StopPlayer(string name)
    {
        Sound s = Array.Find(player_sounds, sound => sound.name == name);

        s.source.Stop();
    }
    
    public bool CheckIsPlaying(string name)
    {
        Sound s = Array.Find(player_sounds, sound => sound.name == name);
        
        bool check = s.source.isPlaying;

        return check;
    }
    
    public void PlayEagle(string name)
    {
        Sound s = Array.Find(eagle_sounds, sound => sound.name == name);

        s.source.Play();
    }

    public void PlayFrog(string name)
    {
        Sound s = Array.Find(frog_sounds, sound => sound.name == name);

        s.source.Play();
    }

    public void PlayOpossum(string name)
    {
        Sound s = Array.Find(opossum_sounds, sound => sound.name == name);

        s.source.Play();
    }
}
