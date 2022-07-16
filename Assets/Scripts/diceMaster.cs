using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class diceMaster : MonoBehaviour
{
    public Sprite[] diceSprites;
    public GameObject diePrefab;

    //use this to instantiate the starting pool that player draws from
    int startPoolSize = 12;
    dice[] startingPool;
    //this is the player's current bag
    int playerBagSize = 4;
    dice[] bag;

    bool startingScreen = true;

    void Start()
    {
        //CHANGES: spawning and controlling image sprites happens independently from creating dice objects now.
        startingPool = new dice[startPoolSize];
        bag = new dice[playerBagSize];
        
        //populating pool with generic dice
        for (int i=0; i<startPoolSize; i++)
        {
            startingPool[i] = new dice(i - 5, 0);
        }
    }

    void Update()
    {
        //TODO: 
        // 1. right now, the die prefab comes preloaded with the 6 sided dice sprite. find out a way to change it according to
        //the number of sides it has
        // 2. we need the dice to respond to clicking...you can accomplish this by just taking the die from the startingPool,
        // and putting it into the bag (variable)
        //...
        // these are the hard parts. once these are finished everything will be super easy

        if (startingScreen)
        {
            //do all work related to the loadout page here, don't forget to set startingScreen=false when the loading out is finished.
            for (int i=0; i<startPoolSize; i++)
            {
                renderDice(startingPool[i]);
            }   
        }
          
    }

    void renderDice(dice x)
    {
        if (!(x.rendered))
        {
            x.rendered = true;
            x.me = GameObject.Instantiate(diePrefab, new Vector3(x.posx, x.posy, 0), Quaternion.identity);
            
        }
    }
}