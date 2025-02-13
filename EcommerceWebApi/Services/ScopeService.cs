namespace EcommerceWebApi.Services
{
    public class ScopeService
    {
        public string value { get; set; }

        public ScopeService()
        {
            this.value = "ScopeService" + Guid.NewGuid(); ;
        }
    }
}
