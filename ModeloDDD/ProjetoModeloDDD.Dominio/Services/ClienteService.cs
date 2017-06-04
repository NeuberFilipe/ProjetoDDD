using System.Collections.Generic;
using ProjetoModeloDDD.Dominio.Entities;
using ProjetoModeloDDD.Dominio.Interfaces;
using ProjetoModeloDDD.Dominio.Interfaces.Services;
using System.Linq;

namespace ProjetoModeloDDD.Dominio.Services
{
    public class ClienteService : ServiceBase<Cliente>, IClienteService
    {
        private readonly IClienteRepository _clienteRepository;

        public ClienteService(IClienteRepository clienteRepository)
            : base(clienteRepository)
        {
            _clienteRepository = clienteRepository;
        }

        public IEnumerable<Cliente> ObterClienteEspeciais(IEnumerable<Cliente> clientes)
        {
            return clientes.Where(c => c.ClienteEspecial(c));
        }
    }
}
