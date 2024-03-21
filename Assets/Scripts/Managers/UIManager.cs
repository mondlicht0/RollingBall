using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using TMPro;
using UnityEngine;

namespace RollingBall.Managers 
{
	public class UIManager : MonoBehaviour
	{
		[Header("Main Menu")]
		[SerializeField] private GameObject _gameMenu;
		[SerializeField] private TextMeshProUGUI _highScore;
		
		[Header("Gameplay")]
		[SerializeField] private CanvasGroup _gameOver;
		[SerializeField] private GameObject _gameplayUI;
		
		
		[Header("Pause")]
		[SerializeField] private GameObject _pauseMenu;
		

		[Header("Score")]
		[SerializeField] private TextMeshProUGUI _scoreText;
		[SerializeField] private TextMeshProUGUI _recordText;
		[SerializeField] private TextMeshProUGUI _totalScore;
		
		
		private void OnEnable()
		{
			GameManager.Instance.OnGameOver += ShowGameOverScreen;
			GameManager.Instance.OnStartGame += HideGameMenu;
		}
		
		private void OnDisable()
		{
			GameManager.Instance.OnGameOver -= ShowGameOverScreen;
			GameManager.Instance.OnStartGame -= HideGameMenu;
		}
		
		private void Start()
		{
			_highScore.text = GameManager.Instance.HighScore.ToString("F1");
		}
		
		private void Update()
		{
			_scoreText.text = GameManager.Instance.CurrentScore.ToString("F1");
		}
		
		private void ShowGameOverScreen() 
		{
			_gameOver.DOFade(1, 1f).OnComplete(() => 
			{
				Time.timeScale = 0f;
			});
			
			_recordText.text = "Record: " + GameManager.Instance.HighScore.ToString("F1");
			_totalScore.text = GameManager.Instance.CurrentScore.ToString("F1");
		}
		
		private void HideGameMenu() 
		{
			_gameMenu.SetActive(false);
			_gameplayUI.SetActive(true);
		}
		
		public void TogglePauseMenu() 
		{
			_pauseMenu.SetActive(!_pauseMenu.activeSelf);
			Time.timeScale = _pauseMenu.activeSelf ? 0 : 1;
		}
	}
}
