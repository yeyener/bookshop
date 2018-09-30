namespace bookshop
{
    public class Result
    {
        public bool Success{get; private set;}
        public string ErrorMessage{get; private set;}

        private Result()
        {
            
        }

        public static Result Succeed(){
            return new Result(){Success = true};
        }

        public static Result Fail(string errorMessage){
            return new Result(){Success = false, ErrorMessage = errorMessage};
        }
    }
}