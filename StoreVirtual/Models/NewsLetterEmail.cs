using StoreVirtual.Service.Lang;
using System.ComponentModel.DataAnnotations;

namespace StoreVirtual.Models
{
    public class NewsLetterEmail
    {
        public int Id { get; set; }

        [Required(ErrorMessageResourceType = typeof(Message), ErrorMessageResourceName = "MSG_E001")]
        [EmailAddress(ErrorMessageResourceType = typeof(Message), ErrorMessageResourceName = "MSG_E004")]
        public string Email { get; set; }
    }
}
