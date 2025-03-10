namespace Inventorys    
{

    public interface ISellables
    {

        #region Properties
        float Price { get; set; } 
        #endregion


        #region Private Methods
        public float Sell();
        #endregion
    }

}