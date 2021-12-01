using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jopa
{
    class Program
    {
        public static ChatBDEntities ChatBDEntities = new ChatBDEntities();
        static void Main(string[] args)
        {
            foreach(var x in ChatBDEntities.Employee)
            {
                x.Password = HashPassword.Hash(x.Password, "половой огран");
            }
            ChatBDEntities.SaveChanges();
        }
    }

    public static class HashPassword
    {
        public static string Hash(string password, string salt)
        {
            byte[] data = System.Text.Encoding.ASCII.GetBytes(salt + password);
            data = System.Security.Cryptography.MD5.Create().ComputeHash(data);
            return Convert.ToBase64String(data);
        }
    }
}
