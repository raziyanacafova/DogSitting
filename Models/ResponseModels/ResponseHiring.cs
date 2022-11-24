//namespace DogSitting_.Models.ResponseModels
//{
//    public class ResponseHiring
//    {
//    }
//}
namespace DogSitter.Models.ResponseModels
{
    public class ResponseHiring
    {
        public int HireId { get; set; }       //dun'no if it is necessary
        public int SitterId { get; set; }
        public int ClientId { get; set; }
        public int NumberOfDogs { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
    }
}
