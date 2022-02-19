using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(BoxCollider2D))]

public class character : MonoBehaviour
{

    [HideInInspector]
    public Rigidbody2D rb2D;

    [HideInInspector]
    public Animator anim;

    [HideInInspector]
    public SpriteRenderer spriteRen;

    public void Start()
    {
        
        rb2D = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        spriteRen = GetComponent<SpriteRenderer>();

    }

}
