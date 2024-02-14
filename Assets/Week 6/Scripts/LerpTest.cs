using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LerpTest : MonoBehaviour
{
    public Transform startPosition;
    public Transform endPosition;
    public float lerpTimer;
    public AnimationCurve animationCurve;
    public float interpolation;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        interpolation = animationCurve.Evaluate(lerpTimer);
        transform.position = Vector3.Lerp(startPosition.position, endPosition.position, interpolation);
        lerpTimer += Time.deltaTime;
    }
}
