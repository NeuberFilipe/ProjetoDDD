using AutoMapper;
using ProjetoModelDDD.MVC.ViewModels;
using ProjetoModeloDDD.Dominio.Entities;

namespace ProjetoModelDDD.MVC.AutoMapper
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public string ProFileName
        {
            get { return "DomainToViewModelMappings"; }
        }

        protected override void Configure()
        {
            Mapper.CreateMap<Cliente, ClienteViewModel>();
            Mapper.CreateMap<Produto, ProdutoViewModel>();
        }

    }
}