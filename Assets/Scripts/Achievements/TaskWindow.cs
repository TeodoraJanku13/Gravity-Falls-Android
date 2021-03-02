using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System;

public class TaskWindow : MonoBehaviour
{
    public GameObject taskWindow;

    //Disable on start
    public GameObject heartContainer;
    public GameObject scorePanel;
    public GameObject player;
    public GameObject pauseBtn;
    public GameObject[] buttons;

    //Task window
    public GameObject bgImage;
    public GameObject text1;
    public GameObject text2;
    public GameObject text3;
    public GameObject img1;
    public GameObject img2;
    public GameObject img3;

    //Sprites
    public Sprite Candy;
    public Sprite timeLeft;
    public Sprite Powerup;
    public Sprite Heart;
    public Sprite Super;
    public Sprite Apple;
    public Sprite Pizza;
    public Sprite Junk;
    public Sprite Level1;
    public Sprite Level2;
    public Sprite Level3;

    public int levelNum;
    
    void Start()
    {
        buttons = GameObject.FindGameObjectsWithTag("MoveButton");
        LevelTasks();
    }

    void LevelTasks()
    {
        levelNum = SceneManager.GetActiveScene().buildIndex;

        switch (levelNum)
        {
            case 2:
            DisableGameUI();
            AudioManager.instance.Play("Panel_Popup");
            bgImage.GetComponent<Image>().sprite = Level1;

            text1.GetComponent<Text>().text = "Collect 100 candies";
            img1.GetComponent<Image>().sprite = Candy;
            img1.GetComponent<Image>().SetNativeSize();

            text2.GetComponent<Text>().text = "Play for 60 seconds";
            img2.GetComponent<Image>().sprite = timeLeft;


            text3.GetComponent<Text>().text = "Collect 3 powerups";
            img3.GetComponent<Image>().sprite = Powerup;
                break;


            case 3:
            DisableGameUI();
            AudioManager.instance.Play("Panel_Popup");
            bgImage.GetComponent<Image>().sprite = Level2;

            text1.GetComponent<Text>().text = "Collect 25 apples";
            img1.GetComponent<Image>().sprite = Apple;
            img1.GetComponent<Image>().SetNativeSize();

            text2.GetComponent<Text>().text = "Collect 3 Extra lives";
            img2.GetComponent<Image>().sprite = Heart;

            text3.GetComponent<Text>().text = "Collect 10 SUPER candies";
            img3.GetComponent<Image>().sprite = Powerup;
                break;

            case 4:
                DisableGameUI();
                AudioManager.instance.Play("Panel_Popup");
                bgImage.GetComponent<Image>().sprite = Level3;

                text1.GetComponent<Text>().text = "Collect 35 pizzas";
                img1.GetComponent<Image>().sprite = Pizza;

                text2.GetComponent<Text>().text = "Play 30 seconds without losing a life";
                img2.GetComponent<Image>().sprite = Heart;

                text3.GetComponent<Text>().text = "Collect 150 junk food";
                img3.GetComponent<Image>().sprite = Junk;
                break;

        }
    }

    void DisableGameUI ()
    {
        Time.timeScale = 0f;
        taskWindow.SetActive(true);

        heartContainer.SetActive(false);
        scorePanel.SetActive(false);
        player.SetActive(false);
        pauseBtn.SetActive(false);

        foreach (GameObject b in buttons)
        {
            b.SetActive(false);
        }

       // buttons.SetActive(false);
    }

    public void ContinueToPlay()
    {
        AudioManager.instance.Play("UI_Click_1");
        Time.timeScale = 1f;
        taskWindow.SetActive(false);

        heartContainer.SetActive(true);
        scorePanel.SetActive(true);
        player.SetActive(true);
        pauseBtn.SetActive(true);

        foreach (GameObject b in buttons)
        {
            b.SetActive(true
                );
        }
    }

    void Update()
    {
        
    }
}
//similar as ahc panel, create a base and call in the beggining of story levels , create a continue button
// to start the actual game
// On start pause the game, disable all the UI

//BG IMAGE