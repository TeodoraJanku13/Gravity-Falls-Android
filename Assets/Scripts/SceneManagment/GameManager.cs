using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public LevelScript levelScript;

    public GameObject gameOverPanel;

    public GameObject heartContainer;

    public GameObject levelComplete;

    public GameObject pauseButton;

    //public GameObject textScore;


    int score = 0;
    
    public  Text scoreText;

    public Text highScore;
 
    
    public bool gameOver = false;    

    public int superPickupCandy = 0;

    public int currentScene;

 

    

    private void Start()
    {
 
        
        LevelMusic();
        PlayerPrefs.DeleteKey("StoryModeCleared");

    }



    void LevelMusic()
    {
        currentScene = SceneManager.GetActiveScene().buildIndex;

        switch (currentScene)
        {
            case 0:
                AudioManager.instance.StopPlaying("L2Theme");
                AudioManager.instance.StopPlaying("L3Theme");
                AudioManager.instance.StopPlaying("L1Theme");
                break;
            case 1:
                //AudioManager.instance.Play("MenuTheme");
                AudioManager.instance.Play("Levels_Popup");
                AudioManager.instance.StopPlaying("L2Theme");
                AudioManager.instance.StopPlaying("L3Theme");
                AudioManager.instance.StopPlaying("L1Theme");
                break;
            case 2:
                AudioManager.instance.Play("L1Theme");
                AudioManager.instance.StopPlaying("L2Theme");
                AudioManager.instance.StopPlaying("L3Theme");
                AudioManager.instance.StopPlaying("MenuTheme");
                break;
            case 3:
                AudioManager.instance.Play("L2Theme");
                AudioManager.instance.StopPlaying("L1Theme");
                AudioManager.instance.StopPlaying("L3Theme");
                AudioManager.instance.StopPlaying("MenuTheme");
                break;
            case 4:
                AudioManager.instance.Play("L3Theme");
                AudioManager.instance.StopPlaying("L2Theme");
                AudioManager.instance.StopPlaying("L1Theme");
                AudioManager.instance.StopPlaying("MenuTheme");
                break;
            case 5:
                // AudioManager.instance.Play("MenuTheme");
                AudioManager.instance.Play("Levels_Popup");
                AudioManager.instance.StopPlaying("L2Theme");
                AudioManager.instance.StopPlaying("L3Theme");
                AudioManager.instance.StopPlaying("L1Theme");
                break;
            case (6):
                AudioManager.instance.Play("L1Theme");
                AudioManager.instance.StopPlaying("L2Theme");
                AudioManager.instance.StopPlaying("L3Theme");
                AudioManager.instance.StopPlaying("MenuTheme");
                break;
            case 7:
                AudioManager.instance.Play("L2Theme");
                AudioManager.instance.StopPlaying("L1Theme");
                AudioManager.instance.StopPlaying("L3Theme");
                AudioManager.instance.StopPlaying("MenuTheme");
                break;
            case 8:

                AudioManager.instance.Play("L3Theme");
                AudioManager.instance.StopPlaying("L2Theme");
                AudioManager.instance.StopPlaying("L1Theme");
                AudioManager.instance.StopPlaying("MenuTheme");
                break;
        }
      

    }

    void Awake()
    {
        instance = this;
    }

    void Update()
    {
        GlobalAchievemetns.ach01Count = score;
        L2GlobalAchievements.ach06Count = superPickupCandy;
        L3GlobalAchievements.ach08Count = score;
    }

    public void IncrementScore()
    {
        if (!gameOver)
        {
            score += 1;
            scoreText.text = score.ToString();
            
            if (score > PlayerPrefs.GetInt("HighScore", 0))
            {
                PlayerPrefs.SetInt("HighScore", score);
                highScore.text = score.ToString();
            }
            
        }
       
    }

    public void DoubleScore()
    {
        if (!gameOver)
        {
            score += 2;
            scoreText.text = score.ToString();
        }
    }

    public void ResetDoubleScore()
    {
        if (!gameOver)
        {
            score += 1;
            scoreText.text = score.ToString();
        }
    }



    public void SuperCandies()
    {
        superPickupCandy += 1;
    }    

    public void GameOver()
    {
        AudioManager.instance.Play("Level_Failed");
        gameOverPanel.SetActive(true);

        heartContainer.SetActive(false);

        pauseButton.SetActive(false);


        highScore.text = PlayerPrefs.GetInt("HighScore", 0).ToString();


        CandySpawner.instance.StopSpawningCandies();

        PowerupSpawner.instance.StopSpawningPowerups();

        Destroy(GameObject.FindWithTag("Player"));

        if (GameObject.Find("LeftBtn") != null)
        {
            GameObject.Find("LeftBtn").SetActive(false);
        }

        if (GameObject.Find("RightBtn") != null)
        {
            GameObject.Find("RightBtn").SetActive(false);
        }

    }

    public void RestartLevel()
    {
        AudioManager.instance.Play("UI_Click_1");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1f;
        if (currentScene == 2)
        {
            GlobalAchievemetns.triggerAch02 = false;
        }
        if (currentScene == 4)
        {
            L3GlobalAchievements.triggerAch09 = false;
        }
        


    }

 

    public void ContinueBtn()
    {
        AudioManager.instance.Play("UI_Click_1");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex +1);
    }

    public void MenuBtn()
    {
        AudioManager.instance.Play("UI_Click_1");
        SceneManager.LoadScene("Menu");
        Time.timeScale = 1f;
    }

    public void BackToMenu()
    {
        AudioManager.instance.Play("UI_Click_Back");
        SceneManager.LoadScene("Menu");
        Time.timeScale = 1f;
    }

    public void StoryMode ()
    {
        AudioManager.instance.Play("UI_Click_1");
        SceneManager.LoadScene("LoadSTORYmode");
    }

    public void ArcadeMode()
    {
        AudioManager.instance.Play("UI_Click_1");
        SceneManager.LoadScene("LoadARCADEmode");
    }

    public void StartOver()
    {
        PlayerPrefs.DeleteAll();
    }


    public void CompleteLevelL1()
    {
        StartCoroutine(WonLevel()); 
    }

    public void CompleteLevelL2()
    {
        StartCoroutine(WonLevel());
    }

    public void CompleteLevelL3()
    {
      
        StartCoroutine(WonLevel());
       
    }

    public void PlayArcadeMode ()
    {
        AudioManager.instance.Play("UI_Click_1");
        SceneManager.LoadScene("LoadARCADEmode");
        
    }

    public void NextLevel()
    {
        AudioManager.instance.Play("UI_Click_1");
        levelScript.PassLevel();
    }

    IEnumerator WonLevel()
    {
        
        yield return new WaitForSeconds(0.5f);

        
        levelComplete.SetActive(true);
        heartContainer.SetActive(false);
        pauseButton.SetActive(false);

        CandySpawner.instance.StopSpawningCandies();

        PowerupSpawner.instance.StopSpawningPowerups();

        Destroy(GameObject.FindWithTag("Player"));

        if (GameObject.Find("LeftBtn") != null)
        {
            GameObject.Find("LeftBtn").SetActive(false);
        }

        if (GameObject.Find("RightBtn") != null)
        {
            GameObject.Find("RightBtn").SetActive(false);
        }

        
    }

    
}


