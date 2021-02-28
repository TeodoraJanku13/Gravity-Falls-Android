using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverManager : MonoBehaviour
{
    public void Restart ()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        GlobalAchievemetns.triggerAch02 = false;
    }

    public void Menu ()
    {
        SceneManager.LoadScene("Menu");
    }
}
