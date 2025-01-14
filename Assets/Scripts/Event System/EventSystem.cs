using UnityEngine;
using System;

public class EventSystem : MonoBehaviour
{
	#region Properties
	#endregion

	#region Fields
	[SerializeField] private Points _points;
	[SerializeField] private Health _playerHealth;
	[SerializeField] private UIController _ui;
	[SerializeField] private SoundController _sound;
	#endregion

	#region Unity Callbacks
	void Start()
    {
		//Event Listener
		_playerHealth.OnGetDamage += OnGetDamage;
		_playerHealth.OnGetHeal += OnGetHeal;
		_playerHealth.OnDie += OnDie;
		_points.OnGetPoints += OnAddPoints;
	}

	#endregion

	#region Private Methods
	private void OnGetDamage()
	{
		_sound.PlayDamageSound();
		_ui.UpdateSliderLife(_playerHealth.CurrentHealth);
	}
	private void OnGetHeal()
	{
		_ui.UpdateSliderLife(_playerHealth.CurrentHealth);
	}
	private void OnDie()
	{
		_sound.PlayDieSound();
		Debug.Log("Player Died");
		Destroy(_playerHealth.gameObject);
	}
	private void OnAddPoints()
	{
		_ui.UpdatePoints(_points.CurrentPoints);
	}
	#endregion
}
