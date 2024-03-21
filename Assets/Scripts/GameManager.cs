using System;
using DG.Tweening;
using RollingBall.Managers;
using UnityEngine;

[DefaultExecutionOrder(-1)]
public class GameManager : MonoBehaviour
{
	public static GameManager Instance { get; private set; }
	
	public float CurrentScore { get; private set; }
	public float HighScore { get; private set; }
	
	public bool IsGameOver { get; private set; } = false;
	
	[SerializeField] private UIManager _uiManager;
	
	[SerializeField] private PlayerMovement _player;
	
	public Action OnStartGame;
	public Action OnGameOver;
	
	private void OnEnable()
	{
		_player.OnDead += GameOver;
	}
	
	private void OnDisable()
	{
		_player.OnDead -= GameOver;
	}
	
	private void Start()
	{
		Time.timeScale = 0f;
		HighScore = PlayerPrefs.GetFloat("HighScore", 0);
		
		Debug.Log(HighScore);
	}
	
	public void StartGame() 
	{
		OnStartGame?.Invoke();
		
		Time.timeScale = 1f;
	}
	
	private void Update()
	{
		if (!IsGameOver) 
		{
			CurrentScore += Time.deltaTime * 1f;
			if (CurrentScore > HighScore)
			{
				HighScore = CurrentScore;
				PlayerPrefs.SetFloat("HighScore", HighScore);
			}
		}
	}
	
	private void Awake()
	{
		if (Instance == null)
		{
			Instance = this;
		}

		else
		{
			Destroy(Instance);
			Instance = this;
		}
	}
	
	private void GameOver() 
	{
		OnGameOver?.Invoke();
		
		IsGameOver = true;
	}
	
}
