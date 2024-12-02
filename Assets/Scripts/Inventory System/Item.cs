using UnityEngine;
using System;

namespace Inventory
{
	[Serializable]
	public class Item
	{
		#region Properties
		[field: SerializeField] public string Name { get; set; }
		#endregion

	}
}
