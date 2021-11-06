using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingsMenu : MonoBehaviour
{
    // insert GameObject
    public Dropdown graphic;
    public Toggle fullscreen;
    //public Dropdown resolution_dropdown;

    // variabel
    int set_fullscreen;

    //Resolution[] resolutions;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Graphic 
        if (graphic == null)
        {
            Debug.LogWarning("Is Graphic null ?");
            QualitySettings.SetQualityLevel(PlayerPrefs.GetInt("QualityGame"));
            return;
        }
        
        QualitySettings.SetQualityLevel(PlayerPrefs.GetInt("QualityGame"));
        graphic.value = PlayerPrefs.GetInt("QualityGame");

        // FullScreen
        if (fullscreen == null)
        {
            Debug.LogWarning("Is fullscreen null ?");
            QualitySettings.SetQualityLevel(PlayerPrefs.GetInt("QualityGame"));
            return;
        }
        
        if (PlayerPrefs.GetInt("FullScreen") == 1)
        {
            fullscreen.isOn = true;
            Screen.fullScreen = true;
        }
        if (PlayerPrefs.GetInt("FullScreen") == 0)
        {
            fullscreen.isOn = false;
            Screen.fullScreen = false;
        }

    }

    public void SetQuality(int quality_index)
    {
        PlayerPrefs.SetInt("QualityGame", quality_index);
        QualitySettings.SetQualityLevel(PlayerPrefs.GetInt("QualityGame"));
    }

    public void SetFullScreen(bool is_fullscreen)
    {
        set_fullscreen = is_fullscreen ? 1:0;

        PlayerPrefs.SetInt("FullScreen", set_fullscreen);

        if (PlayerPrefs.GetInt("FullScreen") == 1){
            Screen.fullScreen = true;
        }
        if (PlayerPrefs.GetInt("FullScreen") == 0){
            Screen.fullScreen = false;
        }

    }

}