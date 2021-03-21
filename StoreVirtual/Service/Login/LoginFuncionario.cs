using Newtonsoft.Json;
using StoreVirtual.Models;

namespace StoreVirtual.Service.Login
{
    public class LoginFuncionario
    {
        private readonly Session.Session _session;
        private string Key = ".Cliente";

        public LoginFuncionario(Session.Session session)
        {
            _session = session;
        }

        public void SetCliente(Funcionario funcinario)
        {
            _session.Insert(Key, JsonConvert.SerializeObject(funcinario));
        }

        public Funcionario GetCliente()
        {
            if (_session.GetConsult(Key) != null)
            {
                return JsonConvert.DeserializeObject<Funcionario>(_session.GetConsult(Key));
            }

            return null;

        }
        public void Update(Funcionario cliente)
        {
            _session.Update(Key, JsonConvert.SerializeObject(cliente));
        }

        public void Remove()
        {
            _session.Remove(Key);
        }
    }
}
