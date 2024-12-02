using UnityEngine;
using System;

public class EventSystem : MonoBehaviour
{
	#region Properties
	#endregion

	#region Fields
	[SerializeField] private Points _points;
	[SerializeField] private Health _payerHealth;
	[SerializeField] private UIController _ui;
	[SerializeField] private SoundController _sound;
	#endregion

	#region Unity Callbacks
	// Start is called before the first frame update
	void Start()
    {
		//Event Listener
		_payerHealth.OnGetDamage += OnGetDamage;
		_payerHealth.OnGetHeal += OnGetHeal;
		_payerHealth.OnDie += OnDie;
		_points.OnGetPoints += OnAddPoints;
	}

	#endregion

	#region Private Methods
	private void OnGetDamage()
	{
		_sound.PlayDamageSound();
		_ui.UpdateSliderLife(_payerHealth.CurrentHealth);
	}
	private void OnGetHeal()
	{
		_ui.UpdateSliderLife(_payerHealth.CurrentHealth);
	}
	private void OnDie()
	{
		_sound.PlayDieSound();
		Destroy(_payerHealth.gameObject);
	}
	private void OnAddPoints()
	{
		_ui.UpdatePoints(_points.CurrentPoints);
	}
	#endregion
}
