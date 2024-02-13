using AutoMapper;
using Microsoft.EntityFrameworkCore;
using UI.Abstraction.Repository.Employee;
using UI.Abstraction.Service.Auth;
using UI.Abstraction.Service.Employee;
using UI.Abstraction.Service.Hash;
using UI.Common.ResponseObject;
using UI.Dto.Auth;
using UI.Dto.Employee;
using E = UI.Entity.Concrete.Employee;
namespace UI.Service.Employee;


public class EmployeeService : IEmployeeService {
    private readonly IUserManagerService _userManagerService;
    private readonly IRoleManagerService _roleManagerService;
    private readonly IEmployeeQueryRepository _employeeQueryRepository;
    private readonly IEmployeeCommandRepository _employeeCommandRepository;
    private readonly IHashService _hashService;
    private readonly IMapper _mapper;

    public EmployeeService(IUserManagerService userManagerService, IRoleManagerService roleManagerService, IEmployeeQueryRepository employeeQueryRepository, IEmployeeCommandRepository employeeCommandRepository, IHashService hashService, IMapper mapper) {
        _userManagerService = userManagerService;
        _roleManagerService = roleManagerService;
        _employeeQueryRepository = employeeQueryRepository;
        _employeeCommandRepository = employeeCommandRepository;
        _hashService = hashService;
        _mapper = mapper;
    }


    public async Task<Response<EmployeeUpdateDto>> GetByIdAsync(string id) {
        var employee = await _employeeQueryRepository.GetByIdAsync(id);
        return new(ResponseType.Success, _mapper.Map<EmployeeUpdateDto>(employee));
    }


    public async Task<Response<List<EmployeeDto>>> ListEmployeeAsync() {
        var employeeList = await _employeeQueryRepository.GetAllAsync();
        var datas = _mapper.Map<List<EmployeeDto>>(employeeList);
        return new(ResponseType.Success, datas);
    }


    public async Task<Response> CreateEmployeeAsync(EmployeeCreateDto dto) {
        //TODO UserRole ve EmployeeType Rollerini Eşleştir.
        //TODO Transaction ve Disposable UserManager davranışını kontrol et.
        dto.Password = _hashService.GetHashSha3_512(dto.Password);

        var employeeData = _mapper.Map<E::Employee>(dto);
        var userData = _mapper.Map<UserSignUpDto>(dto);

        var responseUser = await _userManagerService.CreateUserAsync(userData);
        if (responseUser.ResponseType != ResponseType.Success){
            return new(ResponseType.NotAllowed, responseUser.Message);
        }
        
        employeeData.Id = responseUser.Data.Id;

        await _employeeCommandRepository.CreateAsync(employeeData);
        await _employeeCommandRepository.SaveAsync();

        var employeeWithType = await _employeeQueryRepository.GetQuery()
            .AsNoTracking()
            .Where(x => x.Id == employeeData.Id)
            .Include(x => x.EmployeeType)
            .FirstOrDefaultAsync();

        await _roleManagerService.AssignRoleByUserAsync(userData.Id, employeeWithType.EmployeeType.ApplicationRoleId);

        return new(ResponseType.Success);
    }


    public async Task<Response> UpdateEmployeeAsync(EmployeeUpdateDto dto) {
        var existData = await _employeeQueryRepository.GetByIdAsync(dto.Id);
        _mapper.Map(dto, existData); // Varsayılan objenin üzerine mapleme yapılır. Bu sayede değiştirilmeyen veriler sıfırlanmaz.

        await _employeeCommandRepository.UpdateAsync(existData);
        await _employeeCommandRepository.SaveAsync();
        return new(ResponseType.Success);
    }
}
