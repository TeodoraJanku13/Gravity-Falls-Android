using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class L3GlobalAchievements : MonoBehaviour
{
    PlayerHealth playerHealth;
    ArcadeButton arcadeButton;

    public static L3GlobalAchievements instance;

    //GeneralVariables
    public GameObject achPanel;
    //  public AudioSource achSound;
    public bool achActive;
    public GameObject achTitle;
    public GameObject achDescription;

    //Achivement 07 - 30 Pizzas
    public GameObject ach07Image;
    public static int ach07Count;
    public int ach07Trigger = 30;
    public int ach07Code;

    //Achivement 01 - 150 JunkFood
    public GameObject ach08Image;
    public static int ach08Count;
    public int ach08Trigger = 150;
    public int ach08Code;

    //Achievement 09  - Play 30 seconds without losing a life
    public GameObject ach09Image;
    public static bool triggerAch09 = false;
    public int ach09Code;

    //Level 3 Complete
     bool ach7 = false;
     bool ach8 = false;
     bool ach9 = false;

    public GameObject failedAch;

   // public static int storyModeCleared;

    // Start is called before the first frame update
    void Start()
    {
          PlayerPrefs.SetInt("Ach07", 0);
          PlayerPrefs.SetInt("Ach08", 0);
          PlayerPrefs.SetInt("Ach09", 0);
          PlayerPrefs.DeleteAll();
        StartCoroutine(NoLostLives());

    }

    // Update is called once per frame
    void Update()
    {
        ach07Code = PlayerPrefs.GetInt("Ach07");
        ach08Code = PlayerPrefs.GetInt("Ach08");
        ach09Code = PlayerPrefs.GetInt("Ach09");
       

        if (ach07Count == ach07Trigger && ach07Code != 007)
        {
            StartCoroutine(TriggerAch07());
        }
        if (ach08Count == ach08Trigger && ach08Code != 008)
        {
            StartCoroutine(TriggerAch08());
        }
        if (triggerAch09 == true && ach09Code != 009)
        {
            StartCoroutine(TriggerAch09());
        }

        if (ach7 && ach8 && ach9)
        {
            AchievementsComplete();
            GameObject.FindGameObjectWithTag("Boundary").transform.localScale = new Vector3(0, 0, 0);


            PlayerPrefs.SetInt("StoryModeCleared", 1);
            PlayerPrefs.Save();
        }
 
    }

    public void AchievementsComplete()
    {
        GameManager.instance.CompleteLevelL3();
    }

    IEnumerator TriggerAch07()
    {
        ach7 = true;
        achActive = true;
        ach07Code = 007;
        PlayerPrefs.SetInt("Ach07", ach07Code);
        FindObjectOfType<AudioManager>().Play("Achievement_Completed_Popup");
        ach07Image.SetActive(true);
        achTitle.GetComponent<Text>().text = "COLLECTED";
        achDescription.GetComponent<Text>().text = "Congrats! You have collected 30 Pizzas!";
        achPanel.SetActive(true);
        yield return new WaitForSeconds(7);
        //Reseting UI
        achPanel.SetActive(false);
        ach07Image.SetActive(false);
        achTitle.GetComponent<Text>().text = "";
        achDescription.GetComponent<Text>().text = "";
        achActive = false;
    }

    IEnumerator TriggerAch08()
    {
        ach8 = true;
        achActive = true;
        ach08Code = 008;
        PlayerPrefs.SetInt("Ach08", ach08Code);
        FindObjectOfType<AudioManager>().Play("Achievement_Completed_Popup");
        ach08Image.SetActive(true);
        achTitle.GetComponent<Text>().text = "COLLECTED";
        achDescription.GetComponent<Text>().text = "Congrats! You have collected 150 delicious Junk Food!";
        achPanel.SetActive(true);
        yield return new WaitForSeconds(7);
        //Reseting UI
        achPanel.SetActive(false);
        ach08Image.SetActive(false);
        achTitle.GetComponent<Text>().text = "";
        achDescription.GetComponent<Text>().text = "";
        achActive = false;

    }

    IEnumerator TriggerAch09()
    {
       ach9 = true;
        achActive = true;
        ach09Code = 009;
        PlayerPrefs.SetInt("Ach09", ach09Code);
        FindObjectOfType<AudioManager>().Play("Achievement_Completed_Popup");
        ach09Image.SetActive(true);
        achTitle.GetComponent<Text>().text = "WELL PLAYED";
        achDescription.GetComponent<Text>().text = "Congrats! You haven't missed any junk food for 30 seconds!";
        achPanel.SetActive(true);
        yield return new WaitForSeconds(7);
        //Reseting UI
        achPanel.SetActive(false);
        ach09Image.SetActive(false);
        achTitle.GetComponent<Text>().text = "";
        achDescription.GetComponent<Text>().text = "";
        achActive = false;

    }

    IEnumerator NoLostLives()
    {
        yield return new WaitForSeconds(30);
        if (PlayerHealth.instance.Health ==5)
        {
        triggerAch09 = true;
        }
        else
        {   
            failedAch.SetActive(true);
            GameManager.instance.GameOver();
            
        }
        
    }
}
