using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CircleCollider2D))]

public class guardingMovement : movement
{

    Vector2 startPosition;
    Coroutine movementRoutine;
    GameObject player;

    void Start()
    {

        startPosition = transform.position;
        rb2D = GetComponent<Rigidbody2D>();
        movementRoutine = StartCoroutine(moveBackRoutine());

    }

    private IEnumerator moveBackRoutine() {

        while (true) {

            yield return new WaitForFixedUpdate();

            rawMovement = startPosition - (Vector2)transform.position;

            if (rawMovement.magnitude < speed / 60)
            {

                rawMovement = Vector2.zero;

            }

            rb2D.velocity = rawMovement.normalized * speed;

        }

    }

    public IEnumerator followRoutine()
    {

        while (true)
        {

            yield return new WaitForFixedUpdate();

            rawMovement = (Vector2)player.transform.position - (Vector2)transform.position;

            if (rawMovement.magnitude < speed / 60)
            {

                rawMovement = Vector2.zero;

            }

            rb2D.velocity = rawMovement.normalized * speed;

        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.CompareTag("Player")) { 
        
            player = collision.gameObject;
            StopCoroutine(movementRoutine);
            movementRoutine = StartCoroutine(followRoutine());
        
        }

    }

    private void OnTriggerExit2D(Collider2D collision)
    {

        if (collision.CompareTag("Player"))
        {

            player = null;
            StopCoroutine(movementRoutine);
            movementRoutine = StartCoroutine(moveBackRoutine());

        }

    }

}
