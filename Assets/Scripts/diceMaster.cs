using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class diceMaster : MonoBehaviour
{
    public class dice
    {
        //0 represents x, 1 represents x and so on. This helps track what number is equal to what effect name
        enum effectAlias{EFFECT1, EFFECT2};

        Sprite diceSprite;
        int numSides;
        int maxEffects;
        int[] effects;
        
        //generic dice constructor
        public dice()
        {
            numSides = 6;
            maxEffects = 3;
            effects = new int[maxEffects];
            for (int i=0; i<maxEffects; i++){ effects[i] = -1;}
        }

        //better dice constructor
        public dice(int numSides, int maxEffects)
        {
            this.numSides = numSides;
            this.maxEffects = maxEffects;
            effects = new int[maxEffects];
            //-1 represents no effects in that slot
            for (int i=0; i<maxEffects; i++){ effects[i] = -1;}
        }

        //prints all the values
        public void debugDice()
        {
            Debug.Log("number of sides: " + numSides);
            Debug.Log("max number of effects "+ maxEffects);
            Debug.Log("contains the following number of effects: ");
            for (int i=0; i<maxEffects; i++)
            {
                if (effects[i] != -1)
                {
                    Debug.Log((effectAlias)effects[i]);
                } 
                else 
                {
                    Debug.Log("...");
                }
            }
        }

        //roll dice, returns any number from 1 to numSides
        public int rollDice()
        {
            return Random.Range(1, numSides);
        }

        //TODO: addeffect overflow error handling. behaviour?
        //add an effect (it takes int for now, future plans for it to take name of effect instead, and use enum to turn into int)
        public void addEffect(int effect)
        {
            for (int i=0; i<maxEffects; i++)
            {
                if (effects[i] == -1)
                {
                    effects[i] = effect;
                    break;
                }
            }
        }
    }

    int bagSize;
    dice[] bag;

    void Start() 
    {

    }

    void Update()
    {

    }
}