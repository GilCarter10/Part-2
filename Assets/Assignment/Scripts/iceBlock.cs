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
        distance = Vector3.Distance(transform.position, penguin.transform.position);
    }

    void Update()
    {
        distance = Vector3.Distance(transform.position, penguin.transform.position);

        if (shrink)
        {
            interpolation = animationCurve.Evaluate(lerpTimer);
            if (transform.localScale.z < 0.1f)
            {
                Destroy(gameObject);
                shrink = false;
            }
            transform.localScale = Vector3.Lerp(transform.localScale, Vector3.zero, interpolation);
            lerpTimer += Time.deltaTime;
        }
    }

    public void Attack()
    {
        if (distance < 2)
        {
            shrink = true;
        }
    }


}
