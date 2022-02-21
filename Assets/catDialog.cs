using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class catDialog : MonoBehaviour
{
    public void Start()
    {

        if (playerStats.hasFish)
        {

            GetComponent<dialogScript>().startingIndex = 14;

        }

    }

}
