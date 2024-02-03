using Application.Dtos.Configurations;

namespace Application.Interfaces.Service.Configurations;


public interface IApplicationService {

    List<Menu> GetAuthorizedEndpoints(Type type);

}
