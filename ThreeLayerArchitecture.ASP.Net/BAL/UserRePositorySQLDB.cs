using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using ThreeLayerArchitecture.ASP.Net.DAL;
using ThreeLayerArchitecture.ASP.Net.Models;
using ThreeLayerArchitecture.ASP.Net.Utility;

namespace ThreeLayerArchitecture.ASP.Net.BAL
{
    public class UserRePositorySQLDB: IUserRePository
    {

        private int Id;
        private readonly MvcfirstContext db;
        public UserRePositorySQLDB(MvcfirstContext _db)
        {
            this.db = _db;
        }

        public List<Gender> GetAllGenders()
        {
           
            var genders = db.Genders.ToList();
            return genders;
        }


        public void CreateNewUser(UserRegistrationViewModel UserVM)
        {
          


            //User user = new User(UserVM);
            User user = new User();
            user.ConvertUserVMToUserDTO(UserVM);


            db.Users.Add(user);
            db.SaveChanges();

        }

        public List<Category> GetAllCategories()
        {


            List<Category> categories = new List<Category>();
            Category category1 = new Category();
            category1.Id = 1;
            category1.Name = "General";

            Category category2 = new Category();
            category2.Id = 2;
            category2.Name = "OBC";

            Category category3 = new Category();
            category3.Id = 1;
            category3.Name = "Other";

            categories.Add(category1);
            categories.Add(category2);
            categories.Add(category3);

            return categories;
        }

        public List<UserRegistrationViewModel> GetAllUsers()
        {
           
            //List<User> usersPrevious = db.Users.ToList();
            List<User> users = db.Users.Include(user=>user.Gender). ToList();

            List<UserRegistrationViewModel> userRegistrationViewModels = new List<UserRegistrationViewModel>();

            foreach (var user in users)
            {
               // UserRegistrationViewModel userVM = new UserRegistrationViewModel(user);
                UserRegistrationViewModel userVM = new UserRegistrationViewModel();
                userVM.ConvertUserDTOToUserVM(user);

                userRegistrationViewModels.Add(userVM);
            }

            return userRegistrationViewModels;

        }

        public void DeleteUser(int Id)
        {
           
            var user=GetUser(Id);
            if(user !=null)

            
            {
                db.Users.Remove(user);
                db.SaveChanges();
            }
        }
       
        public User GetUser(int Id)
        {

          
            var user = db.Users.FirstOrDefault(user => user.Id == Id);
            return user;
            
        }
        public UserUpdateViewModel GetSingleUser( int Id)
        {
            
            User user = db.Users.Find(Id);
            UserUpdateViewModel userUpdateViewModel = null;
            if (user!= null)
            {
                userUpdateViewModel = new UserUpdateViewModel(user);

            }
            return userUpdateViewModel;
        }

        public void UpdateUser(UserUpdateViewModel userUVM)
        {
            var user = db.Users.Find(userUVM.Id);
            if (user != null)
            {



                user.ConvertUserVMToUserDTOForUpdateUser(userUVM);


                db.Users.Update(user);
                db.SaveChanges();
            }


        }
    }
}

