namespace Application.Models.UserRoleEditor;


public class UserRoleEditorModel {
    public Guid Id { get; set; }
    public string AssignedRoleIdsJson { get; set; }
    public string ExistRolesJson { get; set; }
}
