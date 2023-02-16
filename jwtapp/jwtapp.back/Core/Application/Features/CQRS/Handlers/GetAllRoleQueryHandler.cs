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
    public class GetAllRoleQueryHandler : IRequestHandler<GetAllRolesQueryRequest, List<RoleListDto>>
    {
        private readonly IRepository<AppRole> _repository;
        private readonly IMapper _mapper;

        public GetAllRoleQueryHandler(IRepository<AppRole> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<List<RoleListDto>> Handle(GetAllRolesQueryRequest request, CancellationToken cancellationToken)
        {
            var datas =  await _repository.GetAllAsync();           
            var dto = _mapper.Map<List<RoleListDto>>(datas);
            return dto;
        }
    }
}