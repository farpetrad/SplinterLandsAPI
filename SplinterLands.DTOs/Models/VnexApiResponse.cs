namespace SplinterLands.DTOs.Models
{
    public class VnexApiResponse<T>
    {
        public string status { get; set; } = string.Empty;
        public T? data { get; set; } = default(T?);
    }
}
