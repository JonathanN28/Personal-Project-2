using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RacketFollowPlayer : MonoBehaviour
{
    public Transform playerHead;
    private Vector3 zeroVector = Vector3.zero;
    public Vector3 offset;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void LateUpdate()
    {
        FollowPlayer();
    }
    private void FollowPlayer()
    {
        // Slerp not applicable to this case because lag. Also ref zeroVector because Unity documentation told to do this
        transform.position = Vector3.SmoothDamp(transform.position,
            playerHead.transform.position + offset, ref zeroVector, 0.1f);
    }
    
}
