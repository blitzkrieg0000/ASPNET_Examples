namespace Domain.Entities.Auth;


public class ApplicationMenu : BaseEntity {

    public string Name { get; set; }

    public virtual ICollection<ApplicationRoleMenu> ApplicationRoleMenus { get; set; }
    
    public ApplicationMenu() {
        ApplicationRoleMenus = new HashSet<ApplicationRoleMenu>();
    }
}
