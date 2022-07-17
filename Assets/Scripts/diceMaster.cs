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
    int startPoolSize = 11;
    int maxPlayerBagSize = 6;
    int playerBagSize = 4;
    int playerHandSize = 3; 

    dice[] startingPool;
    public dice[] playerBag;
    dice[] playerHand;
    
    int numberOfDiceInBag = 0;
    public bool bagFullBool = false;
    
    public enemyScript target;

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
        playerHand = new dice[playerHandSize];
        
        //populating pool with generic dice
        for (int i=0; i<startPoolSize; i++)
        {
            startingPool[i] = new dice();
        }
        positionAllDice(startingPool, startPoolSize, 0);
    }
    //all die must be instantiated
    void positionAllDice(dice[] x, int numDie, int y)
    {
        int oddOrEvenPool = numDie%2;
        for (int i=0; i<numDie; i++)
        {
            if(oddOrEvenPool == 1)
            {
                if (i < numDie/2 + 0.5)
                {
                    startingPool[i].posx = -numDie/2 - 1/2 + i * 2;
                    startingPool[i].posy = y+2;
                }
                else
                {
                    startingPool[i].posx = -numDie/2 - 1/2 + (i - numDie/2 - 1) * 2 + 1;
                    startingPool[i].posy = y;
                }
            }
            else if(oddOrEvenPool == 0)
            {
                if(i < numDie/2)
                {
                    startingPool[i].posx = (i * 2 - numDie/2) + 1;
                    startingPool[i].posy = y+2;
                }
                else
                {
                    startingPool[i].posx = (i - numDie/2)*2 - numDie/2 + 1;
                    startingPool[i].posy = y;
                }
            }
        } 
    }
    
    bool startEnemyScene = false;
    void Update()
    {
        //TODO: 
        // 1. right now, the die prefab comes preloaded with the 6 sided dice sprite. find out a way to change it according to
        //the number of sides it has
        // 2. we need the dice to respond to clicking...you can accomplish this by just taking the die from the startingPool,
        // and putting it into the bag (variable) DONE
        //...
        
        //loadout scene
        if (SceneManager.GetActiveScene().buildIndex == 1)
        {
            if (numberOfDiceInBag < playerBagSize)
            {
                for (int i=0; i<startPoolSize; i++)
                {
                    renderDice(startingPool[i]);
                } 
            }
            else //all desired dice are loaded, destroy the rest and enable button for next scene
            {
                for (int i=0; i<startPoolSize; i++)
                {
                    //make this into derender function later
                    Destroy(startingPool[i].me);
                    startingPool[i].rendered = false;
                }
                if (SceneManager.GetActiveScene().buildIndex == 1)
                {
                    Button backButton = GameObject.Find("Continue Button").GetComponent<Button>();
                    backButton.interactable = true;
                }
            } 
        }
        else if (SceneManager.GetActiveScene().buildIndex == 2) //enemies scene
        {
            //populate player hand, only do this if we're missing die
            if (!startEnemyScene)
            {
                target = FindObjectOfType<enemyScript>();
                for (int i=0; i<playerHandSize; i++)
                {
                    //currentDice
                    dice selectedDice = playerBag[Random.Range(0, playerBagSize)];
                    dice currentDie = new dice(selectedDice.numSides, selectedDice.maxEffects, selectedDice.getEffects(), 2*i - 10, 0);
                    playerHand[i] = currentDie;
                    renderDice(playerHand[i]);
                }
                startEnemyScene = true;   
            }
                 
        }    
    }
    int previousValue = -1;
    dice drawDice()
    {
        //draw random dice from playerBag
        int value = Random.Range(0, maxPlayerBagSize);
        //prevent the same dice getting pulled twice in a row
        while (value == previousValue)
        {
            value = Random.Range(0, maxPlayerBagSize - 1);
        }        
        previousValue = value;
        return(playerBag[value]);
    }
    
    public void attackEnemy(dice x)
    {
        //target represents the enemy script
        target.takeDamage(x.rollDice());
    }

    //gives the dice a sprite
    void renderDice(dice x)
    {
        if ((x != null) && !(x.rendered))
        {
            x.rendered = true;
            x.me = GameObject.Instantiate(diePrefab, new Vector3(x.posx, x.posy, 0), Quaternion.identity);
            dieBehaviour behaviour = x.me.GetComponent<dieBehaviour>();
            behaviour.thisDie = x;
            
        }
    }

    void renderDice(dice[] x)
    {
        foreach (dice die in x)
        {
            if ((die != null) && !(die.rendered))
            {
                die.rendered = true;
                die.me = GameObject.Instantiate(diePrefab, new Vector3(die.posx, die.posy, 0), Quaternion.identity);
                dieBehaviour behaviour = die.me.GetComponent<dieBehaviour>();
                behaviour.thisDie = die;
                
            }
        }
    }
}