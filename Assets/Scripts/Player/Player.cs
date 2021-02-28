using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class Player : MonoBehaviour
{
    public static Player instance;

    private Rigidbody2D rb;

    public float moveSpeed = 15f;

    private bool moveLeft, moveRight;
    public bool pickedUpSpeed;
    public bool pickedUpDouble;

    public Animator animator;
    const string EAT_ANIM = "IsEating";
    public int powerupPickedUp = 0;
    int currentLevel;

    [SerializeField] private GameManager gameManager;

    //Timer
    public GameObject textDisplay;    
    private int seconds = 0;
    public Text Timer;
    public TimerAnimation timerAnimation;
    public GameObject powerupTimer;

   

    //Achievements
    public int pickupLife = 0;
    public int pickupApple = 0;
    public int pickupPizza = 0;
    public bool superPickedUp = false;


    

    


    void Start()
    {
        
        gameManager = GameObject.FindWithTag("GameManager").GetComponent<GameManager>();
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        moveLeft = false;
        moveRight = false;
        pickedUpSpeed = false;
        pickedUpDouble = false;

        currentLevel = SceneManager.GetActiveScene().buildIndex;
    }

    public void MoveLeft ()
    {
        moveLeft = true;
    }

    public void MoveRight ()
    {
        moveRight = true;
    }

    public void StopMoving ()
    {
        moveLeft = false;
        moveRight = false;
        rb.velocity = Vector2.zero;
    }

    void Update()
    {
        

        if (moveLeft)
        {
            rb.velocity = new Vector2(-moveSpeed, 0f);
        }
        if (moveRight)
        {
            rb.velocity = new Vector2(moveSpeed, 0f);
        }

       // timerAnimation.canvasGroup.alpha = 0f;

        if (timerAnimation.timerAnimator.gameObject.activeSelf && seconds == 0)
        {
            timerAnimation.timerAnimator.SetBool("TimerOn", false);
        }

        GlobalAchievemetns.ach03Count = powerupPickedUp;
        L2GlobalAchievements.ach04Count = pickupLife;
        L2GlobalAchievements.ach05Count = pickupApple;
        L3GlobalAchievements.ach07Count = pickupPizza;
    }



    // POWER UP
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("SpeedUp"))
        {
            timerAnimation.ImageSpeed();
            textDisplay.SetActive(true);
            timerAnimation.timerAnimator.SetBool("TimerOn", true);
            timerAnimation.timerRun = true;
            seconds = 7;
            StartCoroutine(RunTimer());

            Destroy(collision.gameObject);
           
            switch (currentLevel)
            {
                case 2:
                     animator.SetTrigger(EAT_ANIM);
                     break;
                case 3:
                    animator.SetTrigger("IsEating2");
                    break;
                case 4:
                    animator.SetTrigger("IsEating3");
                    break;
                case (6):
                    animator.SetTrigger(EAT_ANIM);
                    break;
                case 7:
                    animator.SetTrigger("IsEating2");
                    break;
                case 8:
                    animator.SetTrigger("IsEating3");
                    break;

            }

            superPickedUp = true;

            powerupPickedUp += 1;
            pickedUpSpeed = true;
            GameObject.FindGameObjectWithTag("Boundary").transform.localScale = new Vector3(0, 0, 0);
            GameObject.FindWithTag("CandySpawner").GetComponent<CandySpawner>().spawnInterval = 0.3f;
            moveSpeed = 25f;
            GetComponent<SpriteRenderer>().color = Color.magenta;

            StartCoroutine(ResetSpeed());


        }

        if (collision.CompareTag("DoublePoints"))
        {
            timerAnimation.ImageDouble();
            textDisplay.SetActive(true);
            timerAnimation.timerAnimator.SetBool("TimerOn", true);

           // GlobalAchievemetns.ach03Count += 1;
            powerupPickedUp += 1;

            timerAnimation.timerRun = true;
            seconds = 7;
            StartCoroutine(RunTimer());

            pickedUpDouble = true;
            switch (currentLevel)
            {
                case 2:
                    animator.SetTrigger(EAT_ANIM);
                    break;
                case 3:
                    animator.SetTrigger("IsEating2");
                    break;
                case 4:
                    animator.SetTrigger("IsEating3");
                    break;
                case (6):
                    animator.SetTrigger(EAT_ANIM);
                    break;
                case 7:
                    animator.SetTrigger("IsEating2");
                    break;
                case 8:
                    animator.SetTrigger("IsEating3");
                    break;

            }
            Destroy(collision.gameObject);
            
            StartCoroutine(ResetDouble());
           
        }

        if (collision.CompareTag("ExtraHealth"))
        {
            pickupLife += 1;
            PlayerHealth.instance.Heal();
            switch (currentLevel)
            {
                case 2:
                    animator.SetTrigger(EAT_ANIM);
                    break;
                case 3:
                    animator.SetTrigger("IsEating2");
                    break;
                case 4:
                    animator.SetTrigger("IsEating3");
                    break;
                case (6):
                    animator.SetTrigger(EAT_ANIM);
                    break;
                case 7:
                    animator.SetTrigger("IsEating2");
                    break;
                case 8:
                    animator.SetTrigger("IsEating3");
                    break;

            }
            Destroy(collision.gameObject);
        }

        if (collision.GetComponent<Apple_Tag>() !=null)
        {
            pickupApple += 1;
        }

        if (collision.GetComponent<Pizza_Tag>() != null)
        {
            pickupPizza += 1;
        }

        // ANIMATION
        if (collision.tag=="Candy")
        {

            switch (currentLevel)
            {
                case 2:
                    animator.SetTrigger(EAT_ANIM);
                    break;
                case 3:
                    animator.SetTrigger("IsEating2");
                    break;
                case 4:
                    animator.SetTrigger("IsEating3");
                    break;
                case (6):
                    animator.SetTrigger(EAT_ANIM);
                    break;
                case 7:
                    animator.SetTrigger("IsEating2");
                    break;
                case 8:
                    animator.SetTrigger("IsEating3");
                    break;

            }
        }
            
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag ("SpeedUp"))
        {
            animator.SetBool("IsEating", false);
        }

        if (collision.CompareTag("Candy"))
        {
            animator.SetBool("IsEating", false);
        }
    }



    private IEnumerator ResetBoundary()
    {
        yield return new WaitForSeconds(2);
        GameObject.FindGameObjectWithTag("Boundary").transform.localScale = new Vector3(1, 1, 1);
        superPickedUp = false;
        GetComponent<SpriteRenderer>().color = Color.white;
      
    }


    private IEnumerator ResetSpeed()
    {
        yield return new WaitForSeconds(5);
        
        pickedUpSpeed = false;
        moveSpeed = 15f;
        GetComponent<SpriteRenderer>().color = new Color(1.0f, 0.5f, 0.85f);
        GameObject.FindWithTag("CandySpawner").GetComponent<CandySpawner>().spawnInterval = 1f;
        StartCoroutine(ResetBoundary());
    }


    private IEnumerator ResetDouble()
    {
        yield return new WaitForSeconds(7);
        pickedUpDouble = false;
    }


    public IEnumerator RunTimer()
    {
     
        
        while (seconds != 0)
        {
           
            timerAnimation.canvasGroup.alpha = 1f;
            yield return new WaitForSeconds(1);
            seconds--;
            Timer.text = "0" + seconds.ToString();
           
        }

        if (seconds == 0)
        {
            powerupTimer.SetActive(false);
        }
        
      
    }

}
