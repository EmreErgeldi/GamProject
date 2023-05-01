using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public Transform target;
    private Vector3 offset;

    public float yawSpeed = 100f;
    
    void Start()
    {
        offset = target.position - transform.position;
    }

    private void Update()
    {
        if(Input.GetKey(KeyCode.Q))
        {
            transform.RotateAround(target.position, Vector3.up, -yawSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.E))
        {
            transform.RotateAround(target.position, Vector3.up, yawSpeed * Time.deltaTime);
        }

    }

    private void LateUpdate()
    {
        transform.position = target.position - offset;
    }
}
