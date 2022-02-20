using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(movement))]
[RequireComponent(typeof(Animator))]

public class catScript : character
{

    Vector2 move;

    public bool Agressive;

    float fireCooldown = 1.25f;
    float timeOfNextFire;

    public override void KillCharacter()
    {
        
        gameObject.SetActive(false);

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

        if (Agressive) {

            GetComponent<movement>().followPlayer = true;

            if ((GameObject.Find("player").transform.position - gameObject.transform.position).magnitude < .75 && timeOfNextFire < Time.time) {

                StartCoroutine(fire());

                timeOfNextFire = Time.time + fireCooldown;
            
            }

        }
        
    }

    public IEnumerator fire() {

        gameObject.transform.GetChild(0).gameObject.SetActive(true);

        yield return new WaitForSeconds(.5f);

        gameObject.transform.GetChild(0).gameObject.SetActive(false);

    }

}
