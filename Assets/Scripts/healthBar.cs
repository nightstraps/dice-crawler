using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class healthBar : MonoBehaviour
{
    public Slider healthSlider;

    public void AddHealth(int heal)
    {
        healthSlider.value += heal;
    }
    public void RemoveHealth(int damage)
    {
        healthSlider.value -= damage;
    }
}
