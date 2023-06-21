using SmsApi.Interfaces;
using SmsApi.Models;
using Twilio;
using Twilio.Rest.Api.V2010.Account;

namespace SmsApi.Services
{
    public class SmsService : ISmsService
    {
        private readonly IConfiguration _config;
        public SmsService(IConfiguration config)
        {
            _config= config;
        }
        
        public Task<bool> SendSms(SmsReqObj smsReqObj)
        {
            
            TwilioClient.Init(_config.GetSection("Twillo:AccountSid").Value, _config.GetSection("Twillo:AuthToken").Value);
            var message = MessageResource.Create(
                
                body: smsReqObj.Body,
                from: new Twilio.Types.PhoneNumber(_config.GetSection("Twillo:TwilloPhoneNumber").Value),
                to: new Twilio.Types.PhoneNumber(smsReqObj.To)
            );
            return Task.FromResult(true);
            
        }
    }
}
