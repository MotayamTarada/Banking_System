using Hope.Repositories;
using Hope.Repositories.IRepository;
using Hope.Repositories.Repository;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hope.IOC
{
    public static class IOContainer
    {

        public static void ConfigureIOC(this IServiceCollection services)
        {
             services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddScoped<INationalityRepository, NationalityRepository>();
            services.AddScoped<IEmployeeRepository, EmployeeRepository>();
            services.AddScoped<IQualificationRepository, QualificationRepository>();
            services.AddScoped<IClientRepository, ClientRepository>();
            services.AddScoped<IAccountTypeRepository,AccountTypeRepository>();
            services.AddScoped<IAccountOpeningRepository, AccountOpeningRepository>();
            services.AddScoped<IErrorLogRepository, ErrorLogRepository>();
            services.AddScoped<ILoanRepository, LoanRepository>();
            services.AddScoped<ILoanTypeRepository, LoanTypeRepository>();
            services.AddScoped<IModuleRepository, ModuleRepository>();
            services.AddScoped<IRoleModuleRepository, RoleModuleRepository>();
            services.AddScoped<IRoleRepository, RoleRepository>();
            services.AddScoped<IRoleUserRepository, RoleUserRepository>();
        }
    }
}
