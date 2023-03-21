using LatinoNet.DTOs;
using LatinoNet.Entities.Interfaces;
using LatinoNet.UseCasesPorts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LatinoNet.UseCases.GetAllProducts
{
    public class GetAllProductsInteractor : IGetAllProductsInputPort
    {
        readonly IProductRepository Repository;
        readonly IGetAllProductsOutputPort OutputPort;

        public GetAllProductsInteractor(IProductRepository repository, IGetAllProductsOutputPort outputPort) =>
            (Repository, OutputPort) = (repository, outputPort);

        public Task Handle()
        {
            var products = Repository.GetAll().Select(x => new ProductDTO
            {
                Id = x.Id,
                Name = x.Name,
            });

            OutputPort.Handle(products);

            return Task.CompletedTask;
        }
    }
}
