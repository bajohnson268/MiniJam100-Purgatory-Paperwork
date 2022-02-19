using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player2DTopdown : character
{

    public float speed;
    Vector2 movement;

    void FixedUpdate()
    {

        Movement();

    }

    void Movement() {

        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        movement.Normalize();

        rb2D.velocity = movement * speed;

        if (movement.x != 0 || movement.y != 0)
        {

            GetComponent<Animator>().SetBool("isMoving", true);

            if (movement.x < 0)
            {

                GetComponent<Transform>().rotation = Quaternion.Euler(0, 180, 0);

            }

            else
            {

                GetComponent<Transform>().rotation = Quaternion.Euler(0, 0, 0);

            }

        }

        else {

            GetComponent<Animator>().SetBool("isMoving", false);

        }

    }

}
