using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using jwt.back.Core.Application.Interfaces;
using jwtapp.back.Core.Application.Dto;
using jwtapp.back.Core.Application.Features.CQRS.Queries;
using jwtapp.back.Core.Domain;
using MediatR;

namespace jwtapp.back.Core.Application.Features.CQRS.Handlers
{
    public class CheckUserQueryHandler : IRequestHandler<CheckUserQueryRequest, CheckUserResponseDto>
    {
        private readonly IMediator _mediator;
        private readonly IRepository<AppUser> _userrepository;
        private readonly IRepository<AppRole> _rolerepository;

        public CheckUserQueryHandler(IMediator mediator, IRepository<AppUser> userrepository, IRepository<AppRole> rolerepository )
        {
            _mediator = mediator;
            _userrepository = userrepository;
            _rolerepository = rolerepository;
        }

        public async Task<CheckUserResponseDto> Handle(CheckUserQueryRequest request, CancellationToken cancellationToken)
        {
            var dto =new CheckUserResponseDto();
            var user = await _userrepository.GetByFilterAsync(x=>x.Username == request.Username && x.Password == request.Password);
            if (user == null)
            {
                dto.IsExist = false;
            }
            
            else
            {
                var role = await _rolerepository.GetByFilterAsync(x=>x.Id == user.AppRoleId);
                dto.Id=user.Id;
                dto.Username=user.Username;
                dto.Password=user.Password;
                dto.IsExist=true;
                dto.Role=role?.Definition;
            }
            return dto;
        }
    }
}