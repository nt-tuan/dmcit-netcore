using DMCIT.Core.Entities.Core;
using DMCIT.Core.Entities.SupportRequests;
using DMCIT.Core.Entities.Templates;
using DMCIT.Core.Interfaces;
using DMCIT.Core.SharedKernel;
using DMCIT.Infrastructure.Data;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace DMCIT.Web
{
    public static class SeedData
    {
        static IEnumerable<Type> GetAllTypes()
        {
            var assemblies = new List<Assembly>
            {
                Assembly.GetAssembly(typeof(BaseEntity)),
                Assembly.GetAssembly(typeof(EfRepository)),
                Assembly.GetExecutingAssembly()
            };

            var allTypes = assemblies.SelectMany(u => u.GetTypes());
            return allTypes;
        }
        static async Task CreateTemplateParsers(IServiceProvider services)
        {
            try
            {
                var rep = services.GetRequiredService<ITemplateRepository>();
                var allTypes = GetAllTypes();
                var tpTypes = allTypes.Where(u => typeof(IParser).IsAssignableFrom(u) && !u.IsInterface);

                foreach (var item in tpTypes)
                {
                    var entity = new TemplateParser
                    {
                        Name = item.Name,
                        ClassName = item.AssemblyQualifiedName
                    };
                    await rep.AddTemplateParser(entity, null);
                }
            }
            catch { }
        }

        static async Task CreateTemplates(IServiceProvider services)
        {
            try
            {
                var rep = services.GetRequiredService<ITemplateRepository>();
                var allTypes = GetAllTypes();
                var parsers = allTypes.Where(u => typeof(IParser).IsAssignableFrom(u));
                var types = allTypes.Where(u => typeof(ISystemTemplate).IsAssignableFrom(u) && !u.IsAbstract);

                foreach (var type in types)
                {
                    var sysTemplate = Activator.CreateInstance(type) as ISystemTemplate;
                    var inf = type.GetInterface(typeof(ITemplate<>).Name);
                    if (inf == null)
                        continue;
                    var parser = await rep.GetTemplateParser(inf.GenericTypeArguments[0]);
                    if (parser == null)
                        continue;
                    var template = sysTemplate.Default();
                    template.TemplateTypeId = parser.Id;
                    template.TemplateType = null;
                    await rep.AddTemplate(template, null);
                }
            }
            catch { }
        }

        static async Task CreateAdminUser(IServiceProvider services, IConfiguration config)
        {
            var userManager = services.GetRequiredService<UserManager<AppUser>>();
            var roleManager = services.GetRequiredService<RoleManager<AppRole>>();
            var db = services.GetRequiredService<AppDbContext>();

            AppRole[] roles = {
                new AppRole
                {
                    Name = "admin",
                    Description = "Quản trị thông tin hệ thống"
                },
                new AppRole{
                    Name = "hr.admin",
                    Description = "Quản trị các thông tin về tổ chức và nhân sự"},
                new AppRole{
                    Name = "hr.view",
                    Description = "Xem các thông tin về tổ chức và nhân sự" },
                new AppRole{
                    Name = "sales.admin",
                    Description ="Quản lí các thông tin về kinh doanh" },
                new AppRole{
                    Name = "sales.view",
                    Description = "Xem các thông tin về kinh doanh" },
                new AppRole{
                    Name = "messaging.admin",
                    Description = "Quản lí hệ thống nhắn tin" },
                new AppRole{
                    Name = "messaging.view",
                    Description = "Xem thông tin trong hệ thống nhắn tin" },
                new AppRole{
                    Name = "workflow.admin",
                Description = "Quản trị hệ thống workflow"},
                new AppRole{
                    Name = "workflow.executor",
                    Description = "Thực thi workflow"},
                new AppRole{
                    Name = SupportRequest.MANAGER_ROLE,
                    Description = "Quản lí support request"
                }
            };

            foreach (var role in roles)
            {
                var exist = await roleManager.RoleExistsAsync(role.Name);
                if (!exist)
                {
                    await roleManager.CreateAsync(role);
                }
            }

            var username = config.GetSection("UserSettings")["Username"];
            var password = config.GetSection("UserSettings")["Password"];
            var email = config.GetSection("UserSettings")["Email"];
            var user = await userManager.FindByNameAsync(username);
            if (user == null)
            {
                var admin = new AppUser
                {
                    UserName = username,
                    Email = email
                };
                var createUser = await userManager.CreateAsync(admin, password);
                if (createUser.Succeeded)
                {
                    foreach (var role in roles)
                    {
                        await userManager.AddToRoleAsync(admin, role.Name);
                    }
                }
            }
            else
            {
                var newRoles = roles.Where(u => !userManager.IsInRoleAsync(user, u.Name).Result).Select(u => u.Name);
                await userManager.AddToRolesAsync(user, newRoles);
            }
        }
        static async Task CreateSetting(IServiceProvider services)
        {
            try
            {
                var sr = services.GetRequiredService<ISettingRepository>();
                var logger = services.GetService<ILogger<Program>>();
                logger.LogInformation("Initial default settings");
                await sr.InitialDefaultSetting();
            }
            catch { }
        }

        public static void PopulateInitData(IServiceProvider services)
        {
            IConfiguration config = services.GetRequiredService<IConfiguration>();

            //Init users and roles
            CreateAdminUser(services, config).Wait();

            //Init default setting
            CreateSetting(services).Wait();
            CreateTemplateParsers(services).Wait();
            CreateTemplates(services).Wait();

            var dbContext = services.GetRequiredService<AppDbContext>();
            if (!dbContext.ReceiverCategories.ToList().Any())
            {
                dbContext.ReceiverCategories.Add(new Core.Entities.Messaging.ReceiverCategory
                {
                    Code = "E",
                    Name = "Nhân viên"
                });
                dbContext.ReceiverCategories.Add(new Core.Entities.Messaging.ReceiverCategory
                {
                    Code = "C",
                    Name = "Khách hàng"
                });
                dbContext.SaveChanges();
            }
        }


    }
}
