using AutoMapper;
using UI.Abstraction.Repository.Employee;
using UI.Abstraction.Service.Employee;
using UI.Common.ResponseObject;
using UI.Dto.Employee;
using E = UI.Entity.Concrete.Employee;
namespace UI.Service.Employee;


public class EmployeeService : IEmployeeService {
    private readonly IEmployeeQueryRepository _employeeQueryRepository;
    private readonly IEmployeeCommandRepository _employeeCommandRepository;
    private readonly IMapper _mapper;

    public EmployeeService(IEmployeeQueryRepository employeeQueryRepository, IEmployeeCommandRepository employeeCommandRepository, IMapper mapper) {
        _employeeQueryRepository = employeeQueryRepository;
        _employeeCommandRepository = employeeCommandRepository;
        _mapper = mapper;
    }


    public async Task<Response<List<EmployeeDto>>> ListEmployeeAsync() {
        var employeeList = await _employeeQueryRepository.GetAllAsync();
        var datas = _mapper.Map<List<EmployeeDto>>(employeeList);
        return new(ResponseType.Success, datas);
    }


    public async Task<Response> CreateEmployeeAsync(EmployeeCreateDto dto) {
        var data = _mapper.Map<E::Employee>(dto);
        await _employeeCommandRepository.CreateAsync(data);
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
