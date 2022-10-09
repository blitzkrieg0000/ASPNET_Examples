namespace TennisWeb6.Core.Domains {
    public class AppUser {
        public int Id { get; set; }
        public string? Username { get; set; }
        public string? Password { get; set; }
        public int AppRoleId { get; set; }
        public AppRole AppRoles { get; set; }

        public AppUser() {
            AppRoles = new AppRole();
        }
    }
}