using Hahn.ApplicatonProcess.December2020.Data.Repository;
using Hahn.ApplicatonProcess.December2020.Domain.Application.Applicant.Interfaces;
using Hahn.ApplicatonProcess.December2020.Domain.Application.Dto.Request;
using Hahn.ApplicatonProcess.December2020.Domain.Application.Dto.Response;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hahn.ApplicatonProcess.December2020.Domain.Application.Applicant
{
	public class RequestHandler : IRequestHandler
	{
		private readonly IApplicantRepository _applicantRepository;

		public RequestHandler(IApplicantRepository applicantRepository)
		{
			_applicantRepository = applicantRepository ?? throw new ArgumentNullException("applicantRepository");
		}

		public int RegisterApplicant(Request<Dto.Model.Applicant> applicantRequest)
		{
			var result = _applicantRepository.InsertApplicant(applicantRequest.Data.MapToData());

			return result;
		}

		public Response<Dto.Model.Applicant> GetApplicantByID(int applicantID)
		{
			var result = _applicantRepository.GetApplicantByID(applicantID);

			if (result == null)
			{
				throw new ArgumentException("No applicants were found");
			}

			var applicant = result.MapToDto();
			return new Response<Dto.Model.Applicant>() { Data = applicant };
		}

		public Response<List<Dto.Model.Applicant>> GetApplicants()
		{
			var applicants = _applicantRepository.GetApplicants().MapToDtos();
			return new Response<List<Dto.Model.Applicant>>() { Data = applicants };
		}

		public int UpdateApplicant(int applicantID, Dto.Model.Applicant applicant)
		{
			return _applicantRepository.UpdateApplicant(applicantID, applicant.MapToData());
		}

		public int DeleteApplicant(int applicantID)
		{
			return _applicantRepository.DeleteApplicant(applicantID);
		}

	}
}
