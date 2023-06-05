using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRacket : MonoBehaviour
{
    public GameObject playerBall;
    public GameObject enemyTarget;
    public bool hit;
    public Vector3 trajectory;
    private Rigidbody ballRb;
    // Start is called before the first frame update
    void Start()
    {
        ballRb = playerBall.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionStay(Collision other)
    {
        if (other.gameObject.CompareTag("Ball"))
        {
            hit = true;
            
        }
    }

    private void OnCollisionExit(Collision other)
    {
        if (other.gameObject.CompareTag("Ball"))
        {
            hit = false;
        }
    }

    private void CalculateTrajectory()
    {
        Vector3 distance = transform.position - enemyTarget.transform.position;
    }
}
