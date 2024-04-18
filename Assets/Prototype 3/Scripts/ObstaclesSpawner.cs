using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstaclesSpawner : MonoBehaviour
{
    public GameObject obstaclePrefabe;

    private PlayerControl3 playerControl;

    

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnObstacle", 1f, 1.7f);
        playerControl = GameObject.Find("Player").GetComponent<PlayerControl3>();
    }

    void SpawnObstacle()
    {
        if (playerControl.isGameOver) return;

        Instantiate(obstaclePrefabe);
    }
}
