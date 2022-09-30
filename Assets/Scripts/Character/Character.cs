using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : Actor
{
    #region Inspector

    [SerializeField]
    [Range(1f, 10f)]
    private float _xSpeed = 2f;

    #endregion

    #region  Fields

    private Rigidbody2D _rb;
    private CharacterInput _characterInput;
    private Animator _animator;

    #endregion

    #region Getters

    public float xSpeed => _xSpeed;

    public Rigidbody2D rb => _rb;
    public CharacterInput characterInput => _characterInput;
    public Animator animator => _animator;

    #endregion

    #region Mono

    protected override void Awake()
    {
        _characterInput = GetComponent<CharacterInput>();
        _rb = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();

        base.Awake();
    }

    #endregion
}
