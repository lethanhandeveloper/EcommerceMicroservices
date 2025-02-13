namespace EcommerceWebApi.Services
{
    public class SingletonService
    {

        public string value {  get; set; }

        public SingletonService()
        {
            this.value = "SingletonService" + Guid.NewGuid(); ;
        }
    }
}
