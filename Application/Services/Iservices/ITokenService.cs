﻿using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.Iservices
{
    public interface ITokenService
    {
        string GenerateToken(UserDTO user);

    }
}
