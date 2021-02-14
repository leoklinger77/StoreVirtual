using System.ComponentModel.DataAnnotations;
using StoreVirtual.Service.Lang;

namespace StoreVirtual.Models
{
    public class Contato
    {
        [Required(ErrorMessageResourceType = typeof(Message), ErrorMessageResourceName = "MSG_E001")]
        [MinLength(3, ErrorMessageResourceType = typeof(Message), ErrorMessageResourceName = "MSG_E002")]
        public string Name { get; set; }
        [Required(ErrorMessageResourceType = typeof(Message), ErrorMessageResourceName = "MSG_E001")]
        [EmailAddress(ErrorMessageResourceType = typeof(Message), ErrorMessageResourceName = "MSG_E004")]
        public string Email { get; set; }
        [Required(ErrorMessageResourceType = typeof(Message), ErrorMessageResourceName = "MSG_E001")]
        [MinLength(10, ErrorMessageResourceType = typeof(Message), ErrorMessageResourceName = "MSG_E002")]
        [MaxLength(1000, ErrorMessageResourceType = typeof(Message), ErrorMessageResourceName = "MSG_E003")]
        public string Texto { get; set; }
    }
}
