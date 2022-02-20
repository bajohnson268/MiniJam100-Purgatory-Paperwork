using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class player2DTopdown : character
{

    public float speed;
    Vector2 movement;

    bool isAttacking = false;
    
    float punchCooldown = .75f;
    float timeToNextPunch;

    character enemy;

    public int damage;

    public new void Start()
    {

        rb2D = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        spriteRen = GetComponent<SpriteRenderer>();

        if (playerStats.health != -1)
        {

            health = playerStats.health;

        }

        else {

            health = maxHealth;
        
        }

    }

    public override void KillCharacter()
    {
        //go to death screen
    }

    void FixedUpdate()
    {

        Movement();

    }

    private void Update()
    { 

        if (Input.GetKeyDown(KeyCode.Mouse0) && timeToNextPunch < Time.time) { 
        
            isAttacking = true;
            GetComponent<Animator>().SetBool("isAttacking", true);
            StartCoroutine(StopAttacking());

            if (enemy != null) {

                StartCoroutine(enemy.DamageCharacter(damage, 0));

            }


            timeToNextPunch = Time.time + punchCooldown;

        }

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

    public IEnumerator StopAttacking() {

        yield return new WaitForSeconds(.25f);

        isAttacking=false;
        GetComponent<Animator>().SetBool("isAttacking", false);

    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<character>() != null && !other.isTrigger && !other.CompareTag("Player"))
        {

            enemy = other.GetComponent<character>();

        }

    }

    public void OnTriggerExit2D(Collider2D other)
    {

        if (other.GetComponent<character>() != null && !other.isTrigger && !other.CompareTag("Player"))
        {

            enemy = null;

        }


    }


}
