using UnityEngine;
using System;
using UnityEngine.UI;
using TMPro;
namespace Inventory
{


	public class ItemButtom : MonoBehaviour
	{
		#region Properties
		public Item CurrentItem
		{
			get
			{
				return _currentItem;
			}
			set
			{
				_currentItem = value;
				_buttonText.text = _currentItem.Name;
			}
		}
		public event Action OnClick;

		#endregion

		#region Fields
		private TextMeshProUGUI _buttonText;
		private Button _button;
		private Item _currentItem;
		#endregion

		#region Unity Callbacks
		// Start is called before the first frame update
		void Awake()
		{
			_button = GetComponent<Button>();
			_buttonText = GetComponentInChildren<TextMeshProUGUI>();
			//Delegate example
			_button.onClick.AddListener(() => OnClick?.Invoke());
		}

		#endregion

	}

}