namespace MyFirstProject.WebApp.Models
{
    public class ErrorViewModel
    {
        //novo comentario
        public string? RequestId { get; set; }
        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
    }
}
