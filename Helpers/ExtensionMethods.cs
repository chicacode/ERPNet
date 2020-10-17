using ERPNet.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ERPNet.Helpers
{
    public static class ExtensionMethods
    {
        public static IEnumerable<User> WithoutPasswords(this IEnumerable<User> users )
        {
            if(users == null) return null;
            return users.Select ( x => x.WithoutPassword () );
        }

        public static User WithoutPassword(this User user )
        {
            if(user == null) return null;

            user.Password = null;
            return user;
        }
    }
}
