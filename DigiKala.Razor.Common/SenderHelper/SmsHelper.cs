namespace DigiKala.Common.SenderHelper
{
    public class SmsHelper
    {
        //private IAdmin _admin;


        public void smsSender(string to, string body)
        {
            var sender = "10008663";
            var receptor = to;
            var message = body;
            var api = new Kavenegar.KavenegarApi("5241435546364C68305543484D4E79496A6D56314B4F332F6E31355A425A4431365766556C534B71786A343D");
            api.Send(sender, receptor, message);

        }
    }
}