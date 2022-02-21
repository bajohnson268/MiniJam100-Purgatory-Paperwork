using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class disableDoor : MonoBehaviour
{

    private void Update()
    {

        if (!playerStats.talkedToCats)
        {

            GetComponent<enable>().disableAll();

        }

        else {

            GetComponent<enable>().enableAll();

        }

    }

}
