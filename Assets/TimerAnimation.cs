using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerAnimation : MonoBehaviour
{
    public static TimerAnimation timerAnimation;
   
    public Animator timerAnimator;

    public bool timerRun;
   
    public CanvasGroup canvasGroup;

    public Image switchSprite;

    public Sprite Speed;

    public Sprite Double;


    void Start()
    {
        timerAnimator = GetComponent<Animator>();
        canvasGroup.GetComponent<CanvasGroup>();
        canvasGroup.alpha = 0f;    
    }

    public void ImageDouble()
    {
        switchSprite.sprite = Double;        
    }

    public void ImageSpeed()
    {        
        switchSprite.sprite = Speed;
    }

}
