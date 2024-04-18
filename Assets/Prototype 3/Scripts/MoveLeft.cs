using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeft : MonoBehaviour
{
    private float speed = 17f;
    private float leftBoundry = -7f;
    private PlayerControl3 playerControl;

    // Start is called before the first frame update
    void Start()
    {
        playerControl = GameObject.Find("Player").GetComponent<PlayerControl3>();
    }

    // Update is called once per frame
    void Update()
    {
        if (playerControl.isGameOver) return;

        transform.Translate(speed * Time.deltaTime * Vector3.left);

        if (transform.position.x <= leftBoundry && gameObject.CompareTag("Obstacle")) 
        {
            Destroy(gameObject);
        }
    }
}
