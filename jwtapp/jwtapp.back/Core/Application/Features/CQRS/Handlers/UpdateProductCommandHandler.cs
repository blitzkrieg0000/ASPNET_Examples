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
    public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommandRequest>
    {
        private readonly IRepository<Product> _repository;
        private readonly IMapper _mapper;

        public UpdateProductCommandHandler(IRepository<Product> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateProductCommandRequest request, CancellationToken cancellationToken)
        {
            var updatedproduct = await _repository.GetByIdAsync(request.Id);
            if (updatedproduct!=null)
             {
                updatedproduct.CategoryId=request.CategoryId;
                updatedproduct.Name=request.Name;
                updatedproduct.Price=request.Price;
                updatedproduct.Stock=request.Stock;
                await _repository.UpdateAsync(updatedproduct);
             }   
             return Unit.Value;
        }
    }
}