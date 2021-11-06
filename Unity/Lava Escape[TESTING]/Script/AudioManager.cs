using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using System;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{
    public Sound[] sounds;

    public Slider volume_slider;


    //public static AudioManager instance;
    
    // Start is called before the first frame update
    void Awake()
    {
        //if (instance == null)
        //{
        //     instance = this;
        //}
        //else 
        //{
        //    Destroy(gameObject);
        //    return;
        //}
        
        //DontDestroyOnLoad(gameObject);
        
        foreach (Sound s  in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            
            s.source.clip = s.clip;
            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
        }
 
    }

    void Start(){
        // play sound
        PlayAudio("Theme");

        // call sound
        Sound s = Array.Find(sounds, sound => sound.name == "Theme");

        if (volume_slider == null){
            Debug.LogWarning("Is volume_slider null ?");
            
            s.source.volume = PlayerPrefs.GetFloat("source_volume");
            s.volume = PlayerPrefs.GetFloat("volume");
            return;
        }
        
        s.source.volume = PlayerPrefs.GetFloat("source_volume");
        s.volume = PlayerPrefs.GetFloat("volume");
        volume_slider.value = PlayerPrefs.GetFloat("slider_value");
    }

    void Update()
    {
 
    }
    
    public void PlayAudio(string name){
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null){
            Debug.LogWarning("Sound : "+ name +" not found");
            return;
        }

        s.source.Play();
    }

    public void DecreaseVolume(string name, float volume){
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null){
            Debug.LogWarning("Sound : "+ name +" not found");
            return;
        }

        float abs_volume = s.volume - volume;
        s.source.volume = abs_volume;
    }

    public void DefaultVolume(string name){
        Sound s = Array.Find(sounds, sound => sound.name == name);
    
        s.source.volume = s.volume;
    }

    public void SettingsVolume(float volume)
    {
        Sound s = Array.Find(sounds, sound => sound.name == "Theme");
    
        s.source.volume = volume;
        s.volume = volume;
        volume_slider.value = s.source.volume;
        volume_slider.value = s.volume;

        PlayerPrefs.SetFloat("source_volume", s.source.volume);
        PlayerPrefs.SetFloat("volume",s.volume);
        PlayerPrefs.SetFloat("slider_value",volume_slider.value);

    }

}