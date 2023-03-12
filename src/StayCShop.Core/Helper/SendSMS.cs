using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StayCShop.Helper
{
    public static class SendSMS
    {
        public static bool Send(string phoneNumber, string myMessage)
        {
            try
            {
                var sender = "1000596446";
                var receptor = phoneNumber;
                var message = myMessage;
                var api = new Kavenegar.KavenegarApi("5559796441685A783369726D315642357062514C756A6A4C445867536C385345414345667176436C63356F3D");
                api.Send(sender, receptor, message);

                //var sender = "2000500666";
                //var receptor = phoneNumber;
                ////var message = ".وب سرویس پیام کوتاه کاوه نگار";
                //var api = new Kavenegar.KavenegarApi("5559796441685A783369726D315642357062514C756A6A4C445867536C385345414345667176436C63356F3D");
                //api.Send(sender, receptor, myMessage);
                return true;
            }
            catch (Exception)
            {

                return false;
            }

        }
    }
}
