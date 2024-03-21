using UnityEngine;
using UnityEngine.SceneManagement;

namespace RollingBall.Managers 
{
	public class LevelManager : MonoBehaviour
	{
		public void LoadGameplayScene() 
		{
			SceneManager.LoadScene("Gameplay");
		}
	}
}
