using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveForward : MonoBehaviour
{
    public float speed;

    private float topLimit = 30;
    private float bottomLimit = -5;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * speed);

        if (transform.position.z > topLimit)
        {
            Destroy(gameObject);
        }
        else if (transform.position.z < bottomLimit)
        {
            Debug.Log("Game Over !!");
            Destroy(gameObject);
        }
    }
}
