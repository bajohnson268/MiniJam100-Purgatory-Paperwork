using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class disableDoor : MonoBehaviour
{

    private void Update()
    {

        if (playerStats.talkedToCats || playerStats.killedCats)
        {

            GetComponent<enable>().enableAll();

        }

        else {

            GetComponent<enable>().disableAll();

        }

    }

}
