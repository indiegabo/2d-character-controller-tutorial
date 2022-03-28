using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    [SerializeField][Range(1f, 10f)] private float _speed = 2f;
    private Rigidbody2D _rb;
    private CharacterInput _characterInput;
    private Animator _animator;

    private void Awake()
    {
        _characterInput = GetComponent<CharacterInput>();
        _rb = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
    }

    private void FixedUpdate()
    {
        Vector2 movement = new Vector2(_characterInput.movement.x * _speed, _rb.velocity.y);
        _rb.velocity = movement;

        if (Mathf.Abs(_rb.velocity.x) > 0)
        {
            _animator.SetBool("Running", true);
        }
        else
        {
            _animator.SetBool("Running", false);
        }
    }
}
