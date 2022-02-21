using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class monsterDialog : MonoBehaviour
{

    private void Update()
    {

        if (GetComponent<dialogScript>().startingIndex == 23) {

            Debug.Log("monsters");
            playerStats.talkedToMonsters = true;
        
        }

    }

}
