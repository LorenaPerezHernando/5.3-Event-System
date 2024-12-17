using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Inventorys
{

    [Serializable] //Mientra el contenido de los Items
    public class Items
    {

        #region Properties
        [field: SerializeField] public string Name { get; set; }
        #endregion

    }

}