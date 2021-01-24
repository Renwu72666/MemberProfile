using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MemberProfile.Models;

namespace MemberProfile.Repositories
{
    public static class UserRepository
    {
        public static Members Get(string username, string password)
        {
            var users = new List<Members>();
            users.Add(new Members { MemberDetailId = 1, Username = "goku", Password = "goku", Role = "manager" });
            users.Add(new Members { MemberDetailId = 2, Username = "vejeta", Password = "vejeta", Role = "employee" });
            users.Add(new Members { MemberDetailId = 3, Username = "kuririn", Password = "kuririn", Role = "tester" });
            return users.Where(x => x.Username.ToLower() == username.ToLower() && x.Password == password).FirstOrDefault();
        }
    }
}