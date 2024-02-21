using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fish : MonoBehaviour
{

    private void OnCollisionEnter2D(Collision2D collision) //if the fish collides with the penguin
    {
        collision.gameObject.SendMessage("MaxStamina"); //give the penguin max stamina
        Destroy(gameObject); //destroy
    }

}
