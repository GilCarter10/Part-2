using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Unity.VisualScripting;
using static UnityEditor.PlayerSettings;
using UnityEditor;

public class iceBlock : MonoBehaviour
{
    bool shrink = false;
    public GameObject penguin;
    public float distance;

    public float lerpTimer;
    public AnimationCurve animationCurve;
    public float interpolation;



    void Start()
    {
        distance = Vector3.Distance(transform.position, penguin.transform.position); //distance from penguin player
    }

    void Update()
    {
        distance = Vector3.Distance(transform.position, penguin.transform.position); //update distance from penguin player
        
        if (shrink) 
        {
            interpolation = animationCurve.Evaluate(lerpTimer); //sets interpolation to the evaluation of the animation curve by the lerp timer
            if (transform.localScale.z < 0.1f) //if the scale is less than 0.1, destroy game object
                //this is to avoid have the object get infinitly small and lag the game
            {
                Destroy(gameObject);
                shrink = false;
            }

            transform.localScale = Vector3.Lerp(transform.localScale, Vector3.zero, interpolation); //lerp the object from normal sizee, to 0
            lerpTimer += Time.deltaTime; //increase lerp timer
        }
    }

    public void Attack() //when the penguin attacks
    {
        if (distance < 2) //if this ice block is in range
        {
            shrink = true; //begin shrink animation
        }
    }

}
