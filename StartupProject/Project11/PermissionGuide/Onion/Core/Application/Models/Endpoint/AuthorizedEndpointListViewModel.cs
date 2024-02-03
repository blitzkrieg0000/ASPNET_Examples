using Application.Dtos.Configurations;
using Domain.Entities.Auth;

namespace Application.Models.Endpoint;


public class AuthorizedEndpointListViewModel {
    public Guid Id { get; set; }
    public List<Menu> Menus { get; set; }
    public List<ApplicationEndpoint> Endpoints { get; set; }
}
