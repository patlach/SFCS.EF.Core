using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EF.Core
{
    public class UserRepository
    {
        public User SelectUserByID (AppContext context, int id)
        {
            return context.Users.FirstOrDefault(x => x.Id == id);
        }

        public IList<User> SelectAllUsers(AppContext context)
        {
            return context.Users.ToList();
        }

        public void AddUser(AppContext context, User user)
        {
            try
            {
                context.Users.Add(user);
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }    
        }

        public void UpdateUser(AppContext context, int userIdForUpdate, User updateUserData)
        {
            var user = context.Users.FirstOrDefault(x => x.Id == userIdForUpdate);

            user.Name = updateUserData.Name;
            user.Email = updateUserData.Email;
            user.Role = updateUserData.Role;

            try
            {
                context.SaveChanges();
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
