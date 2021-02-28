using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    public GameObject mainMenuPanel;

    public GameObject playMode;

    public GameObject optionsMenu;

    public void Play ()
    {
        PlayMode();
        //SceneManager.LoadScene("LoadSystem");
    } 

    public void Exit ()
    {
        Application.Quit();
    }

    public void PlayMode()
    {
        mainMenuPanel.SetActive(false);
        playMode.SetActive(true);

    }

    public void ClosePlayMode()
    {
        mainMenuPanel.SetActive(true);
        playMode.SetActive(false);
    }

    public void CloseOptionsMenu()
    {
        optionsMenu.SetActive(false);
        mainMenuPanel.SetActive(true);
    }

    public void OpenOptionsMenu()
    {
        optionsMenu.SetActive(true);
        mainMenuPanel.SetActive(false);
    }
}
