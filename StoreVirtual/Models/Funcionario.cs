using StoreVirtual.Service.Lang;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StoreVirtual.Models
{
    public class Funcionario
    {
        public int Id { get; set; }

        [Required(ErrorMessageResourceType = typeof(Message), ErrorMessageResourceName = "MSG_E001")]
        [MinLength(3, ErrorMessageResourceType = typeof(Message), ErrorMessageResourceName = "MSG_E002")]
        public string Nome { get; set; }
        [Display(Name ="E-mail")]
        [Required(ErrorMessageResourceType = typeof(Message), ErrorMessageResourceName = "MSG_E001")]
        [EmailAddress(ErrorMessageResourceType = typeof(Message), ErrorMessageResourceName = "MSG_E004")]
        public string Email { get; set; }
        [Required(ErrorMessageResourceType = typeof(Message), ErrorMessageResourceName = "MSG_E001")]
        [MinLength(6, ErrorMessageResourceType = typeof(Message), ErrorMessageResourceName = "MSG_E002")]
        public string Senha { get; set; }
        [NotMapped]
        [Display(Name = "Confirmar Senha")]
        [Compare("Senha", ErrorMessageResourceType = typeof(Message), ErrorMessageResourceName = "MSG_E005")]
        public string ConfirmarSenha { get; set; }        
        public string Tipo { get; set; }

        public Funcionario()
        {
        }

        public Funcionario(int id, string nome, string email, string senha, string confirmarSenha, string tipo)
        {
            Id = id;
            Nome = nome;
            Email = email;
            Senha = senha;
            ConfirmarSenha = confirmarSenha;
            Tipo = tipo;
        }
    }
}
