using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class healthBar : MonoBehaviour
{
    public Slider healthSlider;

    private void awake()
    {
        healthSlider.value = 0;
    }
    public void AddHealth(int heal)
    {
        healthSlider.value += heal;
    }
    public void RemoveHealth(int damage)
    {
        healthSlider.value -= damage;
    }
    public void IncreaseMaxHealth(int maxIncrease)
    {
        healthSlider.maxValue += maxIncrease;
        healthSlider.value += maxIncrease;
    }
    public void DecreaseMaxHealth(int maxDecrease)
    {
        healthSlider.value -= maxDecrease;
        healthSlider.maxValue -= maxDecrease;
    }
}
