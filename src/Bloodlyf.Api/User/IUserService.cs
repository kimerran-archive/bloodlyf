using Bloodlyf.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain = Bloodlyf.Domain;

namespace Bloodlyf.Api.User
{
    public interface IUserService : IBaseService<Domain.User>
    {
        Domain.User Login(string u, string p);
    }
}
