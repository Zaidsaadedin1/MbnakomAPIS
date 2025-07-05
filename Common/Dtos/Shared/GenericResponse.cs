namespace MbnakomAPIS.Common.Dtos.Shared
{
    public class GenericResponse<T>
    {
        public bool Success { get; set; }
        public string? Message { get; set; }
        public T? Data { get; set; }
    }
}
