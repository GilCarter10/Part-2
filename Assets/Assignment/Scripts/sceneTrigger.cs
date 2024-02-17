using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class sceneTrigger : MonoBehaviour
{
    public void OnTriggerEnter2D(Collider2D collision)
    {
        collision.SendMessage("SaveY");
        int activeScene = SceneManager.GetActiveScene().buildIndex;
        int nextScene = (activeScene + 1) % SceneManager.sceneCountInBuildSettings;
        SceneManager.LoadScene(nextScene);
        
    }
}
