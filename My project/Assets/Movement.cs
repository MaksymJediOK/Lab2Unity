using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Movement : MonoBehaviour
{
    // Start is called before the first frame update
    public float movementSpeed = 8f;
    public float jumpHeight = 10f;

    CapsuleCollider2D capsuleCollider;
    Vector2 movementVector;
    Rigidbody2D rigidbody;
    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        capsuleCollider = GetComponent<CapsuleCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
        Vector2 playerVelocity = new Vector2(movementVector.x * movementSpeed, rigidbody.velocity.y);
        rigidbody.velocity = playerVelocity;
    }

    private void OnMove(InputValue value)
    { 
        movementVector = value.Get<Vector2>();
    }

    private void OnJump(InputValue value)
    {
        if (!capsuleCollider.IsTouchingLayers(LayerMask.GetMask("Ground"))) return;
        if(value.isPressed)
        {
            rigidbody.velocity += new Vector2(0f, jumpHeight);
        }
    }
}
