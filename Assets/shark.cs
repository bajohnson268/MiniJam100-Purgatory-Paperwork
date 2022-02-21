using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(wanderMovement))]

public class shark : character
{

    float fireCooldown = 1.25f;
    float timeOfNextFire;

    Coroutine damage;

    public override void KillCharacter()
    {
        GetComponent<enable>().toggle();
        playerStats.hasFish = true;
        gameObject.SetActive(false);

    }

    private void Update()
    {

        if (GetComponent<movement>().rawMovement.x > 0)
        {

            GetComponent<Transform>().rotation = Quaternion.Euler(0, 0, 0);

        }

        else
        {

            GetComponent<Transform>().rotation = Quaternion.Euler(0, 180, 0);

        }


        if (GetComponent<movement>().rawMovement.x != 0 || GetComponent<movement>().rawMovement.y != 0)
        {

            GetComponent<Animator>().SetBool("isWalking", true);

        }

        else
        {

            GetComponent<Animator>().SetBool("isWalking", false);

        }

        if ((GameObject.Find("player").transform.position - gameObject.transform.position).magnitude < .75 && timeOfNextFire < Time.time)
        {

            StartCoroutine(fire());

            timeOfNextFire = Time.time + fireCooldown;

        }

    }

    public IEnumerator fire()
    {

        gameObject.transform.GetChild(0).gameObject.SetActive(true);

        yield return new WaitForSeconds(.5f);

        gameObject.transform.GetChild(0).gameObject.SetActive(false);

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.CompareTag("Player")) {

            damage = StartCoroutine(collision.gameObject.GetComponent<character>().DamageCharacter(1, 3));
        
        }

    }

    private void OnCollisionExit2D(Collision2D collision)
    {

        if (collision.gameObject.CompareTag("Player"))
        {

            StopCoroutine(damage);

        }

    }

}
