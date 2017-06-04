using ProjetoModeloDDD.Aplicacao.Interface;
using ProjetoModeloDDD.Dominio.Entities;
using ProjetoModeloDDD.Dominio.Interfaces.Services;
using System.Collections.Generic;

namespace ProjetoModeloDDD.Aplicacao
{
    public class ClienteAppService : AppServiceBase<Cliente>, IClienteAppService
    {
        private readonly IClienteService _clienteService;

        public ClienteAppService(IClienteService clienteService)
            :base(clienteService)
        {
            _clienteService = clienteService;
        }

        public IEnumerable<Cliente> ObterClientesEspeciais()
        {
            return _clienteService.ObterClienteEspeciais(_clienteService.GetAll());
        }
    }
}
