namespace E_commarceWebApi.RequestModel.ResponseModel
{
    public class DataResponseList<TModel> where TModel : class
    {
        public List<TModel> Data { get; set; }
        public string Status { get; set; }
        public string Message { get; set; }
    }
}
