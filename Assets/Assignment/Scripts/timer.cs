using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class timer : MonoBehaviour
{

    TextMeshProUGUI timerText; //text mesh pro object in the UI
    float raceTimerSeconds;
    float raceTimerMinutes;
    int raceActive; //same thing here, raceActive was originally a bool but needed to be a player pref so now its an int
    public GameObject results;

    void Start()
    {
        //get text component on the text mesh pro object
        timerText = GetComponent<TextMeshProUGUI>();

        //make player prefs for the seconds, minutes, and if the scene is active
        raceTimerSeconds = PlayerPrefs.GetFloat("seconds");
        raceTimerMinutes = PlayerPrefs.GetFloat("minutes");
        raceActive = PlayerPrefs.GetInt("active");
    }

    // Update is called once per frame
    void Update()
    {
        //have the timer text object reflect the minutes and seconds that have elapsed
        timerText.text = raceTimerMinutes.ToString("00") + ":" + raceTimerSeconds.ToString("00");
        
        if (raceActive == 1) { //time only goes up when the race is active
            raceTimerSeconds += Time.deltaTime; //seconds elapsed increased by time.deltatime
            if (raceTimerSeconds > 59) //if 60 seconds have elapsed
            {
                raceTimerMinutes += 1; //increase minutes elapsed
                raceTimerSeconds = 0; //reset seconds elapsed
            }
        }

        //save these values to player prefs so they are the same when changing scenes
        PlayerPrefs.SetFloat("seconds", raceTimerSeconds);
        PlayerPrefs.SetFloat("minutes", raceTimerMinutes);
    }

    public void StartRace()
    {
        //when the race starts
        raceActive = 1; //activate race active variable
        PlayerPrefs.SetInt("active", raceActive); //save this save across scenes
        raceTimerSeconds = 0; //ensure time is reset
        raceTimerMinutes = 0;
    }

    public void EndRace()
    {
        //when race is over
        raceActive = 0; //race is no longer active
        PlayerPrefs.SetInt("active", raceActive);

        //show the results text
        results.SetActive(true);
        results.SendMessage("DisplayResults", new Vector2(raceTimerMinutes, raceTimerSeconds)); //i have sent the seconds and minutes over to the results script in a vector2 so it can be displayed

        //reset time
        raceTimerSeconds = 0;
        PlayerPrefs.SetFloat("seconds", raceTimerSeconds);
        raceTimerMinutes = 0;
        PlayerPrefs.SetFloat("minutes", raceTimerMinutes);
    }

    public void ResetTimer()
    {
        //reset the time
        //this is called in the very first scene when game starts
        raceActive = 0;
        raceTimerSeconds = 0;
        PlayerPrefs.SetFloat("seconds", raceTimerSeconds);
        raceTimerMinutes = 0;
        PlayerPrefs.SetFloat("minutes", raceTimerMinutes);
        
    }
}
