using Hahn.ApplicatonProcess.December2020.Domain.Application.Dto.Request;
using Hahn.ApplicatonProcess.December2020.Domain.Application.Dto.Response;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hahn.ApplicatonProcess.December2020.Domain.Application.Applicant.Interfaces
{
	public interface IRequestHandler
	{
		int RegisterApplicant(Request<Dto.Model.Applicant> productRequest);
		Response<Dto.Model.Applicant> GetApplicantByID(int applicantID);
		int UpdateApplicant(int id, Dto.Model.Applicant applicant);
		int DeleteApplicant(int applicantID);

		Response<List<Dto.Model.Applicant>> GetApplicants();
	}
}
