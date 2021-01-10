using Hahn.ApplicatonProcess.December2020.Domain.Application.Applicant.Interfaces;
using Hahn.ApplicatonProcess.December2020.Domain.Application.Dto.Model;
using Hahn.ApplicatonProcess.December2020.Domain.Application.Dto.Request;
using Hahn.ApplicatonProcess.December2020.Domain.Application.Dto.Response;
using Hahn.ApplicatonProcess.December2020.Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hahn.ApplicatonProcess.December2020.Infrastructure
{
	public class Facade : IFacade
	{
		private readonly IRequestHandler _applicantRequestHandler;
		public Facade(IRequestHandler applicantRequestHandler)
		{
			_applicantRequestHandler = applicantRequestHandler;
		}

		public int RegisterApplicant(Request<Applicant> applicantRequest)
		{
			return _applicantRequestHandler.RegisterApplicant(applicantRequest);
		}

		public Response<Applicant> GetApplicantByID(int applicantID)
		{
			return _applicantRequestHandler.GetApplicantByID(applicantID);
		}
		public int UpdateApplicant(int applicantID, Applicant applicant)
		{
			return _applicantRequestHandler.UpdateApplicant(applicantID, applicant);
		}

		public int DeleteApplicant(int applicantID)
		{
			return _applicantRequestHandler.DeleteApplicant(applicantID);
		}

		public Response<List<Applicant>> GetApplicants()
		{
			return _applicantRequestHandler.GetApplicants();
		}
	}
}
