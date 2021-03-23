using StoreVirtual.Models;
using StoreVirtual.Repositories.Interfaces;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace StoreVirtual.Service.Validation
{
    public class UniqueFuncionarioEmailAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            string email = (value as string).Trim();
            IFuncionarioRepository _repository = (IFuncionarioRepository)validationContext.GetService(typeof(IFuncionarioRepository));
            List<Funcionario> list = _repository.FindByEmails(email).ToList();

            Funcionario objetFun = (Funcionario)validationContext.ObjectInstance;


            if (list.Count() > 1)
            {
                return new ValidationResult("E-mail já existente");
            }

            if (list.Count == 1 && objetFun.Id != list[0].Id)
            {
                return new ValidationResult("E-mail já existente");
            }


            return ValidationResult.Success;
        }
    }
}
