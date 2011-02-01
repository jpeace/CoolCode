namespace CoolCode.Web.Endpoints.Home.Index
{
    public class IndexEndpoint
    {
        public IndexViewModel Get(IndexRequestModel model)
        {
            return new IndexViewModel();
        }
    }
}