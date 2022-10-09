using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using TennisWeb6.Core.Application.Features.CQRS.Commands;
using TennisWeb6.Core.Application.Interfaces;
using TennisWeb6.Core.Domains;

namespace TennisWeb6.Core.Application.Features.CQRS.Handlers.Command {
    public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommandRequest> {

        private readonly IRepository<Product> _repository;

        public UpdateProductCommandHandler(IRepository<Product> repository) {
            _repository = repository;
        }

        public async Task<Unit> Handle(UpdateProductCommandRequest request, CancellationToken cancellationToken) {
            var updatedProduct = await _repository.GetByIdAsync(request.Id);
            if (updatedProduct != null) {
                updatedProduct.CategoryId = request.CategoryId;
                updatedProduct.Stock = request.Stock;
                updatedProduct.Price = request.Price;
                updatedProduct.Name = request.Name;
                await _repository.UpdateAsync(updatedProduct);
            }

            return Unit.Value;
        }

    }
}