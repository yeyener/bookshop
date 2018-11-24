using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace bookshop.Models
{
    [Table("Users")]
    public class User
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Password { get; set; }

        public string Salt{get;set;}

        public Collection<UserCustomClaim> UserCustomClaims{get;set;}

        public User()
        {
            UserCustomClaims = new Collection<UserCustomClaim>();
        }
    }
}