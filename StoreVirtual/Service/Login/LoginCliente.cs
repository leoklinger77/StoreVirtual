﻿using Newtonsoft.Json;
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

        public void SetFuncionario(Funcionario cliente)
        {           
            _session.Insert(Key, JsonConvert.SerializeObject(cliente));
        }

        public Funcionario GetFuncionario()
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
