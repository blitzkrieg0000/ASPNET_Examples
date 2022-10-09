using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using TennisWeb6.Core.Application.Dtos;
using TennisWeb6.Core.Application.Features.CQRS.Queries;
using TennisWeb6.Core.Application.Interfaces;
using TennisWeb6.Core.Domains;

namespace TennisWeb6.Core.Application.Features.CQRS.Handlers.Query {
    public class GetAllProductsQueryHandler : IRequestHandler<GetAllProductsQueryRequest, List<ProductListDto>> {
        private readonly IRepository<Product> _repository;
        private readonly IMapper _mapper;
        public GetAllProductsQueryHandler(IRepository<Product> repository, IMapper mapper) {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<List<ProductListDto>> Handle(GetAllProductsQueryRequest request, CancellationToken cancellationToken) {
            var data = await _repository.GetAllAsync();
            return _mapper.Map<List<ProductListDto>>(data);
        }
    }
}