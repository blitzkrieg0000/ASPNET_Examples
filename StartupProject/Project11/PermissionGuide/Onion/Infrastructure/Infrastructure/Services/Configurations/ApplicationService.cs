using System.Reflection;
using Application.Attributes;
using Application.Dtos.Configurations;
using Application.Enums;
using Application.Extensions;
using Application.Interfaces.Service.Configurations;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Routing;
using C = Application.Dtos.Configurations;
namespace Infrastructure.Services.Configurations;


public class ApplicationService : IApplicationService {
    /**
        <summary> 
            Reflection kullanarak "AuthorizeEndpointAttribute" ile işaretlenen Action'ları topluyor. 
        </summary> 
        
        <param name="type">
            Assembly tipi alıyor.
            <code>
                typeof(Program) gibi
            </code>
        </param>

        <returns>
            Controller'ları tanımalanan Menu objesi gibi alarak bir liste halinde döndürür. 
        </returns>
    */
    public List<Menu> GetAuthorizedEndpoints(Type type) {
        // Üzerinde çalışılan Assembly'yi (UI) getir.
        Assembly assembly = Assembly.GetAssembly(type);

        // Assembly üzerinde çalışan, base class'ı "ControllerBase" olan sınıfları; yani controller'ları getir.
        var controllers = assembly.GetTypes().Where(t => t.IsAssignableTo(typeof(ControllerBase)));

        List<Menu> menus = new();
        if (controllers != null) {
            // Her bir controller(menu) için:
            foreach (var controller in controllers) {
                // "AuthorizeEndpointAttribute" ile işaretlenmiş metodları (action) getir.
                var actions = controller.GetMethods().Where(m => m.IsDefined(typeof(AuthorizeEndpointAttribute)));
                if (actions != null) {
                    foreach (var action in actions) {
                        var attributes = action.GetCustomAttributes(true);
                        if (attributes != null) {
                            Menu menu = null;

                            // Action'ın "AuthorizeEndpointAttribute" ile işaretlenmiş attribute'ını getir.
                            var authorizeEndpointAttribute = attributes.FirstOrDefault(a => a.GetType() == typeof(AuthorizeEndpointAttribute)) as AuthorizeEndpointAttribute;

                            // Menus içerisinde menu yoksa ekle; varsa menuyu al (Menuler ve içerdikleri actionları listelemeye çalışıyoruz.) 
                            if (!menus.Any(m => m.Name == authorizeEndpointAttribute.Menu)) {
                                menu = new() { Name = authorizeEndpointAttribute.Menu };
                                menus.Add(menu);
                            } else {
                                menu = menus.FirstOrDefault(m => m.Name == authorizeEndpointAttribute.Menu);
                            }

                            // Action oluştur.
                            C::Action _action = new() {
                                ActionType = Enum.GetName(typeof(ActionType), authorizeEndpointAttribute.ActionType),
                                Definition = authorizeEndpointAttribute.Definition,
                                Identifier = (string)authorizeEndpointAttribute.Identifier
                            };

                            // "HttpMethodAttribute" ile işaretlenmiş attribute'ı getir. Bu bize http metodunun türünü verecek. Ek bilgi olarak kullanılacak.
                            var httpAttribute = attributes.FirstOrDefault(a => a.GetType().IsAssignableTo(typeof(HttpMethodAttribute))) as HttpMethodAttribute;
                            if (httpAttribute != null) {
                                _action.HttpType = httpAttribute.HttpMethods.First();
                            } else {
                                _action.HttpType = HttpMethods.Get;

                            }
                            /*
                                ! Endpoint Kodu için açıklamalar.
                                    Bu Action için bir kod oluştur. Bu kod, kullanıcı endpointe(action)'a istek yaptığında yeniden oluşturularak veri tabanına 
                                kayıtlı kullanıcı izinleri ile karşılaştırılıp yetki vermek için var.
                                    
                                    Bu kod aynı zamanda ilgili endpointin tanımlayıcısı niteliğinde olacak. Her endpoint için bir tanımlayıcı(identifier)
                                enumlaştırarak, gerektiği yerde kullanılacak.
                                    
                                    Kullanıcının yetkiye sahip olduğu endpointler identifier'ları, kullanıcı giriş yaptığında cookie bilgilerine yazılıyor ve
                                gerektiği sayfada sadece kullanıcının görebilmesi gereken modüller gösteriliyor.

                                    Kod burada özelleştirilebilir ancak, açıklama satırında yazılan stil bir nedenden dolayı
                                kullanılmadı: Bazı sayfalarda bazen ilk GET sonra POST işleminin yapılması gerekiyor. Örneğin Update-Create gibi.
                                
                                    Bu sayfaların her iki endpointi için aynı yetki atandığında, bu iki yetkinin aynı modülü kapsaması istendiği için sadece 
                                identifier kullanıldı.
                            */

                            //_action.Code = $"{_action.Identifier}.{_action.HttpType}.{_action.ActionType}.{_action.Definition.GetSha256Hash()}";
                            _action.Code = $"{_action.Identifier}";

                            // Eğer birebir aynı "AuthorizeEndpointAttribute" ile işaretlenmiş actionlar varsa, o iki action aynı iş için beraber çalıştığından tek bir yetki gibi tanımlanacaktır.
                            if (menu.Actions.All(x => x.Code != _action.Code)) {
                                menu.Actions.Add(_action);
                            }

                        }
                    }
                }
            }
        }
        return menus;
    }

}