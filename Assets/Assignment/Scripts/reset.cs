using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class reset : MonoBehaviour
{
    //this object is an invisble trigger where the penguin spawns in the first scene

    public GameObject timer;
    public GameObject penguin;

    private void OnTriggerStay2D(Collider2D collision) //when the penguin is in the trigger zone
    {
        timer.SendMessage("ResetTimer"); //reset timer
        penguin.SendMessage("ResetPlayer"); //reset player values
    }
}
