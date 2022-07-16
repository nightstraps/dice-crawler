using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class diceMaster : MonoBehaviour
{
    public class Dice
    {
        public int sides;
        int maxEffects;
        int[] effects;

        public Dice(int sides, int maxEffects)
        {
            sides = 6;
            maxEffects = 3;
            effects = new int[maxEffects];

            for (int i=0; i<maxEffects; i++)
            {
                effects[i] = 0;
            }
        }

        public void addEffect(int effect)
        {
        }
    }
}