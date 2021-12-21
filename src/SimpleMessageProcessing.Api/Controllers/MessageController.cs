using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SimpleMessageProcessing.Library.Abstractions;
using SimpleMessageProcessing.Library.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleMessageProcessing.Api.Controllers {
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class MessageController : ControllerBase {
        private readonly ISimpleMessageProcess _simpleMessageProcess;

        public MessageController(ISimpleMessageProcess simpleMessageProcess)
        {
            _simpleMessageProcess = simpleMessageProcess;
        }

        [HttpPost]
        public async Task<IActionResult> ProcessMessage()
        {
            // Get plain request body and to be parse later
            var request = HttpContext.Request;
            var stream = new StreamReader(request.Body);
            var requestBody = await stream.ReadToEndAsync();

            if (requestBody.IsNullOrWhiteSpace())
            {
                return BadRequest("Request cannot be empty!");
            }

            var result = await _simpleMessageProcess.ProcessMessage(requestBody);

            if (!result)
            {
                return BadRequest("Invalid message format!");
            }


            return Ok("Message saved successfully!");
        }
    }
}
