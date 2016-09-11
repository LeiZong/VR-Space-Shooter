using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameController : MonoBehaviour {
	public GameObject hazard;
	public Vector3 spawnValues;
	public float hazardCount;
	public float spawnWait;
	public float startWait;
	public float waveWait;

	public Text scoreText;
//	public GUIText scoreText;
//	public GUIText restartText;
//	public GUIText gameOverText;

	private int score;
	private bool restart;
	private bool gameOver;

	void Start () {
		StartCoroutine (SpawnWaves ());
		score = 0;
		UpdateScore ();
		gameOver = false;
		restart = false;
		scoreText.text = "Score: " + score;
//		restartText.text = "";
//		gameOverText.text = "";
	}

	void Update () {
		if (restart) {
			if (Input.GetButton ("Fire1")) {
				Application.LoadLevel (Application.loadedLevel);
			}
		}
	}

	IEnumerator SpawnWaves () {
		yield return new WaitForSeconds (startWait);
		while (true) {
			for (int i = 0; i < hazardCount; i++) {
				Vector3 spawnPosition = new Vector3 (Random.Range (-spawnValues.x, spawnValues.x), Random.Range (-spawnValues.y, spawnValues.y), spawnValues.z);
				Quaternion spawnRotation = Quaternion.identity;
				Instantiate (hazard, spawnPosition, spawnRotation);
				yield return new WaitForSeconds (spawnWait);
			}
			yield return new WaitForSeconds (waveWait);

			if (gameOver) {
//				restartText.text = "Press 'R' for Restart";
				restart = true;
				break;
			}
		}
	}

	public void AddScore (int newScoreValue) {
		score += newScoreValue;
		UpdateScore ();
	}

	void UpdateScore () {
		scoreText.text = "Score: " + score;
	}

	public void GameOver () {
//		gameOverText.text = "Game Over!";
		gameOver = true;
	}
}
