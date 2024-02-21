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

            spriteRenderer.color = Color.white;
         
        }

    }

    private void OnMouseDown()
    {
        Selected(true);
    }

}
