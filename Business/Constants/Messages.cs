using Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Constants
{
    public class Messages
    {
        public static string ProductAdded = "Product added";
        public static string ProductNameInvalid = "Product name invalid";
        public static string ProductListed = "Product listed";
        public static string MaintanenceTime = "Maintanence Time";
        public static string UpdatedProduct = "Product updated";
        public static string ProdocutCountOfCategoryError = "Prodocut Count Of Category Error";

        public static string ProdocutNameAlreadyExists = "Prodocut name already exists";
        public static string CategoryLimitExcited = "Category limit excited";

        public static string? AuthorizationDenied = "Authorization denied";
        public static string UserRegistered = "User Registered";
        public static string UserNotFound = "User not found";
        public static string PasswordError = "Password error";

        public static string SuccessfulLogin = "Login successful";
        public static string UserAlreadyExists = "User already exists";
        public static string AccessTokenCreated = "Access token created";
    }
}
