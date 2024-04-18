using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    private float horizontalInput;
    private float verticalInput;
    private float turnSpeed = 60f;
    private Rigidbody rb;
    [SerializeField] float moveSpeed;
    [SerializeField] GameObject centerOfMass;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.centerOfMass = centerOfMass.transform.position;
        rb.AddForce(transform.forward * 400000);
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void FixedUpdate()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");
        rb.AddRelativeForce(Vector3.forward * moveSpeed * verticalInput);
        transform.Rotate(Vector3.up * Time.deltaTime * turnSpeed * horizontalInput);
    }
}
