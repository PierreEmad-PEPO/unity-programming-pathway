using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerX2 : MonoBehaviour
{
    public GameObject dogPrefab;

    private float elapsedTime = 0f;
    private float totalTime = .5f;

    // Update is called once per frame
    void Update()
    {
        elapsedTime += Time.deltaTime;

        // On spacebar press, send dog
        if (elapsedTime >= totalTime && Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(dogPrefab, transform.position, dogPrefab.transform.rotation);
            elapsedTime = 0f;
        }
    }
}
