using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class garden : MonoBehaviour
{

    public int maxNumSteps;
    int numSteps = 0;

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.CompareTag("Player")) { 
        
            numSteps++;

            if (numSteps >= maxNumSteps)
            {

                Debug.Log("mad");

            }

            else {

                Debug.Log("Stop that");

            }
        
        }

    }

}
