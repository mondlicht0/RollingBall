using UnityEngine;

namespace RollingBall.Balls 
{
	public class BallMovement : MonoBehaviour
	{
		[SerializeField] private float _speed;
		
		private void FixedUpdate()
		{
			Move();
		}

		private void Move()
		{
			transform.Translate(-Vector3.up * _speed * (GameManager.Instance.CurrentScore / 10) * Time.fixedDeltaTime);

			if (!GetComponent<Renderer>().isVisible)
			{
				Destroy(gameObject);
			}
		}
	}
}
