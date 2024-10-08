using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class CharacterController3D : MonoBehaviour
{
    private Rigidbody myRB;                  
    [SerializeField] private float speed;    
    private Vector2 movement;                

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
    }
    public void ApplyPhysics()
    {
        Vector3 move = new Vector3(movement.x, myRB.velocity.y, movement.y) * speed;
        myRB.velocity = move;
    }

    private void FixedUpdate()
    {
        ApplyPhysics();
    }
}