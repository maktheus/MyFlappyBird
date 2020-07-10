using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


[RequireComponent(typeof(Text))]
public class CountDown : MonoBehaviour
{

    public delegate void CountdownFinished();
    public static event CountdownFinished OnCountDownFinished;

    public float timeLeft = 3.0f;
    public Text startText; // used for showing countdown from 3, 2, 1 

    Text countdown;



    void Update()
    {
        timeLeft -= Time.deltaTime;
        startText.text = (timeLeft).ToString("0");
        if (timeLeft <= 0)
        {
           OnCountDownFinished();
        }
    }


}
