using Application.Consts;
using Application.Interfaces.Repository.User;
using Application.Interfaces.Service.Auth;
using Application.Interfaces.Service.Storage;
using AutoMapper;
using Common.ResponseObjects;
using MediatR;

namespace Application.Features.CQRS.Commands.User.UpdateUser;


public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommandRequest, UpdateUserCommandResponse> {
    private readonly IUserQueryRepository _userQueryRepository;
    private readonly IUserCommandRepository _userCommandRepository;
    private readonly IUserManagerService _userManagerService;
    private readonly IStorageService _storageService;
    private readonly IMapper _mapper;


    public UpdateUserCommandHandler(IUserQueryRepository userQueryRepository, IUserCommandRepository userCommandRepository, IUserManagerService userManagerService, IStorageService storageService, IMapper mapper) {
        _userQueryRepository = userQueryRepository;
        _userCommandRepository = userCommandRepository;
        _userManagerService = userManagerService;
        _storageService = storageService;
        _mapper = mapper;
    }


    public async Task<UpdateUserCommandResponse> Handle(UpdateUserCommandRequest request, CancellationToken cancellationToken) {
        var user = await _userQueryRepository.GetByIdAsync(request.UserUpdateDto.Id);

        if (user.IsPersistent) {
            return new(ResponseType.NotAllowed, "Kullanıcı sistem tanımlı olduğu için değiştirilemez.");
        }

        _mapper.Map(request.UserUpdateDto, user);
        _userCommandRepository.UpdateOverwrite(user);


        // Manage File
        if (request.UserUpdateDto.Files != null && request.UserUpdateDto.Files.Count == 1) {

            if (!UploadContentDefaults.AllowedContentTypes.Contains(request.UserUpdateDto.Files[0].ContentType) || request.UserUpdateDto.Files[0].Length > 3000000) {
                return new(ResponseType.NotAllowed, "Eklenen dosya 3MB dan küçük JPG, JPEG, PNG, SVG formatında olmalıdır.");
            }

            var profilePhotoClaim = await _userManagerService.GetClaimAsync(user.Id, UserDefaults.ClaimsTypes.ProfilePhoto);

            if (profilePhotoClaim != null &&
                profilePhotoClaim.ClaimValue != null &&
                profilePhotoClaim.ClaimValue != ImageDefaults.UserProfilePhoto
            ) {
                await _storageService.DeleteAsync(profilePhotoClaim.ClaimValue);
            }

            List<(string fileName, string savedPathName)> result = await _storageService.UploadAsync(request.UserUpdateDto.Files, "data/upload/profile_photo");
            var (firstFileName, firstFileSavedPathName) = result.FirstOrDefault();
            await _userManagerService.SetClaim(user.Id, UserDefaults.ClaimsTypes.ProfilePhoto, firstFileSavedPathName);
        }


        await _userCommandRepository.SaveAsync();

        return new(ResponseType.Success, "Kullanıcı Güncellendi.");
    }

}
