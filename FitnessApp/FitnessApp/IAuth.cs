using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FitnessApp
{
    public interface IAuth
    {
        Task<String> LoginWithEmailAndPassword(String email, String password);
        Task<String> SignUpWithEmailAndPassword(String email, String password);

        bool SignOut();
        bool IsSignIn();
    }
}
