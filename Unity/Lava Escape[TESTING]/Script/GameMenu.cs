using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameMenu : MonoBehaviour
{
    public GameObject pause_menu;
    public GameObject win_menu;
    public GameObject player;
        
    public static bool is_paused;
    
    // Start is called before the first frame update
    void Start()
    {
        pause_menu.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (player.activeInHierarchy == true && Input.GetKeyDown(KeyCode.Escape)){
            if (is_paused == true){
                ResumeGame();
            }
            else
            {
            PauseGame();
            }
        }

        if (player.activeInHierarchy == false && is_paused == false){
            win_menu.SetActive(true);
            FindObjectOfType<AudioManager>().DecreaseVolume("Theme", 0.2f);
        }

        if (player.activeInHierarchy == true && is_paused == true)
        {
            FindObjectOfType<AudioManager>().DecreaseVolume("Theme", 0.2f);
        }
        else if (player.activeInHierarchy == true && is_paused == false)
        {
            FindObjectOfType<AudioManager>().DefaultVolume("Theme");
        }

    }   

    private void PauseGame(){
        pause_menu.SetActive(true);
        Time.timeScale = 0f;
        is_paused = true;
    }

    public void ResumeGame(){
        pause_menu.SetActive(false);
        Time.timeScale = 1f;
        is_paused = false;
    }

    public void GotoMainMenu(){
        Time.timeScale = 1f;
        SceneManager.LoadScene("Menu_Testing");
    }

    public void RestartGame(){
        Time.timeScale = 1f;
        SceneManager.LoadScene("Testing_Play");
    }

    public void QuitGame(){
        Application.Quit();
    }

}
