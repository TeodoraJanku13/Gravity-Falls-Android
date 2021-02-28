using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{

   public static PlayerHealth instance;

    GameManager gameManager;

    public int maxHealth;

    int health;

    public event Action DamageTaken;

    public int Health
    {
        get
        {
            return health;
        }
    }




    // Start is called before the first frame update
   private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    private void Start()
    {
        health = maxHealth;
    }

    public void TakeDamage()
    {
        if (health ==1)
        {
            GameManager.instance.GameOver();
            //GAME OVER
        }
        health -= 1;

        if (DamageTaken != null)
        {
            DamageTaken();
        }
    }

    public void Heal()
    {
        if (health == maxHealth)
        {
            return;
        }
        health += 1;

        if (DamageTaken != null)
        {
            DamageTaken();
        }
    }
}
