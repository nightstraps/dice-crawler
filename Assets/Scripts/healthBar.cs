using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class healthBar : MonoBehaviour
{
    public GameObject sceneManagerObject;
    public Slider healthSlider;
    public Text healthText;
    public float deathTime;
    float deathTimer;

    private void Awake()
    {
        healthSlider.value = 100;
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
    void Update()
    {
        if(healthSlider.value == 0)
        {
            deathTimer += Time.deltaTime;
            if(deathTimer > deathTime)
            {
                sceneLoader sceneManagerScript = sceneManagerObject.GetComponent<sceneLoader>();
                sceneManagerScript.LoadLoseScene();
            }
        }
        healthText.text = healthSlider.value.ToString();
    }
}