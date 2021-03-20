﻿using Microsoft.AspNetCore.Http;

namespace StoreVirtual.Service.Session
{
    public class Session
    {

        private readonly HttpContextAccessor _context;

        public Session(HttpContextAccessor httpContext)
        {
            _context = httpContext;
        }

        public void Insert(string key, string valor)
        {
            _context.HttpContext.Session.SetString(key, valor);
        }

        public void Update(string key, string valor)
        {
            if (Exist(key))
            {
                Remove(key);
                Insert(key, valor);
            }
        }

        public void Remove(string key)
        {
            _context.HttpContext.Session.Remove(key);
        }

        public string GetConsult(string key)
        {
            return _context.HttpContext.Session.GetString(key);
        }
        public bool Exist(string key)
        {
            if (_context.HttpContext.Session.GetString(key) == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public void RemoveAll()
        {
            _context.HttpContext.Session.Clear();
        }
    }
}