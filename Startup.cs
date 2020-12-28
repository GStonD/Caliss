using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Data.Sqlite;
using System.IO;

namespace testx
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            createDB();
            Configuration = configuration;
                }
        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;

            });
            var dbcon = Configuration.GetValue<String>("dbFilename");
            services.AddTransient<ContactoSQLiteRepository>(s =>
            {
                return new ContactoSQLiteRepository("Filename=app.db");

            });



            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/MenuContacto/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();

            app.UseMvc(routes =>
            {
                routes.MapRoute(

                    name: "Index",
                    template: "{controller=MenuContacto}/{action=Index}/{id?}");
                routes.MapRoute(
                  name: "Details",
                  template: "{controller=MenuContacto}/{action=Details}/{id?}");
                routes.MapRoute(
                   name: "Create",
                   template: "{controller=MenuContacto}/{action=Create}/{id?}");
                routes.MapRoute(
                   name: "Delete",
                   template: "{controller=MenuContacto}/{action=Delete}/{id?}");
                routes.MapRoute(
                  name: "Edit",
                  template: "{controller=MenuContacto}/{action=Edit}/{id?}");
                    








        });


        }
       public void createDB()
        {

            using (SqliteConnection db =

               new SqliteConnection("Filename=app.db"))
            {
                db.Open();

                String tableCommand = " CREATE TABLE IF NOT " +
                    "EXISTS PROSPECTO ( ID INTEGER not null  , NOMBRE  varchar(200)  not null  , PRIMER_APELLIDO  varchar(200)  not null  , SEGUNDO_APELLIDO  varchar(200) not null  , CALLE varchar(200)  not null , NUMERO INTEGER not null , COLONIA varchar(200) not  null, CODIGO_POSTAL varchar(200)  not null , TELEFONO INTEGER not null , RFC varchar(200)  not null " +
                    " )";


                SqliteCommand CreateTable = new SqliteCommand(tableCommand, db);
                CreateTable.ExecuteReader();



                 String tableCommand2 = " CREATE TABLE IF NOT " + "EXISTS DOCUMENTO (ID INTEGER  not null ,ID2 INTEGER not null ,NOMBRE_DEL_DOCUMENTO  varchar(200)  not null  , NOMBRE  varchar(200) not null  ,PRIMER_APELLIDO varchar(200) not null ,SEGUNDO_APELLIDO varchar(200) not null , ESTATUS varchar(200)  not null ,  CALLE varchar(200) not null  , NUMERO INTEGER not null  , COLONIA varchar(200) , CODIGO_POSTAL varchar(200) not null  , TELEFONO INTEGER not null , RFC varchar(200) not null  , OBSERVACIONES varchar(200) not null   )";

                SqliteCommand CreateTable2 = new SqliteCommand(tableCommand2, db);
                CreateTable2.ExecuteReader();


                


                
            }

 
            }
        }
    }

