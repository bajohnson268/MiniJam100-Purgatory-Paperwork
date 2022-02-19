using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class directionalMovement : movement
{

    [SerializeField] float movementX;
    [SerializeField] float movementY;

    // Start is called before the first frame update
    void Start()
    {

        rb2D = GetComponent<Rigidbody2D>();
        rb2D.velocity = new Vector2(movementX, movementY).normalized * speed;

    }

}
