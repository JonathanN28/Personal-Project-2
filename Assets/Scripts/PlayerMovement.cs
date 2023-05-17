using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerMovement : MonoBehaviour
{
    [Header("Get")]
    public GameObject racket;
    private RacketFollowPlayer racketFollowPlayer;
    private PlayerRacket playerRacket;
    private CharacterController cController;
    
    [Header("Set")]
    public float speed = 5f;

    
    
    void Start()
    {
        cController = GetComponent<CharacterController>();
        playerRacket = GetComponent<PlayerRacket>();
        racketFollowPlayer = racket.GetComponent<RacketFollowPlayer>();
    }
    void Update()
    {
        Vector3 moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        // Unity answer solution for consistent speed in diagonal form
        moveDirection = Vector3.ClampMagnitude(moveDirection, 1f);
        cController.Move(moveDirection * Time.deltaTime * speed);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            playerRacket.flipRacket();
        }
        else if (Input.GetMouseButton(0))
        {
            racketFollowPlayer.ExtendRacket();
        }
        else if (Input.GetMouseButton(1))
        {
            racketFollowPlayer.RetractRacket();
        }
    }


}
