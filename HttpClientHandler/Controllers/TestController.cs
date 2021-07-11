using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml;

namespace WebApplication1.Controllers
{
    public class TestController : Controller
    {
        //private const string receiverParticipantUrl = "http://192.168.100.12:5002/BaseInsert";
        private const string receiverParticipantUrl = "http://59.152.61.37:35005/BaseInsert";
        [HttpPost("/BaseInsertUsingExistingHttpClient", Name = "BaseInsertUsingExistingHttpClient")]
        public string BaseInsertUsingExistingHttpClient([FromBody] string xmlData)
        {
            string responseFromReceivingParticipant = CommunicationService.CallParticipantFI(receiverParticipantUrl, xmlData);
            return responseFromReceivingParticipant;
        }

        [HttpPost("/BaseInsertUsingStaticHttpClient", Name = "BaseInsertUsingStaticHttpClient")]
        public async Task<string> BaseInsertUsingStaticHttpClient([FromBody] string xmlData)
        {
            CommunicationService communicationService = new CommunicationService();
            string responseFromReceivingParticipant = await communicationService.CallParticipantFIUsingStaticHttpClientInstance(receiverParticipantUrl, xmlData);
            return responseFromReceivingParticipant;
        }

        [HttpPost("/BaseInsertStaticHttpClientWithoutAsync", Name = "BaseInsertStaticHttpClientWithoutAsync")]
        public string BaseInsertStaticHttpClientWithoutAsync([FromBody] string xmlData)
        {
            string responseFromReceivingParticipant = CommunicationService.CallParticipantFIUsingStaticHttpClientWithoutAsync(receiverParticipantUrl, xmlData);
            return responseFromReceivingParticipant;
        }
               

        [HttpPost("/BaseInsertUsingHttpClientFactory", Name = "BaseInsertUsingHttpClientFactory")]
        public async Task<string> BaseInsertUsingHttpClientFactory([FromBody] string xmlData)
        {
            CommunicationService communicationService = new CommunicationService();
            string responseFromReceivingParticipant = await communicationService.CallBaseInsertUsingHttpClientFactory(receiverParticipantUrl, xmlData);
            return responseFromReceivingParticipant;
        }
    }
}
