using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Target : MonoBehaviour
{
    Rigidbody rb;
    int minSpeed = 8;
    int maxSpeed = 15;
    int xRange = 5;
    int torqueRange = 10;

    [SerializeField] int scoreProfit;
    [SerializeField] GameManager gameManager;
    [SerializeField] ParticleSystem explosionEffect;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        rb = GetComponent<Rigidbody>();
        rb.AddForce(Vector3.up * Random.Range(minSpeed, maxSpeed), ForceMode.Impulse);
        rb.AddTorque(Random.Range(-torqueRange, torqueRange), Random.Range(-torqueRange, torqueRange), Random.Range(-torqueRange, torqueRange), ForceMode.Impulse);
        transform.position = new Vector3(Random.Range(-xRange, xRange), 0);
    }

    private void OnMouseDown()
    {
        if (gameManager.isGameActive)
        {
            Destroy(gameObject);
            gameManager.UpdateScore(scoreProfit);
            Instantiate(explosionEffect, transform.position, explosionEffect.transform.rotation);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);

        if (!gameObject.CompareTag("Bad"))
            gameManager.GameOver();
    }
}
