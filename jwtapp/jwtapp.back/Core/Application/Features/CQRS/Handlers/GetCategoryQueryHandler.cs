using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using jwt.back.Core.Application.Interfaces;
using jwtapp.back.Core.Application.Dto;
using jwtapp.back.Core.Application.Features.CQRS.Queries;
using jwtapp.back.Core.Domain;
using MediatR;

namespace jwtapp.back.Core.Application.Features.CQRS.Handlers
{
    public class GetCategoryQueryHandler : IRequestHandler<GetCategoryQueryRequest, CategoryListDto>
    {
         private readonly IRepository<Category> _repository;
        private readonly IMapper _mapper;

        public GetCategoryQueryHandler(IRepository<Category> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<CategoryListDto> Handle(GetCategoryQueryRequest request, CancellationToken cancellationToken)
        {
           var data = await _repository.GetByFilterAsync(x=>x.Id == request.Id);
            var dto = _mapper.Map<CategoryListDto>(data);
            return dto;
        }
    }
}