﻿using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;

namespace Projeto_Rumos.Models
{
    public class AuthenticatedUser
    {
		private readonly IHttpContextAccessor _accessor;

		public AuthenticatedUser(IHttpContextAccessor accessor)
		{
			_accessor = accessor;
		}

		public string Id => GetClaimsIdentity().FirstOrDefault(a => a.Type == ClaimTypes.NameIdentifier)?.Value;
		public string UserName => _accessor.HttpContext.User.Identity.Name;
		public string Email => GetClaimsIdentity().FirstOrDefault(a => a.Type == ClaimTypes.Email)?.Value;


		public IEnumerable<Claim> GetClaimsIdentity()
		{
			return _accessor.HttpContext.User.Claims;
		}
	}
}
