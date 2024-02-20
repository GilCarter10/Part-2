using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.SocialPlatforms.Impl;
using JetBrains.Annotations;

public class penguin : MonoBehaviour
{

    Animator animator;
    Rigidbody2D rb;
    public Vector2 walkDestination;
    public Vector2 walkMovement;
    public float speed;
    bool sliding;
    float slideTimer = 0;
    public float savedY;
    public Vector3 pos;
    public GameObject blockGroup;
    bool stopMoving;


    void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        speed = 3;
        sliding = false;

        pos = transform.position;
        savedY = PlayerPrefs.GetFloat("savedY");
        transform.position = new Vector3 (-8, savedY, 0);
        walkDestination = transform.position;

    }

    private void FixedUpdate()
    {
        walkMovement = walkDestination - (Vector2)transform.position;
        if (walkMovement.magnitude < 0.1)
        {
            walkMovement = Vector2.zero;
        }
        rb.MovePosition(rb.position + walkMovement.normalized * speed * Time.deltaTime);
    }


    void Update()
    {
        pos = transform.position;


        if (Input.GetMouseButtonDown(0))
        {
            walkDestination = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        }
        animator.SetFloat("walkMovement", walkMovement.magnitude);

        //slide
        if (walkMovement.magnitude > 0.1)
        {
            if (Input.GetKey(KeyCode.Space))
            {
                sliding = true;
            }
        }

        if (sliding)
        {
            animator.SetBool("isSlide", true);
            speed = 7;
            slideTimer += Time.deltaTime;
            blockGroup.BroadcastMessage("Attack");
            if (slideTimer > 0.9)
            {
                sliding = false;
                animator.SetBool("isSlide", false);
                speed = 3;
                slideTimer = 0;
                
            }
        }


        if (Input.GetMouseButtonDown(1))
        {
            animator.SetTrigger("isAttack");
            blockGroup.BroadcastMessage("Attack");
        }


        if (stopMoving)
        {
            if (Input.GetMouseButtonDown(0))
            {
                animator.SetTrigger("isAttack");
                blockGroup.BroadcastMessage("Attack");
                stopMoving = false;
            }
        }
    }

    public void StopMoving()
    {
        stopMoving = true;
        walkMovement = Vector2.zero;
        walkDestination = pos;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (sliding == false)
        {
            StopMoving();
        }

    }

    public void SaveY()
    {
        PlayerPrefs.SetFloat("savedY", pos.y);
        savedY = PlayerPrefs.GetFloat("savedY");
    }

    public void EndRace()
    {
        PlayerPrefs.SetFloat("savedY", 0.49f);
    }

}
