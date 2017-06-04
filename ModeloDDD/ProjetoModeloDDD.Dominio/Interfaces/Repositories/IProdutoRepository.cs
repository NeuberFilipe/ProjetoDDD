using ProjetoModeloDDD.Dominio.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoModeloDDD.Dominio.Interfaces
{
  public interface IProdutoRepository : IRepositoryBase<Produto>
    {
        IEnumerable<Produto> BuscaPorNome(string nome);
    }
}
