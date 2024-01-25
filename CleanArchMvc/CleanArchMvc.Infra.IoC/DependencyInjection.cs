using CleanArchMvc.Domain.Interfaces;
using CleanArchMvc.Infra.Data.Context;
using CleanArchMvc.Infra.Data.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchMvc.Infra.IoC
{
	public static class DependencyInjection
	{
		public static IServiceCollection AddInfrastructure(this IServiceCollection services, 
			IConfiguration configuration ) 
		{							//registro do contexto ApplicantionDBContext
			services.AddDbContext<ApplicationDBContext>(options =>
				options.UseSqlServer(configuration //Definição do provedor do banco de dados
				.GetConnectionString("DefaultConnection"), //Definição da string de conexão
				b => b.MigrationsAssembly(typeof(ApplicationDBContext).Assembly.FullName))); //migração para onde está definido meu arquivo de contexto

			services.AddScoped<IProductRepository, ProductRepository>();
			services.AddScoped<ICategoryRepository, CategoryRepository>();

			return services;
		}
	}
}
