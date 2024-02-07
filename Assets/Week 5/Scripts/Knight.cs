using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knight : MonoBehaviour
{
    Rigidbody2D rb;
    Vector2 destination;
    Vector2 movement;
    public float speed = 3;
    Animator animator;
    bool clickOnSelf = false;
    public float health;
    public float maxHealth = 5;
    bool isDead = false;
    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        health = maxHealth;
    }

    private void FixedUpdate()
    {
        if (isDead) return;
        movement = destination - (Vector2)transform.position;
        if(movement.magnitude < 0.1)
        {
            movement = Vector2.zero;
        }
        rb.MovePosition(rb.position + movement.normalized * speed * Time.deltaTime);
    }

    void Update()
    {
        if (isDead) return;
        if(Input.GetMouseButtonDown(0) & clickOnSelf == false) 
        {
            destination = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        }
        animator.SetFloat("Movement", movement.magnitude);

    }

    private void OnMouseDown()
    {
        if(isDead) return;
        SendMessage("TakeDamage", 1);
        clickOnSelf = true;
    }

    private void OnMouseUp()
    {
        clickOnSelf = false;
    }

    public void TakeDamage(float damage)
    {
        health -= damage;
        health = Mathf.Clamp(health, 0, maxHealth);
        if (health <= 0)
        {
            animator.SetTrigger("Death");
            isDead = true;
        } else
        {
            animator.SetTrigger("TakeDamage");
            isDead = false;

        }
        
    }
}
