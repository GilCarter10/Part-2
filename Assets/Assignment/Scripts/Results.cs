using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Results : MonoBehaviour
{
    TextMeshProUGUI resultsText;

    void Start()
    {
        gameObject.SetActive(false);
        resultsText = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DisplayResults(Vector2 time)
    {
        resultsText.text = "Your time was " + time.x.ToString("00") + ":" + time.y.ToString("00");

    }
}
