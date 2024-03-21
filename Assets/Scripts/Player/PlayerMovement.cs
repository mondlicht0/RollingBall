using System;
using UnityEngine;

public class PlayerMovement : MonoBehaviour 
{
	[SerializeField] private float _speed;
	[SerializeField] private Rigidbody2D _rb;
	
	private Controls _controls;
	private float _moveInput;
	
	public Action OnDead;
	
	private void OnEnable()
	{
		_controls.Enable();
	}
	
	private void OnDisable()
	{
		_controls.Disable();
	}
	
	private void Awake()
	{
		_controls = new Controls();
		
		_rb = GetComponent<Rigidbody2D>();
	}
	
	private void Update() 
	{
		_moveInput = _controls.Player.Move.ReadValue<float>();
	}
	
	private void FixedUpdate()
	{
		MovePlayer();
	}
	
	private void MovePlayer()
	{
		Vector2 movement = new Vector2(_moveInput, 0f);
		
		_rb.MovePosition(_rb.position + movement * _speed * Time.deltaTime);
	}
	
	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.CompareTag("Enemy") && !GameManager.Instance.IsGameOver) 
		{
			OnDead?.Invoke();
		}
	}
}
