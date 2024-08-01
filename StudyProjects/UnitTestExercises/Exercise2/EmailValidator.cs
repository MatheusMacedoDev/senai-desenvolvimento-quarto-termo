using System.Net.Http.Headers;
using System.Net.Mail;

namespace Exercise2
{
    public static class EmailValidator
    {
        public static bool Validate(string email)
        {
            try
            {
                new MailAddress(email);

                return true;
            } 
            catch(FormatException)
            {
                return false;
            }
        }
    }
}
