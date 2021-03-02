using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GlobalAchievemetns : MonoBehaviour
{
    public GameManager gameManager;
    //GeneralVariables
    public GameObject achPanel;
    public bool achActive = false;
    public GameObject achTitle;
    public GameObject achDescription;


    //Achivement 01 - 100 Candies
    public GameObject ach01Image;
    public static int ach01Count;
    public int ach01Trigger = 100;
    public int ach01Code;
    //Achievement 02  - Play 60 seconds
    public GameObject ach02Image;
    public static bool triggerAch02 = false;
    public int ach02Code;
    //Achivement 03 - 3 PowerUps
    public GameObject ach03Image;
    public static int ach03Count;
    public int ach03Trigger = 3;
    public int ach03Code;

    //Level 1 Complete
    bool ach1 = false;
    bool ach2 = false;
    bool ach3 = false;





    void Start()
    {
           PlayerPrefs.SetInt("Ach01", 0);    // RESET PLAYERPREF
           PlayerPrefs.SetInt("Ach02", 0);
           PlayerPrefs.SetInt("Ach03", 0);


        StartCoroutine(PlayFor());
    }

    public void AchievementsCompleteL1()
    {
        gameManager.CompleteLevelL1();
    }

    void Update()
    {
        ach01Code = PlayerPrefs.GetInt("Ach01");
        ach02Code = PlayerPrefs.GetInt("Ach02");
        ach03Code = PlayerPrefs.GetInt("Ach03");



        if (ach01Count == ach01Trigger && ach01Code != 001)
        {
            StartCoroutine(TriggerAch01());
        }
        if (triggerAch02 == true && ach02Code != 002)
        {
            StartCoroutine(TriggerAch02());
        }
        if (ach03Count == ach03Trigger && ach03Code != 003)
        {
            StartCoroutine(TriggerAch03());
        }

        if (ach1 && ach2 && ach3)
        {
            AchievementsCompleteL1();
            GameObject.FindGameObjectWithTag("Boundary").transform.localScale = new Vector3(0, 0, 0);
        }

        

    }

    IEnumerator TriggerAch01()
    {
        AudioManager.instance.Play("Achievement_Completed_Popup");
        ach1 = true;
        achActive = true;
        ach01Code = 001;
        PlayerPrefs.SetInt("Ach01", ach01Code);
        ach01Image.SetActive(true);
        achTitle.GetComponent<Text>().text = "COLLECTED";
        achDescription.GetComponent<Text>().text = "Congrats! You have collected 100 candies!";
        achPanel.SetActive(true);
        yield return new WaitForSeconds(7);
        //Reseting UI
        achPanel.SetActive(false);
        ach01Image.SetActive(false);
        achTitle.GetComponent<Text>().text = "";
        achDescription.GetComponent<Text>().text = "";
        achActive = false;
    }

    IEnumerator TriggerAch02()
    {
        ach2 = true;
        achActive = true;
        ach02Code = 002;
        PlayerPrefs.SetInt("Ach02", ach02Code);
        AudioManager.instance.Play("Achievement_Completed_Popup");
        ach02Image.SetActive(true);
        achTitle.GetComponent<Text>().text = "WELL PLAYED";
        achDescription.GetComponent<Text>().text = "Congrats! You have played for 60 seconds!";
        achPanel.SetActive(true);
        yield return new WaitForSeconds(7);
        //Reseting UI
        achPanel.SetActive(false);
        ach02Image.SetActive(false);
        achTitle.GetComponent<Text>().text = "";
        achDescription.GetComponent<Text>().text = "";
        achActive = false;

    }

    //Play for 75 seconds
    IEnumerator PlayFor()
    {
        yield return new WaitForSeconds(75);
        triggerAch02 = true;
    }

    IEnumerator TriggerAch03()
    {
        ach3 = true;
        achActive = true;
        ach03Code = 003;
        PlayerPrefs.SetInt("Ach03", ach03Code);
        AudioManager.instance.Play("Achievement_Completed_Popup");
        ach03Image.SetActive(true);
        achTitle.GetComponent<Text>().text = "COLLECTED";
        achDescription.GetComponent<Text>().text = "Congrats! You have collected 3 power ups!";
        achPanel.SetActive(true);
        yield return new WaitForSeconds(7);
        //Reseting UI
        achPanel.SetActive(false);
        ach03Image.SetActive(false);
        achTitle.GetComponent<Text>().text = "";
        achDescription.GetComponent<Text>().text = "";
        achActive = false;
    }

} 
