using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class CharacterController3D : MonoBehaviour
{
    private Rigidbody myRB;                   
    [SerializeField] private float speed;     
    [SerializeField] private float jumpForce; 
    private Vector2 movement;                 
    private bool isJumping = false;           

    private void Awake()
    {
        myRB = GetComponent<Rigidbody>();
    }
    public void OnMovement(InputAction.CallbackContext context)
    {
        movement = context.ReadValue<Vector2>();
    }
    public void OnJump(InputAction.CallbackContext context)
    {
        if (context.performed && IsGrounded())
        {
            isJumping = true;  
        }
    }
    private bool IsGrounded()
    {
        return Physics.Raycast(transform.position, Vector3.down, 1.5f);
    }
    public void ApplyPhysics()
    {
        Vector3 move = new Vector3(movement.x, myRB.velocity.y, movement.y) * speed;
        myRB.velocity = new Vector3(move.x, myRB.velocity.y, move.z);

        if (isJumping)
        {
            myRB.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isJumping = false;
        }
    }
    private void FixedUpdate()
    {
        ApplyPhysics(); 
    }
}