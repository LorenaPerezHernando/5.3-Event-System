namespace Inventory
{
	public interface ISellable
	{
		#region Properties
		public float Price { get; set; }
		#endregion

		#region Public Methods
		public float Sell();
		#endregion
	}
}
