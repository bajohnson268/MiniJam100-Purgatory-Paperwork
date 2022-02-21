using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fishEnable : MonoBehaviour
{
    private void Update()
    {

        if (playerStats.hasFish || playerStats.killedCats)
        {

            GetComponent<enable>().disableAll();

        }

        else
        {

            GetComponent<enable>().enableAll();

        }

    }

}
