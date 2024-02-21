using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Android.Types;

public class soccor_player : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;

    void Start()
    {
        spriteRenderer.color = Color.red;
    }

    // Update is called once per frame
    void Update()
    {
     
    }

    public void Selected(bool isSelected)
    {
        if (isSelected)
        {
            spriteRenderer.color = Color.green;
        }
        else
        {

            spriteRenderer.color = Color.red;
         
        }

    }

    private void OnMouseDown()
    {
        Controller.SetCurrentSelection(this);
    }

}
