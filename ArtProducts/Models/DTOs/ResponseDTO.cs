namespace ArtProducts.Models.DTOs
{
    public class ResponseDTO
    {
        public string Message { get; set; } = string.Empty;
        public object ? Result { get; set; }
        public bool isSuccess {  get; set; }
    }
}
