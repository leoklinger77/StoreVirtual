namespace StoreVirtual.Models
{
    public class Funcionario
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public string Tipo { get; set; }

        public Funcionario()
        {
        }

        public Funcionario(int id, string nome, string email, string senha, string tipo)
        {
            Id = id;
            Nome = nome;
            Email = email;
            Senha = senha;
            Tipo = tipo;
        }
    }
}
