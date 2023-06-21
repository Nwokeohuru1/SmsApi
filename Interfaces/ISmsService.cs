using SmsApi.Models;

namespace SmsApi.Interfaces
{
    public interface ISmsService
    {
        Task<bool> SendSms(SmsReqObj smsReqObj);
    }
}
