internal class Program {
    private static void Main(string[] args) {
        //! BUILDER----------------------------------------------------------------------------------------------------
        var builder = WebApplication.CreateBuilder(args);
        #region Builder
        
        #region Add Environment Variables 
        /*
            Uygulamayı publish ettiğimizde -sırasıyla- nerelerden ortam değişkeni okuyacağınızı belirlersiniz. 1-appsettings.json, 2-Ortam değişkenleri
        */
        if (builder.Environment.IsDevelopment()) {
            builder.Configuration.AddJsonFile("appsettings.Development.json", false, true);
            Console.WriteLine("Development Settings Activated");
        }
        else {
            builder.Configuration.AddJsonFile("appsettings.json", false, true);
            Console.WriteLine("Production Settings Activated");
        }
        builder.Configuration.AddEnvironmentVariables(); // "ConnectionStrings__Default" gibi dışarıdan değer alabilmek için ayar
        #endregion
        
        
        
        //! APPLICATION------------------------------------------------------------------------------------------------
        var app = builder.Build();
        

        // Configure the HTTP request pipeline.
        if (!app.Environment.IsDevelopment()) {
            app.UseExceptionHandler("/Error");
            // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
            app.UseHsts();
        }

        app.UseHttpsRedirection();
        app.UseStaticFiles();

        app.UseRouting();

        app.UseAuthorization();

        app.Run();
    }
}

#region Add Environment Variables 

#endregion
