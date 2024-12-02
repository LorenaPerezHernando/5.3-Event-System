using UnityEngine;
using System;

public class SoundController : MonoBehaviour
{
	#region Properties
	#endregion

	#region Fields
	[SerializeField] private AudioClip _damageSound;
	[SerializeField] private AudioClip _dieSound;
	private AudioSource _audioSource;
	#endregion

	#region Unity Callbacks
	// Start is called before the first frame update
	void Start()
    {
		_audioSource = GetComponent<AudioSource>();
	}
    
	#endregion

	#region Public Methods
	public void PlayDamageSound()
	{
		_audioSource.clip = _damageSound;
		_audioSource.Play();
	}
	public void PlayDieSound()
	{
		_audioSource.clip = _dieSound;
		_audioSource.Play();
	}
	#endregion

	#region Private Methods
	#endregion
}
