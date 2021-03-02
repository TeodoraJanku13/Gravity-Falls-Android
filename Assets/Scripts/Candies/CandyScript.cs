using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CandyScript : MonoBehaviour
{
    Player player;

    PlayerHealth playerHealth;
    GameManager gameManager;


    private void Start()
    {
        player = GameObject.FindWithTag("Player").GetComponent<Player>();
        playerHealth = PlayerHealth.instance;
    }
    void OnTriggerEnter2D (Collider2D collider)
 {
        if (collider.gameObject.tag == "Player")
        {
            AudioManager.instance.Play("Pig_Eat"); 
            if (player.pickedUpDouble == false)
            {                
                GameManager.instance.IncrementScore();
                Destroy(gameObject);
            }
           else
            {
                GameManager.instance.DoubleScore();
                Destroy (gameObject);
            }

            if (player.superPickedUp)
            {
                GameManager.instance.SuperCandies();
            }

            
        }

        if (collider.gameObject.tag =="Boundary")
        {
            PlayerHealth.instance.TakeDamage();
            
            Destroy (gameObject);
             
              
        }
          

 }


}
