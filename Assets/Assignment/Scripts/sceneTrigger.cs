using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class sceneTrigger : MonoBehaviour
{
    public void OnTriggerEnter2D(Collider2D collision) //when you collide with the scene trigger
    {
        collision.SendMessage("SaveY"); //save the penguins y value
        int activeScene = SceneManager.GetActiveScene().buildIndex;
        int nextScene = (activeScene + 1) % SceneManager.sceneCountInBuildSettings;
        SceneManager.LoadScene(nextScene); //load the next scene in the scene list
        
    }
}
