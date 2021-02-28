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
        SceneManager.LoadScene("Level1");
    }

    public void Level2Story()
    {
        SceneManager.LoadScene("Level2");
    }

    public void Level3Story()
    {
        SceneManager.LoadScene("Level3");
    }
    public void Level1Arcade()
    {
        SceneManager.LoadScene("Level1A");
    }

    public void Level2Arcade()
    {
        SceneManager.LoadScene("Level2A");
    }

    public void Level3Arcade()
    {
        SceneManager.LoadScene("Level3A");
    }

}
