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
    public class UpdateCategoryCommandHandler : IRequestHandler<UpdateCategoryCommandRequest>
    {
          private readonly IRepository<Category> _repository;
        private readonly IMapper _mapper;

        public UpdateCategoryCommandHandler(IRepository<Category> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateCategoryCommandRequest request, CancellationToken cancellationToken)
        {
            var updatedproduct = await _repository.GetByIdAsync(request.Id);
            if(updatedproduct != null)
            {
                updatedproduct.Id=request.Id;
                updatedproduct.Definition=request.Definition;
                await _repository.UpdateAsync(updatedproduct);
            };
            return Unit.Value;
            
        }
    }
}