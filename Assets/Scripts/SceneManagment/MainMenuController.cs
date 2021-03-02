using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    public GameObject mainMenuPanel;

    public GameObject playMode;

    public GameObject optionsMenu;

    private void Start()
    {
      //  PlayerPrefs.DeleteAll();
        AudioManager.instance.Play("MenuTheme");
        AudioManager.instance.Play("Play_Options_Exit_Popup");
        
    }

    public void Play ()
    {
        AudioManager.instance.Play("UI_Click_1");
        PlayMode();
        
    } 

    public void Exit ()
    {
        AudioManager.instance.Play("UI_Click_1");
        Application.Quit();
    }

    public void PlayMode()
    {
        mainMenuPanel.SetActive(false);
        playMode.SetActive(true);

    }

    public void ClosePlayMode()
    {
        AudioManager.instance.Play("UI_Click_Back");
        mainMenuPanel.SetActive(true);
        playMode.SetActive(false);
    }

    public void CloseOptionsMenu()
    {
        AudioManager.instance.Play("UI_Click_Back");
        optionsMenu.SetActive(false);
        mainMenuPanel.SetActive(true);
    }

    public void OpenOptionsMenu()
    {
        AudioManager.instance.Play("UI_Click_1");
        optionsMenu.SetActive(true);
        mainMenuPanel.SetActive(false);
    }
}
