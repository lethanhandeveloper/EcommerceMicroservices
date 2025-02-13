namespace EcommerceWebApi.Services
{
    public class TransientService
    {
        public string value { get; set; }

        public TransientService()
        {
            this.value = "TransientService" + Guid.NewGuid(); ;
        }
    }
}
