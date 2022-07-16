using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class diceMaster : MonoBehaviour
{
    public class Dice()
    {
        public int sides;
        int maxEffects;
        int[] effects;

        public dice(int sides, int maxEffects)
        {
            sides = 6;
            maxEffects = 3;
            effects = new int[maxEffects];

            for (int i=0; i<maxEffects; i++)
            {
                effects[i] = 0;
            }
        }

        public addEffect(int effect)
        {
        }
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
