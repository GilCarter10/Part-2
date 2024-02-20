using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class StartFinishLine : MonoBehaviour
{
    public string type;
    public GameObject timer;
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (type == "start")
        {
            timer.SendMessage("StartRace");
        } else if (type == "finish")
        {
            timer.SendMessage("EndRace");
        }
        
    }
}
