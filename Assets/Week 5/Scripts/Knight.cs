using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Knight : MonoBehaviour
{
    Rigidbody2D rb;
    Vector2 destination;
    Vector2 movement;
    public float speed = 3;
    Animator animator;
    bool clickOnSelf = false;
    public float health = 5;
    public float maxHealth = 5;
    bool isDead = false;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();

        health = PlayerPrefs.GetFloat("Health", 5);
        SendMessage("UpdateHealth", health);

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
        if(Input.GetMouseButtonDown(0) && clickOnSelf == false && !EventSystem.current.IsPointerOverGameObject()) 
        {
            destination = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        }
        animator.SetFloat("Movement", movement.magnitude);

        if(Input.GetMouseButtonDown(1) && clickOnSelf == false)
        {
            animator.SetTrigger("Attack");
        }
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

        PlayerPrefs.SetFloat("Health", health);
        health = PlayerPrefs.GetFloat("Health", health);

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
