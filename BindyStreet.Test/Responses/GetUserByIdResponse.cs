namespace BindyStreet.Test.Responses
{
    public class GetUserByIdResponse
    {
        public List<object> messages { get; set; }
        public bool succeeded { get; set; }
        public UserData data { get; set; }
        public object exception { get; set; }
        public int code { get; set; }
    }
    public class Address
    {
        public string street { get; set; }
        public string suite { get; set; }
        public string city { get; set; }
        public string zipCode { get; set; }
        public Geo geo { get; set; }
    }

    public class Company
    {
        public string name { get; set; }
        public string catchPhrase { get; set; }
        public string bs { get; set; }
    }

    public class UserData
    {
        public int id { get; set; }
        public string name { get; set; }
        public string username { get; set; }
        public string email { get; set; }
        public string phone { get; set; }
        public string website { get; set; }
        public Address address { get; set; }
        public Company company { get; set; }
    }

    public class Geo
    {
        public string lat { get; set; }
        public string lng { get; set; }
    }

}
