using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverManager : MonoBehaviour
{
    public void Restart ()
    {
        AudioManager.instance.Play("UI_Click_1");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        GlobalAchievemetns.triggerAch02 = false;
    }

    public void Menu ()
    {
        AudioManager.instance.Play("UI_Click_1");
        SceneManager.LoadScene("Menu");
    }
}
