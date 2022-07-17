using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class riskBar : MonoBehaviour
{
    public Slider riskSlider;
    public Text riskText;

    private void Awake()
    {
        riskSlider.value = 0;
    }
    public void IncreaseRisk(int dieSides)
    {
        riskSlider.value += dieSides;
    }
    void Update()
    {
        if(riskSlider.value == 100)
        {
            //risk effect stuff
        }
        riskText.text = riskSlider.value.ToString();
    }
}
