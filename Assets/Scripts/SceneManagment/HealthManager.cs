using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthManager : MonoBehaviour
{

    public GameObject heart;
    public List<Image> hearts;

    PlayerHealth playerHealth;


    // Start is called before the first frame update
    void Start()
    {
        playerHealth = PlayerHealth.instance;
        playerHealth.DamageTaken += UpdateHearts;

        for (int i = 0; i < playerHealth.maxHealth; i++)
        {
            GameObject h = Instantiate(heart, this.transform);
            hearts.Add(h.GetComponent<Image>());
        }
    }


    void UpdateHearts()
    {
        int heartFill = playerHealth.Health;

        foreach (Image i in hearts)
        {
            i.fillAmount = heartFill;
            heartFill -= 1;
        }
    }
}

