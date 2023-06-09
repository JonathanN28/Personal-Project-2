using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRacket : MonoBehaviour
{
    public GameObject rbEnemyRacket;
    public Animator npcAnim;
    public GameObject playerBall;
    public GameObject enemyTarget;
    private float speed = 200f;
    private Vector3 theAngle;
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

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Ball"))
        {
            //ballRb.AddForce(theAngle * Time.deltaTime * speed, ForceMode.Impulse);
            
            // Turn off the racket's collider
            rbEnemyRacket.GetComponent<Collider>().enabled = false;
            // Turn back on after 2 seconds
            Invoke("TurnOnCollider", 2f);
        }
    }
    private void TurnOnCollider()
    {
        rbEnemyRacket.GetComponent<Collider>().enabled = true;
    }
    
}
