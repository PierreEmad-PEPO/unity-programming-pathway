using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] animalsPrefabs;
    private int rangeX = 20;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnRandomAnimal", 2, 1.5f);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void SpawnRandomAnimal()
    {
        int idx = Random.Range(0, animalsPrefabs.Length);
        Vector3 pos = new Vector3(Random.Range(-rangeX, rangeX), 0, 30);
        Instantiate(animalsPrefabs[idx], pos, animalsPrefabs[idx].transform.rotation);
    }
}
