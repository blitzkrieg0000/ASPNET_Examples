using Application.Dtos.User;
using Application.Dtos.UserRole;
using Application.Extensions;
using Application.Interfaces.Repository.User;
using Application.Interfaces.Service.Auth;
using AutoMapper;
using Common.ResponseObjects;
using MediatR;

namespace Application.Features.CQRS.Queries.User.UpdateUser;


public class UpdateUserQueryHandler : IRequestHandler<UpdateUserQueryRequest, UpdateUserQueryResponse> {
    private readonly IUserQueryRepository _userQueryRepository;
    private readonly IUserManagerService _userManagerService;
    private readonly IRoleManagerService _roleManagerService;
    private readonly IMapper _mapper;

    public UpdateUserQueryHandler(IUserQueryRepository userQueryRepository, IUserManagerService userManagerService, IRoleManagerService roleManagerService, IMapper mapper) {
        _userQueryRepository = userQueryRepository;
        _userManagerService = userManagerService;
        _roleManagerService = roleManagerService;
        _mapper = mapper;
    }

    public async Task<UpdateUserQueryResponse> Handle(UpdateUserQueryRequest request, CancellationToken cancellationToken) {
        var user = await _userQueryRepository.GetByIdAsync(request.Id);
        if (user == null) {
            return new(ResponseType.ValidationError, "Kullanıcı Bulunamadı.");
        }

        var userUpdateDto = _mapper.Map<UserUpdateDto>(user);
        var userClaim = await _userManagerService.GetClaimAsync(user.Id, "ProfilePhoto");
        if (userClaim != null) {
            userUpdateDto.Image = userClaim.ClaimValue;
        }

        var metaData = new Dictionary<string, dynamic> { { "Secret", userUpdateDto.Id.EncryptGuid() } };
        return new UpdateUserQueryResponse(ResponseType.Success, userUpdateDto, metaData);
    }
}
