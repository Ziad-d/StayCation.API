namespace StayCation.API.DTOs
{
    public class ResultDTO
    {
        public bool IsSuccess { get; set; }
        public dynamic Data { get; set; }
        public string Message { get; set; }

        public static ResultDTO Sucess(dynamic data, string message = "Success Operation")
        {
            return new ResultDTO
            {
                IsSuccess = true,
                Data = data,
                Message = message
            };
        }

        public static ResultDTO Faliure(string message = "Invalid Operation")
        {
            return new ResultDTO
            {
                IsSuccess = false,
                Data = default,
                Message = message,
            };
        }
    }
}
