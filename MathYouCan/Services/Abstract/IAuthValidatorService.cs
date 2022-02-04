using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MathYouCan.Services.Abstract
{
    public interface IAuthValidatorService
    {
        string AreValidCredentials(string mail, string password);
    }
}
