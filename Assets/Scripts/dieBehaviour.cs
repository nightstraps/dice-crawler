using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dieBehaviour : MonoBehaviour
{   
    public dice thisDie;
    void OnMouseDown()
    {
        diceMaster diceMasterScript = FindObjectOfType<diceMaster>();
        if (!diceMasterScript.bagFullBool)
        {
            diceMasterScript.AddToBag(thisDie, diceMasterScript.playerBag);
            Destroy(gameObject);
        }
        else 
        {
            //dice is being displayed in inventory
            diceMasterScript.attackEnemy(thisDie);
            Destroy(gameObject);
        }
    }
}
