using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class penguin : MonoBehaviour
{



    Animator animator;
    Rigidbody2D rb;
    public Vector2 walkDestination;
    public Vector2 walkMovement;
    public float speed;
    bool sliding;
    float slideTimer = 0;

    void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        speed = 3;
        sliding = false;
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
        if(Input.GetMouseButtonDown(0))
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



    }
}
