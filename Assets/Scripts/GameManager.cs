using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

	[SerializeField] private GameObject menu;
	[SerializeField] private Text score;
	[SerializeField] private Text highscore;
	public static GameManager instance = null;
	private bool playerActive = false;
	private bool gameOver = true;

    [SerializeField] private AudioSource milestoneSound;

	private void Update()
	{
		score.text = "SCORE: " + PlayerController.score;
		highscore.text = "HIGHSCORE: " + PlayerPrefs.GetInt("highscore");

        if (PlayerController.score % 500 == 0 && PlayerController.score > 0)
        {
            milestoneSound.Play();
        }

	}

	public bool PlayerActive
	{
		get { return playerActive; }
	}

	public bool GameOver
	{
		get { return gameOver; }
	}

	public void ShowMenu()
	{
		menu.SetActive(true);
	}

	private void Awake()
	{
		if (instance == null)
		{
			instance = this;
		} else if (instance != this)
		{
			Destroy(gameObject);
		}

		DontDestroyOnLoad(gameObject);
	}

	public void PlayerCollided()
	{
		gameOver = true;
	}

	public void PlayerStarted()
	{
		playerActive = true;
	}

	public void EnterGame()
	{
		menu.SetActive(false);
		gameOver = false;
	}
}
