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
        public event Action OnClick;
        public Items CurrentItem
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
            _button.onClick.AddListener(() => OnClick?.Invoke());    
        }

        #endregion

     
    }

}