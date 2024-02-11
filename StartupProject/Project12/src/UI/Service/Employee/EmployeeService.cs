using AutoMapper;
using UI.Abstraction.Repository.Employee;
using UI.Abstraction.Service.Auth;
using UI.Abstraction.Service.Employee;
using UI.Abstraction.Service.Hash;
using UI.Common.ResponseObject;
using UI.Dto.Auth;
using UI.Dto.Employee;
using UI.Entities.Auth;
using E = UI.Entity.Concrete.Employee;
namespace UI.Service.Employee;


public class EmployeeService : IEmployeeService {
    private readonly IUserManagerService _userManagerService;
    private readonly IEmployeeQueryRepository _employeeQueryRepository;
    private readonly IEmployeeCommandRepository _employeeCommandRepository;
    private readonly IHashService _hashService;
    private readonly IMapper _mapper;

    public EmployeeService(IUserManagerService userManagerService, IEmployeeQueryRepository employeeQueryRepository, IEmployeeCommandRepository employeeCommandRepository, IHashService hashService, IMapper mapper) {
        _userManagerService = userManagerService;
        _employeeQueryRepository = employeeQueryRepository;
        _employeeCommandRepository = employeeCommandRepository;
        _hashService = hashService;
        _mapper = mapper;
    }

    public async Task<Response<List<EmployeeDto>>> ListEmployeeAsync() {
        var employeeList = await _employeeQueryRepository.GetAllAsync();
        var datas = _mapper.Map<List<EmployeeDto>>(employeeList);
        return new(ResponseType.Success, datas);
    }


    public async Task<Response> CreateEmployeeAsync(EmployeeCreateDto dto) {
        dto.Password = _hashService.GetHashSha3_512(dto.Password);

        var employeeData = _mapper.Map<E::Employee>(dto);
        var userData = _mapper.Map<UserSignUpDto>(dto);

        var responseUser = await _userManagerService.CreateUserAsync(userData);
        employeeData.Id = responseUser.Data.Id;
        
        await _employeeCommandRepository.CreateAsync(employeeData);
        await _employeeCommandRepository.SaveAsync();

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
