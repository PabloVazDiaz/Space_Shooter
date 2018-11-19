using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour {

    public GameObject[] hazards;
    public Vector3 spawnValues;
    public int hazardCount;
    public float spawnWait;
    public float starWait;
    public float waveWait;
    public Text scoreText;
    public Text RestartText;
    public Text GameOverText;
    private int Score;
    private bool gameOver;
    private bool restart;


    private void Start()
    {
        Score = 0;
        UpdateScore();
        StartCoroutine( SpawnWaves());
        gameOver=false;
        RestartText.text = "";
        GameOverText.text = "";
        restart = false;
    }

    private void Update()
    {
        if (restart)
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                Application.LoadLevel(Application.loadedLevel);
            }
        }
    }

    IEnumerator SpawnWaves()
    {
        yield return new WaitForSeconds(starWait);
        while (true) {
            for (int i = 0; i < hazardCount; i++) {
                GameObject hazard = hazards[Random.Range(0, hazards.Length)];
                Vector3 spawnPosition = new Vector3(Random.Range(-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
                Quaternion spawnRotation = Quaternion.identity;
                Instantiate(hazard, spawnPosition, spawnRotation);
                yield return new WaitForSeconds(spawnWait);
            }
            yield return new WaitForSeconds( waveWait);

            if (gameOver)
            {
                RestartText.text = " Presiona 'R' para volver a jugar";
                restart = true;
                break;
            }
        }
    }

    public void AddScore(int newScoreValue)
    {
        Score += newScoreValue;
        UpdateScore();
    }

    private void UpdateScore()
    {
        scoreText.text = "Score: " + Score;
    }

    public void GameOver()
    {
        GameOverText.text = "GAME OVER";
        gameOver = true;
    }
}
