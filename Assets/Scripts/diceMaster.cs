using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class diceMaster : MonoBehaviour
{
    public Sprite[] diceSprites;
    public GameObject diePrefab;

    //use this to instantiate the starting pool that player draws from
    int startPoolSize = 12;
    dice[] startingPool;
    //this is the player's current bag
    int maxPlayerBagSize = 6;
    int playerBagSize = 4;
    public dice[] playerBag;
    int numberOfDiceInBag = 0;
    public bool bagFullBool = false;
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
            numberOfDiceInBag++;
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
        DontDestroyOnLoad(gameObject);
        startingPool = new dice[startPoolSize];
        playerBag = new dice[maxPlayerBagSize];
        
        //populating pool with generic dice
        for (int i=0; i<startPoolSize; i++)
        {
            int oddOrEvenPool = startPoolSize%2;
            if(oddOrEvenPool == 1)
            {
                if (i < startPoolSize/2 + 0.5)
                {
                    startingPool[i] = new dice(-startPoolSize/2 - 1/2 + i * 2, 2);
                }
                else
                {
                    startingPool[i] = new dice(-startPoolSize/2 - 1/2 + (i - startPoolSize/2 - 1) * 2, 0);
                }
            }
            else if(oddOrEvenPool == 0)
                if(i < startPoolSize/2)
                {
                    startingPool[i] = new dice((i * 2 - startPoolSize/2), 2);
                }
                else
                {
                    startingPool[i] = new dice((i - startPoolSize/2)*2 - startPoolSize/2, 0);
                }
        }
    }


    void Update()
    {
        //TODO: 
        // 1. right now, the die prefab comes preloaded with the 6 sided dice sprite. find out a way to change it according to
        //the number of sides it has
        // 2. we need the dice to respond to clicking...you can accomplish this by just taking the die from the startingPool,
        // and putting it into the bag (variable) DONE
        //...
        // figure out way to change to 
        if (numberOfDiceInBag < playerBagSize)
        {
            for (int i=0; i<startPoolSize; i++)
            {
                renderDice(startingPool[i]);
            } 
        }
        else
        {
            for (int i=0; i<startPoolSize; i++)
            {
                Destroy(startingPool[i].me);
            }
            if (SceneManager.GetActiveScene().buildIndex != 2)
            {
                Button backButton = GameObject.Find("Continue Button").GetComponent<Button>();
                backButton.interactable = true;
            }
            Debug.Log("finished picking dice!");
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