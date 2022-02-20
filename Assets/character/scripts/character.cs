using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(BoxCollider2D))]

public abstract class character : MonoBehaviour
{

    [HideInInspector]
    public Rigidbody2D rb2D;

    [HideInInspector]
    public Animator anim;

    [HideInInspector]
    public SpriteRenderer spriteRen;

    public int maxHealth;
    public int health;

    public void Start()
    {
        
        rb2D = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        spriteRen = GetComponent<SpriteRenderer>();

    }

    public abstract void KillCharacter();

    public virtual IEnumerator FlickerCharacter()
    {
        // Tint the sprite red
        GetComponent<SpriteRenderer>().color = Color.red;

        // Wait for 0.1 seconds
        yield return new WaitForSeconds(0.1f);

        // Change the sprite back to default color
        GetComponent<SpriteRenderer>().color = Color.white;
    }

    public virtual IEnumerator DamageCharacter(int damage, float interval)
    {
        // Continuously inflict damage until the loop breaks
        while (true && damage != 0)
        {

            StartCoroutine(FlickerCharacter());

            // Inflict damage
            health = health - damage;

            // Player is dead; kill off game object and exit loop
            if (health <= 0)
            {

                KillCharacter();
                break;
            }

            if (interval > 0)
            {
                // Wait a specified amount of seconds and inflict more damage
                yield return new WaitForSeconds(interval);
            }
            else
            {
                // Interval = 0; inflict one-time damage and exit loop
                break;
            }
        }
    }

}
