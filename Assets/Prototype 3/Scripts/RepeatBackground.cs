using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepeatBackground : MonoBehaviour
{
    private BoxCollider boxCollider;
    private Vector3 pos;

    // Start is called before the first frame update
    void Start()
    {
        boxCollider = GetComponent<BoxCollider>();
        pos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (pos.x - transform.position.x >= boxCollider.size.x /2)
        {
            transform.position = pos;
        }
    }
}
