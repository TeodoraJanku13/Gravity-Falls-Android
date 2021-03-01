using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelPicker : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
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
    public void Level1Arcade()
    {
        AudioManager.instance.Play("UI_Click_1");
        SceneManager.LoadScene("Level1A");
    }

    public void Level2Arcade()
    {
        AudioManager.instance.Play("UI_Click_1");
        SceneManager.LoadScene("Level2A");
    }

    public void Level3Arcade()
    {
        AudioManager.instance.Play("UI_Click_1");
        SceneManager.LoadScene("Level3A");
    }

}
