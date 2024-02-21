using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalkeeperControlller : MonoBehaviour
{
    public Rigidbody2D gkRB;
    Vector2 selectedPlayerPos;
    Vector2 playerToGoal;
    Vector2 goalPos;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        selectedPlayerPos = Controller.CurrentSelection.transform.position;
        goalPos = transform.position;
        playerToGoal = new Vector2(goalPos.x - selectedPlayerPos.x, goalPos.y - selectedPlayerPos.x);

        gkRB.position = playerToGoal.normalized;
    }
}
