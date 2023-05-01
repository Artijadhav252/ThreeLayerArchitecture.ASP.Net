using Microsoft.EntityFrameworkCore;
using ThreeLayerArchitecture.ASP.Net.DAL;
using ThreeLayerArchitecture.ASP.Net.Models;
using ThreeLayerArchitecture.ASP.Net.Utility;

namespace ThreeLayerArchitecture.ASP.Net.BAL
{
    public interface IUserRePository
    {

        List<Gender> GetAllGenders();



        void CreateNewUser(UserRegistrationViewModel UserVM);



        List<Category> GetAllCategories();


        List<UserRegistrationViewModel> GetAllUsers();


        void DeleteUser(int Id);



        User GetUser(int Id);

        UserUpdateViewModel GetSingleUser(int Id);
        void UpdateUser(UserUpdateViewModel userUVM);

    }
}
