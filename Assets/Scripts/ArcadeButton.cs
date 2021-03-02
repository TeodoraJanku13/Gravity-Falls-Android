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
       // Debug.Log(L3GlobalAchievements.instance.achievement);
    }

    // Update is called once per frame
    void Update()
    {

        
        if (PlayerPrefs.HasKey("StoryModeCleared"))
        {
            PlayerPrefs.GetInt("StoryModeCleared");
            arcButton.interactable = true;
        }
        
   
    }

}
