using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using jwt.back.Core.Application.Interfaces;
using jwtapp.back.Core.Application.Features.CQRS.Commands;
using jwtapp.back.Core.Domain;
using MediatR;

namespace jwtapp.back.Core.Application.Features.CQRS.Handlers
{
    public class DeleteCategoryCommandHandler : IRequestHandler<DeleteCategoryCommandRequest>
    {   
        private readonly IRepository<Category> _repository;
        private readonly IMapper mapper;

        public DeleteCategoryCommandHandler(IRepository<Category> repository, IMapper mapper)
        {
            _repository = repository;
            this.mapper = mapper;
        }

        public async Task<Unit> Handle(DeleteCategoryCommandRequest request, CancellationToken cancellationToken)
        {
            var deleteddata =await _repository.GetByIdAsync((object)request.Id);
            if (deleteddata != null)
            {
                await _repository.RemoveAsync(deleteddata);
            }
            
            return Unit.Value;
        }
    }
}