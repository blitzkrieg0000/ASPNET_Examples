namespace Domain.Entities.Auth;


public class ApplicationEndpoint : BaseEntity {
    public string ActionType { get; set; }
    public string HttpType { get; set; }
    public string Definition { get; set; }
    public string Code { get; set; }

    public ApplicationMenu Menu { get; set; }
    public ICollection<ApplicationRole> Roles { get; set; }


    public ApplicationEndpoint() {
        Roles = new HashSet<ApplicationRole>();
    }
}

