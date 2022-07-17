using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dieBehaviour : MonoBehaviour
{    
    public dice thisDie;
    void OnMouseDown()
    {
        diceMaster diceMasterScript = FindObjectOfType<diceMaster>();
        if (diceMasterScript.bagFullBool == false)
        {
            diceMasterScript.AddToBag(thisDie, diceMasterScript.playerBag);
            Destroy(gameObject);
        }
    }
}
