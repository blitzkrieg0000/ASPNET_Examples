using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using TennisWeb6.Core.Application.Features.CQRS.Commands;
using TennisWeb6.Core.Application.Interfaces;
using TennisWeb6.Core.Domains;

namespace TennisWeb6.Core.Application.Features.CQRS.Handlers.Command {
    public class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommandRequest> {
        private readonly IRepository<Product> _repository;

        public DeleteProductCommandHandler(IRepository<Product> repository) {
            _repository = repository;
        }

        public async Task<Unit> Handle(DeleteProductCommandRequest request, CancellationToken cancellationToken) {
            var deletedEntity = await _repository.GetByIdAsync(request.Id);
            if (deletedEntity != null) {
                await _repository.RemoveAsync(deletedEntity);
            }
            return Unit.Value;
        }
    }
}