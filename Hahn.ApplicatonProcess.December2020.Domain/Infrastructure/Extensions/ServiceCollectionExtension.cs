using Hahn.ApplicatonProcess.December2020.Data.Repository;
using Hahn.ApplicatonProcess.December2020.Domain.Application.Applicant;
using Hahn.ApplicatonProcess.December2020.Domain.Application.Applicant.Interfaces;
using Hahn.ApplicatonProcess.December2020.Infrastructure.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hahn.ApplicatonProcess.December2020.Infrastructure.Extensions
{
    public static class ServiceCollectionExtension
    {
		public static void AddInfrastructureServices(this IServiceCollection services)
		{
			services.AddTransient(typeof(IFacade), typeof(Facade));
			services.AddTransient(typeof(IApplicantRepository), typeof(ApplicantRepository));
			services.AddTransient(typeof(IRequestHandler), typeof(RequestHandler));			
		}
	}
}
