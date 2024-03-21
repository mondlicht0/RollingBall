using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;
using UnityEngine.UI;

namespace RollingBall.Managers
{
	public class LoadScreen : MonoBehaviour
	{
		[SerializeField] private GameObject _loadScreen;
		[SerializeField] private Image _loadingIcon;
		
		private void Start()
		{
			Loading("Gameplay");
		}

		public void Loading(string sceneName)
		{
			StartCoroutine(LoadAsync(sceneName));
		}

		private IEnumerator LoadAsync(string sceneName)
		{
			Time.timeScale = 1f;
			AsyncOperation loadOperation = SceneManager.LoadSceneAsync(sceneName);
			loadOperation.allowSceneActivation = false;

			while (!loadOperation.isDone)
			{
				_loadingIcon.transform.DORotate(new Vector3(0, 0, 270f), 5f);

				if (loadOperation.progress >= 0.9f && !loadOperation.allowSceneActivation)
				{
					yield return new WaitForSeconds(0.5f);
					loadOperation.allowSceneActivation = true;
				}

				yield return null;
			}
		}
	}
}
