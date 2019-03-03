using RestaurantSchoolProject.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace RestaurantSchoolProject
{
    public interface IUserService
    {
        Task<Login> Authenticate(string username, string password);

    }

    public class UserService : IUserService
    {
        private RestaurantContext context = new RestaurantContext();



        public async Task<Login> Authenticate(string username, string password)
        {
            var user = await Task.Run(() => context.Login.SingleOrDefault(x => x.Login1 == username && x.Heslo == password));

            // Vrací NULL pokut uživatel neexistuje
            if (user == null)
                return null;

           
            user.Heslo = null;
            return user;
        }


    }
}