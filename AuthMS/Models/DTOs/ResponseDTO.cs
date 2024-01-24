namespace AuthMS.Models.DTOs
{
    public class ResponseDTO
    {
        public string Message {  get; set; }=string.Empty;

        public object Result { get; set; } = default!;

        public bool IsSuccess { get; set; } = true;
    }
}
