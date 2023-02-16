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
    public class GetAllAppUserQueryHandler : IRequestHandler<GetAllAppUsersQueryRequest, List<AppUserListDto>>
    {
        private readonly IRepository<AppUser> _repository;
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public GetAllAppUserQueryHandler(IRepository<AppUser> repository, IMediator mediator, IMapper mapper)
        {
            _repository = repository;
            _mediator = mediator;
            _mapper = mapper;
        }

        public async Task<List<AppUserListDto>> Handle(GetAllAppUsersQueryRequest request, CancellationToken cancellationToken)
        {
            var data = await _repository.GetAllAsync();
            var dto = _mapper.Map<List<AppUserListDto>>(data);
            return dto;
        }
    }
}