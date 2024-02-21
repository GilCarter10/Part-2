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
        gameObject.SetActive(false); //not active until told
        resultsText = GetComponent<TextMeshProUGUI>(); //get text mesh pro component
    }


    public void DisplayResults(Vector2 time)
    {
        resultsText.text = "Your time was " + time.x.ToString("00") + ":" + time.y.ToString("00"); //text will show the time results given from the timer object

    }
}
