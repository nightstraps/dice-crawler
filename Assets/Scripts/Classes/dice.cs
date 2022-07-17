using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dice
{
    static int totalDice;
    private int diceId;

    //0 represents x, 1 represents x and so on. This helps track what number is equal to what effect name
    enum effectAlias{EFFECT1, EFFECT2};

    public int numSides;
    public int maxEffects;
    //-1 represents empty effects slot
    int[] effects;
    
    public int posx;
    public int posy;

    //when accompanying image is rendered, set to true
    public bool rendered = false;
    public GameObject me;

    //generic dice constructor
    public dice()
    {
        diceId = totalDice;
        totalDice++;
        numSides = 6;
        maxEffects = 3;
        effects = new int[maxEffects];
        for (int i=0; i<maxEffects; i++){effects[i] = -1;}
        posx = 0;
        posy = 0;
    }

    //TODO: find texture based off number of sides
    //better dice constructor
    public dice(int numSides, int maxEffects, int x, int y)
    {
        diceId = totalDice;
        totalDice++;
        this.numSides = numSides;
        this.maxEffects = maxEffects;
        effects = new int[maxEffects];
        for (int i=0; i<maxEffects; i++){ effects[i] = -1;}
        posx = x;
        posy = y;
    }
    public dice(int numSides, int maxEffects, int[] effects, int x, int y)
    {
        diceId = totalDice;
        totalDice++;
        this.numSides = numSides;
        this.maxEffects = maxEffects;
        effects = new int[maxEffects];
        this.effects = effects;
        posx = x;
        posy = y;
    }

    //location specified
    public dice(int x, int y)
    {
        diceId = totalDice;
        totalDice++;
        numSides = 6;
        maxEffects = 3;
        effects = new int[maxEffects];
        for (int i=0; i<maxEffects; i++){ effects[i] = -1;}
        posx = x;
        posy = y;
    }

    public int[] getEffects()
    {
        return effects;
    }
    //prints all the values
    public void debugDice()
    {
        Debug.Log("dice number: " + diceId + " number of sides: " + numSides + "\n");
        /**
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
        **/
    }

    //roll dice, returns any number from 1 to numSides
    public int rollDice()
    {
        /**
        for (int i=0; i<effects.Length; i++)
        {
            //check if there is an effect at effects[i]
            //if there is effect, apply the effect
            //you might have to add a field to the class that specifies the player or enemy the dice is attatched to, or the target.
            
            //in terms of turn based... put advancing one turn into a function
        }
        **/
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
