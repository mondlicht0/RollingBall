using UnityEngine;
using UnityEngine.SceneManagement;

namespace RollingBall.Managers 
{
	public class LevelManager : MonoBehaviour
    {
        public void Home() 
        {
            SceneManager.LoadScene(1);
        }
        
        public void Retry() 
        {
            SceneManager.LoadScene(1);
        }
    }
}
