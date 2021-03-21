using Newtonsoft.Json;
using StoreVirtual.Models;

namespace StoreVirtual.Service.Login
{
    public class LoginCliente
    {
        private readonly Session.Session _session;
        private string Key = ".Cliente";

        public LoginCliente(Session.Session session)
        {
            _session = session;
        }

        public void SetCliente(Cliente cliente)
        {           
            _session.Insert(Key, JsonConvert.SerializeObject(cliente));
        }

        public Funcionario GetCliente()
        {
            if (_session.GetConsult(Key) != null)
            {
                return JsonConvert.DeserializeObject<Funcionario>(_session.GetConsult(Key));
            }

            return null;
            
        }
        public void Update(Cliente cliente)
        {
            _session.Update(Key, JsonConvert.SerializeObject(cliente));
        }

        public void Remove()
        {
            _session.Remove(Key);
        }
    }
}
