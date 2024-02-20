using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class timer : MonoBehaviour
{

    TextMeshProUGUI timerText;
    float raceTimerSeconds;
    float raceTimerMinutes;
    int raceActive;
    public GameObject results;

    void Start()
    {
        timerText = GetComponent<TextMeshProUGUI>();
        raceTimerSeconds = PlayerPrefs.GetFloat("seconds");
        raceTimerMinutes = PlayerPrefs.GetFloat("minutes");
        raceActive = PlayerPrefs.GetInt("active");
    }

    // Update is called once per frame
    void Update()
    {
        timerText.text = raceTimerMinutes.ToString("00") + ":" + raceTimerSeconds.ToString("00");
        if (raceActive == 1) {
            raceTimerSeconds += Time.deltaTime;
            if (raceTimerSeconds > 59)
            {
                raceTimerMinutes += 1;
                raceTimerSeconds = 0;
            }
        }
        PlayerPrefs.SetFloat("seconds", raceTimerSeconds);
        PlayerPrefs.SetFloat("minutes", raceTimerMinutes);
    }

    public void StartRace()
    {
        raceActive = 1;
        PlayerPrefs.SetInt("active", raceActive);
        raceTimerSeconds = 0;
        raceTimerMinutes = 0;
    }

    public void EndRace()
    {
        raceActive = 0;
        PlayerPrefs.SetInt("active", raceActive);

        results.SetActive(true);
        results.SendMessage("DisplayResults", new Vector2(raceTimerMinutes, raceTimerSeconds));

        raceTimerSeconds = 0;
        PlayerPrefs.SetFloat("seconds", raceTimerSeconds);
        raceTimerMinutes = 0;
        PlayerPrefs.SetFloat("minutes", raceTimerMinutes);
    }

    public void ResetTimer()
    {

    }
}
