namespace StoreVirtual.Models
{
    public class ErrorViewModel
    {
        public string RequestId { get; set; }
        public bool ShowResquetId => !string.IsNullOrEmpty(RequestId);
    }
}
