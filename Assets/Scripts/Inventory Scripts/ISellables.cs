namespace Inventorys
{

    public interface ISellables
    {

        #region Properties
        [field: SerializeField] public float Price { get; set; }
        #endregion


        #region Private Methods
        public float Sell();
        #endregion
    }

}