using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxMovement : MonoBehaviour
{
    float horizontalInput;
    [SerializeField] float speed;
    Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
    }
    private void FixedUpdate()
    {
        transform.Translate(horizontalInput * speed * transform.forward);
        if (transform.position.z > 6.5)
            transform.position = new Vector3(transform.position.x, transform.position.y, 6.5f);
        if (transform.position.z < -6.5)
            transform.position = new Vector3(transform.position.x, transform.position.y, -6.5f);
    }
}
