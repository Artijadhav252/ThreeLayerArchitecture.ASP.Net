using ThreeLayerArchitecture.ASP.Net.DAL;
using ThreeLayerArchitecture.ASP.Net.Models;

namespace ThreeLayerArchitecture.ASP.Net.Utility
{
    public static class ExtensionMethodDemo
    {

        public static void ConvertUserVMToUserDTO(this User user,UserRegistrationViewModel UserVM)
        {
            user.EmailId = UserVM.EmailId;
            user.FirstName = UserVM.FirstName;
            user.LastName = UserVM.LastName;
            user.GenderId = UserVM.GenderId;
            user.MobileNumber = UserVM.MobileNumber;
            user.Password = UserVM.Password;
            user.AdharNumber = UserVM.AdharNumber;
            user.Category = UserVM.Category;
            user.TermsConditions = UserVM.TermsConditions;
        }

        public static void ConvertUserDTOToUserVM(this UserRegistrationViewModel userVM, User user)
        {
            userVM.Id = user.Id;
            userVM.EmailId = user.EmailId;
            userVM.FirstName = user.FirstName;
            userVM.LastName = user.LastName;
            userVM.GenderId = user.GenderId;
            //userVM.GenderName = user.Gender.TExt;
            userVM.MobileNumber = user.MobileNumber;
            userVM.AdharNumber = user.AdharNumber;
            userVM.Category = user.Category;
            userVM.Id = user.Id;
        }
        public static void ConvertUserVMToUserDTOForUpdateUser(this User user, UserUpdateViewModel userUVM)
        {
            user.FirstName = userUVM.FirstName;
            user.LastName = userUVM.LastName;
            user.GenderId = userUVM.GenderId;
            user.MobileNumber = userUVM.MobileNumber;
            user.AdharNumber = userUVM.AdharNumber;
            user.Category = userUVM.Category;
        }

    }
}
