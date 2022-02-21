using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mouseDialog : MonoBehaviour
{

    public void Start()
    {

        if (playerStats.talkedToMonsters) {

            GetComponent<dialogScript>().startingIndex = 27;

        }
            
        else if (playerStats.hasFish) { 
        
            GetComponent<dialogScript>().startingIndex = 18;
        
        }

    }

    public void Update()
    {
        if (GetComponent<dialogScript>().startingIndex == 15)
        {

            playerStats.talkedToCats = true;

        }

        else if (GetComponent<dialogScript>().startingIndex == 46) {

            playerStats.catsPeace = true;

        }

    }

}
