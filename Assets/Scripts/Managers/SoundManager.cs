using UnityEngine;

namespace RollingBall.Managers 
{
	public class SoundManager : MonoBehaviour
	{
		[SerializeField] private AudioSource _musicSource;
		[SerializeField] private AudioSource _soundSource;
		
		[Header("Music Icons")]
		[SerializeField] private GameObject _musicOn;
		[SerializeField] private GameObject _musicOff;
		
		[Header("Sound Icons")]
		[SerializeField] private GameObject _soundOn;
		[SerializeField] private GameObject _soundOff;
		
		
		public void SwitchMusic() 
		{
			_musicOn.gameObject.SetActive(!_musicOn.gameObject.activeSelf);
			_musicOff.gameObject.SetActive(!_musicOff.gameObject.activeSelf);

			_musicSource.volume = _musicOn.gameObject.activeSelf ? 1 : 0;
		}
		
		public void SwitchSound() 
		{
			_soundOn.gameObject.SetActive(!_soundOn.gameObject.activeSelf);
			_soundOff.gameObject.SetActive(!_soundOff.gameObject.activeSelf);

			_soundSource.volume = _soundOn.gameObject.activeSelf ? 1 : 0;
		}
		
		public void PlaySfx(AudioClip sound) 
		{
			_soundSource.PlayOneShot(sound);
		}
	}
}
