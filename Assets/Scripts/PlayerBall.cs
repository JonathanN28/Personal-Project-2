using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBall : MonoBehaviour
{
    public GameObject ball;
    private Rigidbody ballRb;
    
    public float speed = 15f;
    public Transform servePosition;
    public Vector3 serveOffset;

    public float serveRepeatDelay = 1f;
    void Start()
    {
        ballRb = ball.GetComponent<Rigidbody>();
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            serveBall();
        }
    }

    private void serveBall()
    {
        ball.transform.position = servePosition.position;
        ballRb.velocity = Vector3.zero;
        ballRb.AddForce((serveOffset * speed) * Time.deltaTime, ForceMode.Impulse);
    }
}
