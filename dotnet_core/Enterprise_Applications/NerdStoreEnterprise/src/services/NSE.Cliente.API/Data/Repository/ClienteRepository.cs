﻿using Microsoft.EntityFrameworkCore;
using NSE.Cliente.API.Models;
using NSE.Core.Data;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NSE.Cliente.API.Data.Repository
{
    public class ClienteRepository : IClienteRepository
    {
        private readonly ClientesContext _context;
        public IUnitOfWork UnitOfWork => _context;

        public ClienteRepository(ClientesContext context)
        {
            _context = context;
        }

        public void Adicionar(Models.Cliente cliente)
        {
            _context.Add(cliente);
        }

        public void Dispose()
        {
            _context.Dispose();
        }

        public async Task<Models.Cliente> ObterPorCpf(string cpf)
        {
            return await _context.Clientes.FirstOrDefaultAsync(c => c.Cpf.Numero == cpf);
        }

        public async Task<IEnumerable<Models.Cliente>> ObterTodos()
        {
            return await _context.Clientes.AsNoTracking().ToListAsync();
        }
    }
}