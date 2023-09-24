namespace BindyStreet.Test.Responses
{
    public class GetUsersResponse
    {
        public List<object> messages { get; set; }
        public bool succeeded { get; set; }
        public List<UserData> data { get; set; }
        public object exception { get; set; }
        public int code { get; set; }
    }
}
