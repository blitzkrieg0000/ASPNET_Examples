using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using jwt.back.Core.Application.Interfaces;
using jwtapp.back.Core.Application.Enums;
using jwtapp.back.Core.Application.Features.CQRS.Commands;
using jwtapp.back.Core.Domain;
using MediatR;

namespace jwtapp.back.Core.Application.Features.CQRS.Handlers
{
    public class RegisterUserCommandHandler : IRequestHandler<RegisterUserCommandRequest>
    {
        private readonly IRepository<AppUser> _repository;

        public RegisterUserCommandHandler(IRepository<AppUser> repository)
        {
            _repository = repository;
        }

        public async Task<Unit> Handle(RegisterUserCommandRequest request, CancellationToken cancellationToken)
        {
            await _repository.CreateAsync(new AppUser{
             
                Username=request.Username,
                Password=request.Password,
                AppRoleId =(int)RoleType.Member
            });
            return Unit.Value;
        }
    }
}