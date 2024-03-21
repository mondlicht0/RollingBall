using System.Collections.Generic;
using RollingBall.Balls;
using UnityEngine;

namespace RollingBall.Managers 
{
	public class EnemySpawner : MonoBehaviour
	{
		[SerializeField] private List<BallMovement> _ballPrefabs;
		
		[Header("Points")]
		[SerializeField] private Transform _startPoint;
		[SerializeField] private Transform _endPoint;
		
		[Header("Range")]
		[SerializeField, Range(0, 1)] private float _spawnWidthRange;
		[SerializeField, Range(0, 1)] private float _spawnHeightRange;
		
		[SerializeField] private float _spawnInterval = 1f;
		[SerializeField] private float _spawnRadius = 2f;
		
		private float _timer;
		
		private void Update()
		{
			_timer += Time.deltaTime;

			if (_timer >= _spawnInterval)
			{
				SpawnBall();
				_timer = 0f;
				_spawnInterval /= 1.01f;
			}
			
		}
		
		private void SpawnBall()
		{
			Vector3 spawnPosition = GetRandomPointOnRoad();
			Instantiate(_ballPrefabs[Random.Range(0, _ballPrefabs.Count)], spawnPosition, Quaternion.identity);
		}
		
		private Vector3 GetRandomPointOnRoad()
		{
			Vector2 startPos = _startPoint.position;
			Vector2 endPos = _endPoint.position;

			Vector2 randomPoint = Vector2.Lerp(startPos, endPos, Random.Range(0f, 1f));
			randomPoint += Random.insideUnitCircle * _spawnRadius;

			return randomPoint;
		}
	}
}
