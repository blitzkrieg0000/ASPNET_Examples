namespace Domain.Entities.Auth;


public class ApplicationMenu : BaseEntity {

    public string Name { get; set; }

    public ICollection<ApplicationEndpoint> Endpoints { get; set; }

    public ApplicationMenu() {
        Endpoints = new HashSet<ApplicationEndpoint>();
    }
}
