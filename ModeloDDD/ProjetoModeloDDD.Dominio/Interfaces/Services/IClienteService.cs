using ProjetoModeloDDD.Dominio.Entities;
using System.Collections.Generic;

namespace ProjetoModeloDDD.Dominio.Interfaces.Services
{
   public interface IClienteService : IServiceBase<Cliente>
    {
        IEnumerable<Cliente> ObterClienteEspeciais(IEnumerable<Cliente> clientes);
    }
}
