using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Inventorys
{

    [Serializable]
    public class Weapons : Items, IUsables
    {

        #region Properties
        [field: SerializeField] public float Damage { get; set; }
        #endregion

        #region Fields
        #endregion

        #region Public Methods
        public void Attack()
        {
            Debug.Log("Do Atack..");
        }

        public void Use()
        {
            Attack();
        }
        #endregion

        #region Private Methods

        #endregion
    }

}