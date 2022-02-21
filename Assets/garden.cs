using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class garden : MonoBehaviour
{

    public int maxNumSteps;
    int numSteps = 0;

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.CompareTag("Player") && !collision.isTrigger) { 
        
            numSteps++;

            Debug.Log(numSteps);

            if (numSteps >= maxNumSteps)
            {

                GetComponent<dialogScript>().startingIndex = 3;
                playerStats.monstersMad = true;

            }

            else {

               //Debug.Log("Stop that");

            }
        
        }

    }

}
