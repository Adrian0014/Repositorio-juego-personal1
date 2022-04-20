using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed = 5f;
    public float jumpForce = 10f;
    public bool isGrounded;
    float dirx;
    public SpriteRenderer renderer;
    Rigidbody2D _rBody;
    public Animator _animator;


    void Awake()
    {
        _rBody = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
    }

    void Update()
    {
        dirx = Input.GetAxisRaw("Horizontal");
        Debug.Log(dirx);
        if(dirx == -1)
        {
            renderer.flipX = true;
            _animator.SetBool("Run", true);
        }

        else if(dirx == 1)
        {
            renderer.flipX = false;
            _animator.SetBool("Run", true);
        }
        
        else
        {
            _animator.SetBool("Run", false);
        }


        if(Input.GetButtonDown("Jump") && isGrounded)
        {
            _rBody.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            _animator.SetBool("Jumping",true);
        }
    }

    void FixedUpdate()
    {
        _rBody.velocity = new Vector2(dirx * speed, _rBody.velocity.y);
    }

}

