namespace E_commarceWebApi.RequestModel.ResponseModel
{
    public class DataResponse<TModel> where TModel : class
    {
        public TModel Data { get; set; }
        public string Status { get; set; }
        public string Message { get; set; }
    }
}
