//namespace DogSitting_.Models.ResponseModels
//{
//    public class ResponseFeedback
//    {
//    }
//}
namespace DogSitter.Models.ResponseModels
{
    public class ResponseFeedback
    {
        public int ClientId { get; set; }
        public int SitterId { get; set; }
        public string Feedback { get; set; }
    }
}
