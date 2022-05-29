using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float MoveSpeed = 3f;
    Vector2 moveInput;
    Rigidbody2D _rigidbody2D;
    Animator _animator;
    void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
    }

    void Update()
    {
        Move();
        FlipSprite();
    }

    void OnMove(InputValue value)
    {
        moveInput = value.Get<Vector2>();
        Debug.Log(moveInput);
    }

    void Move()
    {
        _rigidbody2D.velocity = moveInput * MoveSpeed;

        bool hasHorizontalSpeed = Mathf.Abs(_rigidbody2D.velocity.x) > Mathf.Epsilon;
        _animator.SetBool("IsMoving", hasHorizontalSpeed);
    }


    void FlipSprite()
    {
        bool hasHorizontalSpeed = Mathf.Abs(_rigidbody2D.velocity.x) > Mathf.Epsilon;

        if (hasHorizontalSpeed)
        {
            transform.localScale = new Vector2(Mathf.Sign(_rigidbody2D.velocity.x), 1f);
        }

    }
}
