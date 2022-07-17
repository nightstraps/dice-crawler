using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyScript : MonoBehaviour
{
    public GameObject player;
    SpriteRenderer sr;
    dice myDice;

    int health = 12;

    void Start()
    {
        sr = gameObject.GetComponent<SpriteRenderer>();
        myDice = new dice();
    }

    void Update()
    {
        if (health <= 0)
        {
            Debug.Log("enemy dead!");
        }
    }

    public void takeDamage(int damage)
    {
        health -= damage;
        Debug.Log("took " + damage + " damage!");
        return;
    }

    public void enemyTakeTurn()
    {
        //make player take hit based off dice
        return;
    }
}
