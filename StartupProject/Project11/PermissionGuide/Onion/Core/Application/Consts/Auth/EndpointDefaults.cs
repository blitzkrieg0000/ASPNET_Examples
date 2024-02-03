namespace Application.Consts.Auth;


public static class EndpointDefaults {

    public static class Menu {
        public const string NewsAnnouncement = "Haber ve Duyurular";
        public const string NewsAnnouncementCategory = "Haber ve Duyuru Kategorileri";
        public const string GrantSupport = "Hibe & Destekler";
        public const string GrantSupportCategory = "Hibe & Destek Kategorileri";
        public const string ProductGrowingSuggestion = "Yetiştirme Önerileri";
        public const string ProductGrowingSuggestionCategory = "Yetiştirme Önerisi Kategorileri";
        public const string Admin = "Admin";
        public const string User = "Kullanıcı";
        public const string Member = "Üye";
        public const string Role = "Rol Yönetimi";
        public const string UserRoleManagement = "Rol Atama Yönetimi";
        public const string Endpoint = "Modül Yönetimi";
        public const string APINewsAnnouncement = "API Haber ve Duyurular";
        public const string APINewsAnnouncementCategory = "API Haber ve Duyuru Kategorileri";
        public const string Redis = "Redis Cache Servis";
    }


    public static class Identifier {
        public enum NewsAnnouncement {
            List = 100,
            Create,
            Update,
            Delete
        }

        public enum NewsAnnouncementCategory {
            List = 200,
            Create,
            Update,
            Delete
        }

        public enum GrantSupport {
            List = 300,
            Create,
            Update,
            Delete
        }

        public enum GrantSupportCategory {
            List = 400,
            Create,
            Update,
            Delete
        }

        public enum ProductGrowingSuggestion {
            List = 500,
            Create,
            Update,
            Delete
        }

        public enum ProductGrowingSuggestionCategory {
            List = 600,
            Create,
            Update,
            Delete
        }

        public enum Admin {
            Index = 700,
            Settings
        }

        public enum User {
            List = 800,
            Create,
            Update,
            Delete
        }

        public enum Member {
            List = 900,
            Create,
            Update,
            Delete
        }

        public enum Role {
            List = 1000,
            Create,
            Update,
            Delete
        }

        public enum UserRoleManagement {
            AssignedRoleList = 1100,
            RoleAssignmentList,
            AssignRole,
            RemoveAssignedRole,
            AssignRolesByRoleEditor
        }

        public enum Endpoint {
            List = 1200,
            Update
        }

        public enum APINewsAnnouncement {
            List = 1300
        }

        public enum APINewsAnnouncementCategory {
            List = 1400
        }

        public enum Redis {
            Delete = 1500
        }
    }

}
