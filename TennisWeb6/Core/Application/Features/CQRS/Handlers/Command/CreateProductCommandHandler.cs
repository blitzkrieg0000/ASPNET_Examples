using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using TennisWeb6.Core.Application.Features.CQRS.Commands;
using TennisWeb6.Core.Application.Interfaces;
using TennisWeb6.Core.Domains;

namespace TennisWeb6.Core.Application.Features.CQRS.Handlers.Command {
    public class CreateProductCommandHandler : IRequestHandler<CreateProductCommandRequest> {
        private readonly IRepository<Product> _repository;

        public CreateProductCommandHandler(IRepository<Product> repository) {
            _repository = repository;
        }

        public async Task<Unit> Handle(CreateProductCommandRequest request, CancellationToken cancellationToken) {
            await _repository.CreateAsync(new Product() {
                CategoryId = request.CategoryId,
                Name = request.Name,
                Price = request.Price,
                Stock = request.Stock
            });
            return Unit.Value;
        }
    }
}