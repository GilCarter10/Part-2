using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Android.Types;

public class soccor_player : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;
    Rigidbody2D rb;
    public float speed = 100;
    public Color unSelectedColor;
    public Color selectedColor;

    void Start()
    {
        spriteRenderer.color = unSelectedColor;
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
     
    }

    private void OnMouseDown()
    {
        Controller.SetCurrentSelection(this);
    }

    public void Selected(bool isSelected)
    {
        if (isSelected)
        {
            spriteRenderer.color = selectedColor;
        }
        else
        {

            spriteRenderer.color = unSelectedColor;
         
        }

    }

    public void Move(Vector2 direction)
    {
        rb.AddForce(direction * speed, ForceMode2D.Impulse);
    }

}
