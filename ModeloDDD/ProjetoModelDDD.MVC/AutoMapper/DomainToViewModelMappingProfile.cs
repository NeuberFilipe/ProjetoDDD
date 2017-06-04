using AutoMapper;
using ProjetoModelDDD.MVC.ViewModels;
using ProjetoModeloDDD.Dominio.Entities;

namespace ProjetoModelDDD.MVC.AutoMapper
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public string ProFileName
        {
            get { return "ViewModelToDomainMappings"; }
        }

        protected override void Configure()
        {
            Mapper.CreateMap<ClienteViewModel, Cliente>();
            Mapper.CreateMap<ProdutoViewModel, Produto>();
           
        }


    }
}