using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(movement))]
[RequireComponent(typeof(Animator))]

public class catScript : MonoBehaviour
{

    Vector2 move;

    private void Start()
    {
        

    }

    // Update is called once per frame
    void Update()
    {
        if (GetComponent<movement>().rawMovement.x > 0)
        {

            GetComponent<Transform>().rotation = Quaternion.Euler(0, 180, 0);

        }

        else {

            GetComponent<Transform>().rotation = Quaternion.Euler(0, 0, 0);

        }


        if (GetComponent<movement>().rawMovement.x != 0 || GetComponent<movement>().rawMovement.y != 0)
        {

            GetComponent<Animator>().SetBool("isWalking", true);

        }

        else {

            GetComponent<Animator>().SetBool("isWalking", false);

        }


        
    }
}
