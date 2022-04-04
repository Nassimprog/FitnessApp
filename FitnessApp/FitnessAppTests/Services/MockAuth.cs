using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessAppTests.Services
{
    public class MockAuth
    {
        public string LoginWithEmailAndPassword(String email, String password)
        {
            return "token";
        }
        public string SignUpWithEmailAndPassword(String email, String password)
        {
            return "token";
        }

        bool SignOut()
        {
            return true;
        }
        bool IsSignIn() 
        {
            return true;
        }
    }
}
