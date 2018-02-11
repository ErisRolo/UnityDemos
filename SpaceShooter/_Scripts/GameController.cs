using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameController : MonoBehaviour
{
    public GameObject hazard;
    public Vector3 spawnValues;
    public int hazardCount;
    public float spawnWait;
    public float startWait = 1.0f;
    public float waveWait = 2.0f;

    public Text scoreText;
    private int score;

    private Vector3 spawnPosition = Vector3.zero;
    private Quaternion spawnRotation;

    public Text gameOverText;
    private bool gameOver;

    public Text restartText;
    private bool restart;

    IEnumerator SpawnWaves()
    {
        yield return new WaitForSeconds(startWait);
        while (true)
        {
            if (gameOver)
            {
                restartText.text = "按R键重新开始";
                restart = true;
                break;
            }
            for (int i = 0; i < hazardCount; ++i)
            {
                spawnPosition.x = Random.Range(-spawnValues.x, spawnValues.x);
                spawnPosition.z = spawnValues.z;
                spawnRotation = Quaternion.identity;
                Instantiate(hazard, spawnPosition, spawnRotation);
                yield return new WaitForSeconds(spawnWait);
            }
            yield return new WaitForSeconds(waveWait);
        }
    }

    // Use this for initialization
    void Start ()
    {
        score = 0;
        UpdateScore();

        gameOverText.text = "";
        gameOver = false;

        restartText.text = "";
        restart = false;

        StartCoroutine(SpawnWaves());
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (restart)
        {
            if (Input.GetKeyDown(KeyCode.R))
                Application.LoadLevel(Application.loadedLevel);
        }
    }

    public void AddScore(int newScoreValue)
    {
        score += newScoreValue;
        UpdateScore();
    }

    void UpdateScore()
    {
        scoreText.text = "得分: " + score;
    }

    public void GameOver()
    {
        gameOver = true;
        gameOverText.text = "游戏结束";
    }
}
