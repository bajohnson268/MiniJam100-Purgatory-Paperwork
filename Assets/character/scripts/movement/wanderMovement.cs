using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CircleCollider2D))]

public class wanderMovement : movement
{

    public float stopChance;
    public float changeInterval;

    public bool followPlayer;

    private GameObject player;

    Coroutine movementRoutine;

    void Start()
    {

        rb2D = GetComponent<Rigidbody2D>();
        movementRoutine = StartCoroutine(wanderRoutine(changeInterval));

    }

    public IEnumerator wanderRoutine(float interval) {

        while (true)
        {

            yield return new WaitForSeconds(interval);

            if (Random.Range(0f, 1f) > stopChance)
            {

                rawMovement.x = Random.Range(-1f, 1f);
                rawMovement.y = Random.Range(-1f, 1f);

                rb2D.velocity = rawMovement.normalized * speed;

            }

            else
            {

                rawMovement.x = 0;
                rawMovement.y = 0;

                rb2D.velocity = Vector2.zero;

            }

        }
    
    }

    public IEnumerator followRoutine() {

        while (true) {

            yield return new WaitForFixedUpdate();

            rawMovement = (Vector2)player.transform.position - (Vector2)transform.position;
            rb2D.velocity = rawMovement.normalized * speed;

        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.CompareTag("Player") && followPlayer) { 
        
            player = collision.gameObject;
            StopCoroutine(movementRoutine);
            movementRoutine = StartCoroutine(followRoutine());
        
        }

    }

    private void OnTriggerExit2D(Collider2D collision)
    {

        if (collision.CompareTag("Player") && followPlayer)
        {

            player = null;
            StopCoroutine(movementRoutine);
            movementRoutine = StartCoroutine(wanderRoutine(changeInterval));

        }

    }

}
