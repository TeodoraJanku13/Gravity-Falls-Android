using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public Button[] lvlButtons;


    void Start()
    {
        int levelAt = PlayerPrefs.GetInt("levelAt", 2); 

        for (int i = 0; i < lvlButtons.Length; i++)
        {
            if (i + 2 > levelAt)
                lvlButtons[i].interactable = false;
        }
    }


    public void Level1Story()
    {
        AudioManager.instance.Play("UI_Click_1");
        SceneManager.LoadScene("Level1");
    }

    public void Level2Story()
    {
        AudioManager.instance.Play("UI_Click_1");
        SceneManager.LoadScene("Level2");
    }

    public void Level3Story()
    {
        AudioManager.instance.Play("UI_Click_1");
        SceneManager.LoadScene("Level3");
    }

    void Update()
    {
        
    }
}
