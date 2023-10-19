
using BlazorApp1.Authentication;
namespace BlazorApp1.Authentication
{
    public class UserAccountService
    {

        public async Task<string> GetByUserName(string _email, string _password)

        {

            var ua = await DAL.DALUserAuth.Authenticate(_email, _password);
            if(ua!=null)
            {
                return ua;

            }
            else
            {
                return "";
            }
        }

    }
}
