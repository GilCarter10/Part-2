using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class staminaBar : MonoBehaviour
{
    public Slider slider; //reference the UI slider

    public void UpdateStamina(float stamina)
    {
        slider.value = stamina; //update it so it reflects the stamina value from the penguin
    }
}
