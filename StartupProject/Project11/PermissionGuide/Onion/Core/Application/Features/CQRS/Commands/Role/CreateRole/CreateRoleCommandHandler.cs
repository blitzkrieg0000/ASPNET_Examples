using Application.Interfaces.Repository.Role;
using AutoMapper;
using Common.ResponseObjects;
using Domain.Entities.Auth;
using MediatR;

namespace Application.Features.CQRS.Commands.Role.CreateRole;


public class CreateRoleCommandHandler : IRequestHandler<CreateRoleCommandRequest, CreateRoleCommandResponse> {
    private readonly IRoleQueryRepository _roleQueryRepository;
    private readonly IRoleCommandRepository _roleCommandRepository;
    private readonly IMapper _mapper;

    public CreateRoleCommandHandler(IRoleQueryRepository roleQueryRepository, IRoleCommandRepository roleCommandRepository, IMapper mapper) {
        _roleQueryRepository = roleQueryRepository;
        _roleCommandRepository = roleCommandRepository;
        _mapper = mapper;
    }

    public async Task<CreateRoleCommandResponse> Handle(CreateRoleCommandRequest request, CancellationToken cancellationToken) {
        var existingEntity = await _roleQueryRepository.GetByFilterAsync(x=>x.Name==request.RoleCreateDto.Name);
        if(existingEntity!=null){
            return new(ResponseType.NotAllowed, $"'{existingEntity.Name}' rolü zaten mevcut.");
        }
        var entity = _mapper.Map<ApplicationRole>(request.RoleCreateDto);
        await _roleCommandRepository.CreateAsync(entity);
        await _roleCommandRepository.SaveAsync();
        return new(ResponseType.Success, $"'{request.RoleCreateDto.Name}' rolü eklendi");
    }
}
