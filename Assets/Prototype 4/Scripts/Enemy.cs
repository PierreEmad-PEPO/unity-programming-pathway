using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    float speed = 120f;
    Rigidbody rb;
    GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 v = player.transform.position - transform.position;
        rb.AddForce(v.normalized * speed * Time.deltaTime);

        if (transform.position.y < -10)
        {
            Destroy(gameObject);
            EnemySpawner.enemiesNumber--;
        }
    }
}
