
using DogSitter.DatabaseProvider;
using DogSitter.Models;
using DogSitter.Models.RequestModels;
using DogSitter.Models.ResponseModels;
using Microsoft.AspNetCore.Mvc;
using System.Globalization;

namespace DogSitter.Controllers
{
    [ApiController]
    [Route("DogSit")]
    public class SwaggerController : ControllerBase
    {
        [HttpPost]
        [Route("Add a Sitter")]
        public IActionResult AddSitter(RequestSitter sitter)
        {
            //Sitter newsitter=new Sitter();
            Services.CreateSitter(sitter);
            return StatusCode(StatusCodes.Status201Created);
        }
        [HttpPost]
        [Route("Create an Account")]
        public IActionResult AddClient(RequestClient client)
        {
            //Client newclient=new Client();
            Services.CreateClient(client);

            return StatusCode(StatusCodes.Status201Created);
        }
        [HttpPost]
        [Route("Hire a Sitter")]
        public IActionResult HireSitter(RequestHiring hiring) //(RequestClient client,int numofdogs,RequestSitter sitter)
        {
            
            int clientid = Services.GetClientId(hiring.Client);
            int sitterid = Services.GetSitterId(hiring.Sitter);
            ResponseHiring responsehiring = new ResponseHiring() { ClientId=clientid, SitterId=sitterid, NumberOfDogs=hiring.NumberOfDogs, StartTime=hiring.StartTime,EndTime=hiring.EndTime};
            //Firstly we check if there is a time overlap:
            //Services.CheckTimeOverlap(responsehiring.StartTime,resposehiring.EndTime,responsehiring.sitterid)
            int hiringid =Services.CreateHiring(responsehiring);
            responsehiring.HireId = hiringid;
            Services.CreateHiringDetails(responsehiring);
            return StatusCode(StatusCodes.Status200OK);
        }
        [HttpPost]
        [Route("Leave a Feedback")]
        public IActionResult AddFeedback(RequestFeedback requestfeedback)
        {
            int sitterid=Services.GetSitterId(requestfeedback.Sitter);
            int clientid = Services.GetClientId(requestfeedback.Client);
            //Logic to transform requestfeedback to a responsefeedback:
            ResponseFeedback responsefeedback = new ResponseFeedback() { ClientId = clientid,SitterId=sitterid,Feedback=requestfeedback.Feedback };

            Services.CreateFeedback(responsefeedback);

            return StatusCode(StatusCodes.Status201Created);
        }
        [HttpGet]
        [Route("See List of Sitters")]
        public List<SitterDisplay> GetSitters()
        {
            return Services.GetSitters();
        }
        /*[HttpDelete]
        [Route("Delete a Sitter")]
        public IActionResult DeleteSitter(RequestSitter sitter)
        {
            //don't know how to handle it
            return StatusCode(StatusCodes.Status200OK);
        }
        */

    }
}