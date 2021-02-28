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
       // highScore.text = PlayerPrefs.GetInt("HighScore", 0).ToString();
        currentScene = SceneManager.GetActiveScene().buildIndex;

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

    public void SetHighScore()
    {
        if (score > PlayerPrefs.GetInt("HighScore", 0))
        {
        PlayerPrefs.SetInt("HighScore", score);
            highScore.text = score.ToString();
        }
        
    }

    public void ResetHS()
    {
        PlayerPrefs.DeleteKey("HighScore");
    }

    public void SuperCandies()
    {
        superPickupCandy += 1;
    }    

    public void GameOver()
    {

        gameOverPanel.SetActive(true);

        heartContainer.SetActive(false);

        pauseButton.SetActive(false);

        SetHighScore();

        CandySpawner.instance.StopSpawningCandies();

        //CHECK
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
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex +1);
    }

    public void MenuBtn()
    {
        SceneManager.LoadScene("Menu");
        Time.timeScale = 1f;
    }

    public void StoryMode ()
    {
        SceneManager.LoadScene("LoadSTORYmode");
    }

    public void ArcadeMode()
    {
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
        SceneManager.LoadScene("LoadARCADEmode");
        
    }

    public void NextLevel()
    {
        levelScript.PassLevel();
    }

    IEnumerator WonLevel()
    {
        yield return new WaitForSeconds(7);
        
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


