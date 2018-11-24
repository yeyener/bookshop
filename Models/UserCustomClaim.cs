namespace bookshop.Models
{
    public class UserCustomClaim
    {
        public int UserId{get;set;}

        public User User{get;set;}

        public int CustomClaimId{get;set;}

        public CustomClaim CustomClaim {get;set;}
    }
}