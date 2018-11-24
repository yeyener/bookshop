using System.Collections.Generic;
using bookshop.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Filters;

namespace bookshop.Attributes
{
    // Policy based auth kullanılacağı için burası atıl oldu. Kapat
    // public class AuthorizeYey : AuthorizeAttribute, IAuthorizationFilter
    // {
    //     private List<RoleEnum> _roles;

    //     public AuthorizeYey(List<RoleEnum> roles) : base() {
    //         _roles = roles;
    //     }

    //     public void OnAuthorization(AuthorizationFilterContext context)
    //     {
            
    //     }
    // }
}