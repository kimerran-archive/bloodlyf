﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain = Bloodlyf.Domain;

namespace Bloodlyf.DataAccess.DonorProfile
{
    public interface IDonorProfileRepository : IBaseRepository<Domain.DonorProfile>
    {
    }
}
