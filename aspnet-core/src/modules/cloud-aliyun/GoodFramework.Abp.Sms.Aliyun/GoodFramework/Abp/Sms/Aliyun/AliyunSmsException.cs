using GoodFramework.Abp.Aliyun;

namespace GoodFramework.Abp.Sms.Aliyun
{
    public class AliyunSmsException : AbpAliyunException
    {
        public AliyunSmsException(string code, string message)
            :base(code, message)
        {
        }
    }
}
