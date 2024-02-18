using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.SocialPlatforms.Impl;

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
    public GameObject iceBlock;


    void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        speed = 3;
        sliding = false;

        pos = transform.position;
        savedY = PlayerPrefs.GetFloat("savedY");
        pos.y = savedY;

        walkDestination = rb.position;

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
            iceBlock.SendMessage("Attack");
        }

    }


    public void SaveY()
    {
        PlayerPrefs.SetFloat("savedY", pos.y);

        Debug.Log("jello");

    }

}
