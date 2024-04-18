using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] List<GameObject> objects = new List<GameObject>();
    [SerializeField] TextMeshProUGUI gameOverText;
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] TextMeshProUGUI titleText;
    [SerializeField] int score;

    public bool isGameActive = false;
    
    float spawnDelay = 3f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void UpdateScore(int scoreToAdd)
    {
        score += scoreToAdd;
        scoreText.text = "Score: " + score;
    }

    public void GameOver()
    {
        gameOverText.gameObject.SetActive(true);
        isGameActive = false;
    }

    IEnumerator SpawnObjects()
    {
        while (isGameActive) 
        {
            yield return new WaitForSeconds(spawnDelay);
            int idx = Random.Range(0, objects.Count);
            Instantiate(objects[idx]);
        }
    }

    public void StartGame(int difficulty)
    {
        spawnDelay /= difficulty;
        isGameActive = true;
        score = 0;
        StartCoroutine(SpawnObjects());
        titleText.gameObject.SetActive(false);
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
