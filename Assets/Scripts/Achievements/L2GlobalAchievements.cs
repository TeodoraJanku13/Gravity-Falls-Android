using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class L2GlobalAchievements : MonoBehaviour
{
    //GeneralVariables
    public GameObject achPanel;
  //  public AudioSource achSound;
    public bool achActive;
    public GameObject achTitle;
    public GameObject achDescription;

    //Achivement 04 - 3 ExtraLives
    public GameObject ach04Image;
    public static int ach04Count;
    public int ach04Trigger = 3;
    public int ach04Code;

    //Achivement 05 - 20 Apples
    public GameObject ach05Image;
    public static int ach05Count;
    public int ach05Trigger = 20;
    public int ach05Code;

    //Achivement 06 - 10 Candies While SuperPower is On
    public GameObject ach06Image;
    public static int ach06Count;
    public int ach06Trigger = 10;
    public int ach06Code;

    //Level 2 Complete
    bool ach4 = false;
    bool ach5 = false;
    bool ach6 = false;



    void Start()
    {
          PlayerPrefs.SetInt("Ach04", 0);
          PlayerPrefs.SetInt("Ach05", 0);
          PlayerPrefs.SetInt("Ach06", 0);
    }
    void Update()
    {
        ach04Code = PlayerPrefs.GetInt("Ach04");
        ach05Code = PlayerPrefs.GetInt("Ach05");
        ach06Code = PlayerPrefs.GetInt("Ach06");

        if (ach04Count == ach04Trigger && ach04Code != 004)
        {
            StartCoroutine(TriggerAch04());
        }
        if (ach05Count == ach05Trigger && ach05Code != 005)
        {
            StartCoroutine(TriggerAch05());
        }
        if (ach06Count == ach06Trigger && ach06Code != 006)
        {
            StartCoroutine(TriggerAch06());
        }

        if (ach4 && ach5 && ach6)
        {
            AchievementsComplete();
            GameObject.FindGameObjectWithTag("Boundary").transform.localScale = new Vector3(0, 0, 0);
        }
    }

    public void AchievementsComplete()
    {
        GameManager.instance.CompleteLevelL3();
    }
    
    IEnumerator TriggerAch04()
    {
        ach4 = true;
        achActive = true;
        ach04Code = 004;
        PlayerPrefs.SetInt("Ach04", ach04Code);
        FindObjectOfType<AudioManager>().Play("Achievement_Completed_Popup");
        ach04Image.SetActive(true);
        achTitle.GetComponent<Text>().text = "COLLECTED";
        achDescription.GetComponent<Text>().text = "Congrats! You have collected 3 Extra Lives!";
        achPanel.SetActive(true);
        yield return new WaitForSeconds(7);
        //Reseting UI
        achPanel.SetActive(false);
        ach04Image.SetActive(false);
        achTitle.GetComponent<Text>().text = "";
        achDescription.GetComponent<Text>().text = "";
        achActive = false;
    }

    IEnumerator TriggerAch05()
    {
        ach5 = true;
        achActive = true;
        ach05Code = 005;
        PlayerPrefs.SetInt("Ach05", ach05Code);
        FindObjectOfType<AudioManager>().Play("Achievement_Completed_Popup");
        ach05Image.SetActive(true);
        achTitle.GetComponent<Text>().text = "COLLECTED";
        achDescription.GetComponent<Text>().text = "Congrats! You have collected 20 Apples!";
        achPanel.SetActive(true);
        yield return new WaitForSeconds(7);
        //Reseting UI
        achPanel.SetActive(false);
        ach05Image.SetActive(false);
        achTitle.GetComponent<Text>().text = "";
        achDescription.GetComponent<Text>().text = "";
        achActive = false;
    }

    IEnumerator TriggerAch06()
    {
        ach6 = true;
        achActive = true;
        ach06Code = 006;
        PlayerPrefs.SetInt("Ach06", ach06Code);
        FindObjectOfType<AudioManager>().Play("Achievement_Completed_Popup");
        ach06Image.SetActive(true);
        achTitle.GetComponent<Text>().text = "COLLECTED";
        achDescription.GetComponent<Text>().text = "Congrats! You have collected 10 SUPER Candies!";
        achPanel.SetActive(true);
        yield return new WaitForSeconds(7);
        //Reseting UI
        achPanel.SetActive(false);
        ach06Image.SetActive(false);
        achTitle.GetComponent<Text>().text = "";
        achDescription.GetComponent<Text>().text = "";
        achActive = false;
    }
}


