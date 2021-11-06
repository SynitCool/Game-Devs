using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    // variabel
    public GameObject main_menu;
    public GameObject settings_menu;
    
    // Start is called before the first frame update
    void Start()
    {
        // Menu active
        main_menu.SetActive(true);
        settings_menu.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayGame(){
        SceneManager.LoadScene("Testing_Play");
    }

    public void GoToSettings(){
        main_menu.SetActive(false);
        settings_menu.SetActive(true);
    }

    public void QuitGame(){
        Application.Quit();
    }

    public void BackToMenu(){
        main_menu.SetActive(true);
        settings_menu.SetActive(false);
    }
}
