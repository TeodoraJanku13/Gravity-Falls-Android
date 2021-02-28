using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ArcadeButton : MonoBehaviour
{
    Button arcButton;
    GameManager gameManager;
    public bool activateButton;

    public bool l3bool;

    L3GlobalAchievements l3GlobalAchievements;

    public int isCleared;



    // Start is called before the first frame update
    void Start()
    {
        arcButton = GetComponent<Button>();
        arcButton.interactable = false;
        // activateButton = false;

       // Debug.Log(isCleared);


      //  L3GlobalAchievements.storyModeCleared = isCleared;

    }

    // Update is called once per frame
    void Update()
    {

        //  UnlockBtn();
        if (PlayerPrefs.HasKey("StoryModeCleared"))
        {
            PlayerPrefs.GetInt("StoryModeCleared");
            arcButton.interactable = true;
        }
        
   
    }

    public void UnlockBtn()
    {

         //   if (isCleared == 1)
        //        {
       //         arcButton.interactable = true;
       //     }

    }
}
