using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fireBreath : MonoBehaviour
{

    Coroutine damage;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && !collision.isTrigger)
        {

            damage = StartCoroutine(collision.gameObject.GetComponent<character>().DamageCharacter(1, 0));

        }

    }

}
