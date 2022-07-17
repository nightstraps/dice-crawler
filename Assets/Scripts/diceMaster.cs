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
    public dice[] playerBag;
    int numberOfDiceInBag = 0;
    public bool bagFullBool = false;

    bool startingScreen = true;
    public void AddToBag(dice x, dice[] targetBag)
    {
        if (numberOfDiceInBag == playerBagSize - 1)
        {
            for (int i=0; i<playerBagSize; i++)
            {
                if (targetBag[i] == null)
                {
                    targetBag[i] = x;
                    break;
                }
            }
            bagFullBool = true;
        }
        else
        {
            //add the dice to the bag array
            for (int i=0; i<playerBagSize; i++)
            {
                if (targetBag[i] == null)
                {
                    targetBag[i] = x;
                    break;
                }
            }
            numberOfDiceInBag += 1;
        }
    }
    void Start()
    {
                //CHANGES: spawning and controlling image sprites happens independently from creating dice objects now.
        startingPool = new dice[startPoolSize];
        playerBag = new dice[playerBagSize];
        
        //populating pool with generic dice
        for (int i=0; i<startPoolSize; i++)
        {
            int oddOrEvenPool = startPoolSize%2;
            if(oddOrEvenPool == 1)
            {
                if (i < startPoolSize/2 + 0.5)
                {
                    startingPool[i] = new dice(-startPoolSize/2 - 1/2 + i * 2, 5);
                }
                else
                {
                    startingPool[i] = new dice(-startPoolSize/2 - 1/2 + (i - startPoolSize/2 - 1) * 2, 3);
                }
            }
            else if(oddOrEvenPool == 0)
                if(i < startPoolSize/2)
                {
                    startingPool[i] = new dice((i * 2 - startPoolSize/2), 5);
                }
                else
                {
                    startingPool[i] = new dice((i - startPoolSize/2)*2 - startPoolSize/2, 3);
                }
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

        foreach (dice x in playerBag)
        {
            if (x != null)
            {
                x.debugDice();
            }
        }
          
    }

    void renderDice(dice x)
    {
        if (!(x.rendered))
        {
            x.rendered = true;
            x.me = GameObject.Instantiate(diePrefab, new Vector3(x.posx, x.posy, 0), Quaternion.identity);
            dieBehaviour behaviour = x.me.GetComponent<dieBehaviour>();
            behaviour.thisDie = x;
            
        }
    }
}