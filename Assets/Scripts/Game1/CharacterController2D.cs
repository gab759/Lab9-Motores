using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CharacterController2D : MonoBehaviour
{
    Rigidbody2D _compRigidbody2D;
    [SerializeField] float speed;

    private void Awake()
    {
        _compRigidbody2D = GetComponent<Rigidbody2D>();
    }
    public void OnMovement(InputAction.CallbackContext contex)
    {
        Vector2 movementPlayer = contex.ReadValue<Vector2>();
        _compRigidbody2D.velocity = movementPlayer * speed;
    }
}
