using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dice
{
    public int test;

    //0 represents x, 1 represents x and so on. This helps track what number is equal to what effect name
    enum effectAlias{EFFECT1, EFFECT2};

    int numSides;
    int maxEffects;
    int[] effects;
    
    public int posx;
    public int posy;

    //when accompanying image is rendered, set to true
    public bool rendered = false;
    public GameObject me;

    //generic dice constructor
    public dice()
    {
        numSides = 6;
        maxEffects = 3;
        effects = new int[maxEffects];
        for (int i=0; i<maxEffects; i++){ effects[i] = -1;}
        posx = 0;
        posy = 0;
    }

    //TODO: find texture based off number of sides
    //better dice constructor
    public dice(int numSides, int maxEffects, int x, int y)
    {
        this.numSides = numSides;
        this.maxEffects = maxEffects;
        effects = new int[maxEffects];
        for (int i=0; i<maxEffects; i++){ effects[i] = -1;}
        posx = x;
        posy = y;
    }

    //location specified
    public dice(int x, int y)
    {
        numSides = 6;
        maxEffects = 3;
        effects = new int[maxEffects];
        for (int i=0; i<maxEffects; i++){ effects[i] = -1;}
        posx = x;
        posy = y;
    }

    //prints all the values
    public void debugDice()
    {
        Debug.Log("number of sides: " + numSides + "\n");
        Debug.Log("max number of effects "+ maxEffects);
        Debug.Log("contains the following effects: ");
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
