using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class Ball : MonoBehaviour
{

    Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.position = new Vector3(0, -1.3f, 0);
        rb.velocity = Vector3.zero;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(Controller.score);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Controller.score += 1;
        rb.position = new Vector3(0, -1.3f, 0);
        rb.velocity = Vector3.zero;

    }
}
