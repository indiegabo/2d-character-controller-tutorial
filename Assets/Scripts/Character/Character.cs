using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : Actor
{
    [SerializeField]
    public float speed { get; protected set; } = 2f;

    public Rigidbody2D rb { get; protected set; }
    public CharacterInput characterInput { get; protected set; }
    public Animator animator { get; protected set; }

    protected override void Awake()
    {
        characterInput = GetComponent<CharacterInput>();
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        base.Awake();
    }
}
