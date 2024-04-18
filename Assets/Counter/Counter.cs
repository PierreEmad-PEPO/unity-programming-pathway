using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class Counter : MonoBehaviour
{
    public Text CounterText;
    [SerializeField] GameObject spheresPrefab;
    [SerializeField] Sprite[] sprites;
    [SerializeField] Image img;

    private int Count = 0;

    private void Start()
    {
        Count = 0;
        InvokeRepeating("SpawnSpheres", 2, 2);
    }

    private void OnTriggerEnter(Collider other)
    {
        Count += 1;
        CounterText.text = "Count : " + Count;
        img.sprite = sprites[Math.Min(sprites.Length-1, Count/8)];
    }
    private void SpawnSpheres()
    {
        float x = Random.Range(-5, 5);
        Vector3 pos = spheresPrefab.transform.position;
        pos.z = x;
        Instantiate(spheresPrefab, pos, Quaternion.identity);
    }
}
