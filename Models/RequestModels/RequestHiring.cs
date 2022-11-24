//namespace DogSitting_.Models.RequestModels
//{
//    public class RequestHiring
//    {
//    }
//}
namespace DogSitter.Models.RequestModels
{
    public class RequestHiring
    {
        public RequestClient Client { get; set; }
        public RequestSitter Sitter { get; set; }
        public int NumberOfDogs { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
    }
}
