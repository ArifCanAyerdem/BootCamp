using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipMovement : MonoBehaviour
{
    private Rigidbody rb;
    [SerializeField] private float motorPower;
    [SerializeField] private float torquePower;
    private float inputVertical, inputHorizontal;

    
    [SerializeField]private float torqueDragValue;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }
    
    void Update()
    {
        inputVertical = Input.GetAxis("Vertical");
        inputHorizontal = Input.GetAxis("Horizontal");
    }
    private void FixedUpdate()
    {
        rb.velocity = transform.forward * inputVertical * motorPower;
        rb.AddTorque(transform.up * inputHorizontal * torquePower);
        rb.angularVelocity /= torqueDragValue;
        
       
    }
}
