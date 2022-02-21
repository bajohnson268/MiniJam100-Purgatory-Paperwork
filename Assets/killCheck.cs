using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class killCheck : MonoBehaviour
{

    private void Update()
    {

        if (GameObject.FindObjectOfType<catScript>() == null) {

            Debug.Log("you monster");
            playerStats.killedCats = true;
        
        }

    }

}
