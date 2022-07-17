using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class riskBar : MonoBehaviour
{
    Slider riskSlider;

    private void awake()
    {
        riskSlider.value = 0;
    }
    public void increaseRisk(int dieSides)
    {
        riskSlider.value += dieSides;
    }
    void update()
    {
        if(riskSlider.value == 100)
        {
            //risk effect stuff
        }
    }
}
