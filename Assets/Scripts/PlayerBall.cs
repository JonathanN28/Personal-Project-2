using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerBall : MonoBehaviour
{
    [Header("Get")]
    public TextMeshProUGUI scoreText;
    private Rigidbody ballRb;
    public Transform servePosition;

    [Header("Set")]
    public float speed = 15f;
    public float maxSpeed = 5f;
    public float playerScore = 0f;
    public float enemyScore = 0f;
    public Vector3 serveOffset;
    public float fastBallDrag = 0.4f;
    public float slowBallDrag = 0.1f;

    public float serveRepeatDelay = 1f;
    void Start()
    {
        ballRb = GetComponent<Rigidbody>();
        Physics.gravity = new Vector3(0, Physics.gravity.y * 0.5f, 0);
    }
    void Update()
    {
        // Debug.Log(ballRb.velocity.magnitude);
        if (ballRb.velocity.magnitude > 4)
        {
            ballRb.drag = fastBallDrag;
        }
        else
        {
            ballRb.drag = slowBallDrag;
        }
        ballRb.velocity = Vector3.ClampMagnitude(ballRb.velocity, maxSpeed);
        if (Input.GetKeyDown(KeyCode.R))
        {
            serveBall();
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            if (Mathf.Sign(transform.position.z) == 1f)
            {
                playerWin();
            }
            else
            {
                enemyWin();
            }

            if (playerScore == 11f)
            {
                
            }
            else if (enemyScore == 11f)
            {
                
            }
        }
    }

    private void serveBall()
    {
        transform.position = servePosition.position;
        ballRb.velocity = Vector3.zero;
        ballRb.AddForce((serveOffset * speed) * Time.deltaTime, ForceMode.Impulse);
    }

    private void playerWin()
    {
        playerScore += 1f;
        scoreText.text = playerScore + " - " + enemyScore;
    }

    private void enemyWin()
    {
        enemyScore += 1f;
        scoreText.text = playerScore + " - " + enemyScore;
    }
}
