using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class killCheck2 : MonoBehaviour
{
    private void Update()
    {

        if (GameObject.FindObjectOfType<monsterScript>() == null)
        {

            Debug.Log("you monster");
            playerStats.killedMonsters = true;

        }

    }
}
