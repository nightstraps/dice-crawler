using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class riskBar : MonoBehaviour
{
    Slider riskSlider;

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
