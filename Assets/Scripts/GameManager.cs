using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class GameManager : MonoBehaviour
{
    // Ajouter une list de prefabs pour la remplir avec les gameobjets
    public List<GameObject> targets;
    // Temps en seconde du spawn des prefabs
    private float spawnRate = 1.0f;

    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI gameOverText;
    public Button restartButton;
    public GameObject titleObject;

    private int score;
    public bool isGameActive;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    { 
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void UpdateScore(int scoreToAdd)
    {
        score += scoreToAdd;
        scoreText.text = "Score : " + score;
    }
    public void GameOver()
    {
        isGameActive = false;
        gameOverText.gameObject.SetActive(true);
        restartButton.gameObject.SetActive(true);
    }
    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void StartGame(int difficulty)
    {
        spawnRate = spawnRate / difficulty;
        
        titleObject.SetActive(false);
        // Lance la coroutine
        isGameActive = true;
        score = 0;

        StartCoroutine(SpawnTarget());
        UpdateScore(0);
    }
    IEnumerator SpawnTarget()
    {
        // Attends spawnRate seconde 
        while (isGameActive)
        {
            yield return new WaitForSeconds(spawnRate);
            // CHoisit un index aléatoire entre 0 et le nombre max de préfab dans la list
            int index = Random.Range(0, targets.Count);
            // SPawn
            Instantiate(targets[index]);
        }
    }
}
