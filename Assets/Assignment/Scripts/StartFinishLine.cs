using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class StartFinishLine : MonoBehaviour
{
    public string type; //is it the start line or finish line
    public GameObject timer;
    public GameObject penguin;

    private void OnTriggerEnter2D(Collider2D collision) //when the penguin crosses the line
    {
        if (type == "start") //if its the start line
        {
            timer.SendMessage("StartRace"); //start timer
            penguin.SendMessage("StartRace"); //start stamina
        } else if (type == "finish") //if its the finish line
        {
            timer.SendMessage("EndRace"); //stop the timer and display results
        }
        
    }
}
