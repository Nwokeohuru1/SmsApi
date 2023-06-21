using Microsoft.AspNetCore.Mvc;
using SmsApi.Interfaces;
using SmsApi.Models;

namespace SmsApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SmsController : ControllerBase
    {
        private readonly ISmsService _smsService;
        public SmsController(ISmsService smsService)
        {
            _smsService = smsService;
        }
        [HttpPost]
        [Route("SendSms")]
        public async Task<IActionResult> SendSms(SmsReqObj reqObj)
        {
            await _smsService.SendSms(reqObj);
            return Ok("Text Sent");
        }
    }
}
