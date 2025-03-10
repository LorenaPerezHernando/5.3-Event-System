using Inventorys;
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
namespace Inventorys
{

    public class ItemButtons : MonoBehaviour
    {

        #region Properties
        public Items CurrentItem
        {
            get
            {
                return _currentItem;
            }
            set
            {
                _currentItem = value;
                if (_currentItem != null &&_currentItem.Name != null)
                {
                    _buttonText.text = _currentItem.Name;
                }
                else
                {
                    Debug.LogError("Se intentó asignar un CurrentItem null en un botón.");
                }
                
            }
        }

        public event Action OnClick;

        #endregion

        #region Fields
        [SerializeField] private TextMeshProUGUI _buttonText;
        [SerializeField] private Button _button;
        [SerializeField] private Items _currentItem;
        #endregion

        #region Unity Callbacks

        void Awake()
        {
            _button = GetComponent<Button>();
            _buttonText = GetComponentInChildren<TextMeshProUGUI>();
            _button.onClick.AddListener(() => OnClick?.Invoke());    //Delegate Example
        }

        #endregion

     
    }

}