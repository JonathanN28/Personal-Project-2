using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private CharacterController cController;

    public float speed = 5f;
    void Start()
    {
        cController = GetComponent<CharacterController>();
    }
    void Update()
    {
        Vector3 moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        // Unity answer solution for consistent speed in diagonal form
        moveDirection = Vector3.ClampMagnitude(moveDirection, 1f);
        cController.Move(moveDirection * Time.deltaTime * speed);
    }

    
}
