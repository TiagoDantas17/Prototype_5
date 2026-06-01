using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManagerX : MonoBehaviour
{
    public List<GameObject> targets;

    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI gameOverText;

    public GameObject restartButton;
    public GameObject titleScreen;

    public bool isGameActive;

    private int score;
    private float spawnRate = 1.0f;

    void Start()
    {
        isGameActive = false;

        score = 0;
        UpdateScore(0);

        gameOverText.gameObject.SetActive(false);
        restartButton.SetActive(false);
    }

    public void StartGame(int difficulty)
    {
        isGameActive = true;

        score = 0;
        UpdateScore(0);

        spawnRate = 1.0f / difficulty;

        titleScreen.SetActive(false);
        gameOverText.gameObject.SetActive(false);
        restartButton.SetActive(false);

        StartCoroutine(SpawnTarget());
    }

    IEnumerator SpawnTarget()
    {
        while (isGameActive)
        {
            yield return new WaitForSeconds(spawnRate);

            int index = Random.Range(0, targets.Count);
            Instantiate(targets[index]);
        }
    }

    public void UpdateScore(int scoreToAdd)
    {
        score += scoreToAdd;
        scoreText.text = "Score: " + score;
    }

    public void GameOver()
    {
        isGameActive = false;

        gameOverText.gameObject.SetActive(true);
        restartButton.SetActive(true);
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
