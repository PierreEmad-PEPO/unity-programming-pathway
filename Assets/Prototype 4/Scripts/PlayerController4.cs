using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController4 : MonoBehaviour
{
    [SerializeField] GameObject focalPoint;
    [SerializeField] GameObject powerupIndicator;

    float verticalInput;
    float horizontalInput;
    float rotationSpeed = 60f;
    float movementSpeed = 180f;
    Rigidbody rb;
    bool hasPowerup = false;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");

        focalPoint.transform.Rotate(-Vector3.up * horizontalInput * rotationSpeed * Time.deltaTime);
        powerupIndicator.transform.position = transform.position + new Vector3(0, -0.95f, 0);
    }

    private void FixedUpdate()
    {
        rb.AddForce(focalPoint.transform.forward * verticalInput * movementSpeed * Time.deltaTime);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Powerup"))
        {
            hasPowerup = true;
            powerupIndicator.SetActive(true);
            Destroy(other.gameObject);
            StartCoroutine(PowerupCountdown());
        }
    }

    private IEnumerator PowerupCountdown() 
    {
        yield return new WaitForSeconds(7);
        hasPowerup = false;
        powerupIndicator.SetActive(false);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy") && hasPowerup)
        {
            Vector3 v = collision.transform.position - transform.position;
            collision.rigidbody.AddForce(v * 250f * Time.deltaTime, ForceMode.Impulse);
        }
    }
}
