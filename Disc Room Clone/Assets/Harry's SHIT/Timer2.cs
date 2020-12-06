using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class Timer2 : MonoBehaviour
{
    
    public float timeRemaining = 0;
    public bool timerIsRunning = false;
    //this is used to determine if the player is still alive.
    public float isAlive;
    public TextMeshProUGUI timeText;
    void Start()
    {
        timerIsRunning = true;
        //timeText = gameObject.GetComponent<TextMeshProUGUI>();
       

    }
    void FixedUpdate()
    {
//        if (timerIsRunning && GameObject.Find("PlayerPrefab(Clone)") != null)
//        {
//                DisplayTime(timeRemaining);
//                timeRemaining += Time.deltaTime;
//        }
//        else
//        {
//            Debug.Log("Player Dead");
//            timeRemaining = 0;
//            timerIsRunning = false;
//        }
//        if(GameObject.Find("PlayerPrefab(Clone)") != null)
//        {
//            print("player alive");
//        }
//        else
//        {
//            print("player dead");
//        }
    
    }


    void DisplayTime(float timeToDisplay)
    {
        timeToDisplay += 1;
        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);
        float milliSeconds = (timeToDisplay % 1) * 100;

        timeText.text = string.Format("{0:00}:{1:00}:{2:00}", minutes, seconds, milliSeconds);
    }

}
