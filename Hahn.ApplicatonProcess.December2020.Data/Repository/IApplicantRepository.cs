using System;
using System.Collections.Generic;
using System.Text;

namespace Hahn.ApplicatonProcess.December2020.Data.Repository
{
	public interface IApplicantRepository
	{
		int InsertApplicant(Entities.Applicant applicant);
		Entities.Applicant GetApplicantByID(int applicantID);
		int UpdateApplicant(int applicantID, Entities.Applicant applicant);
		int DeleteApplicant(int applicantID);
		
		List<Entities.Applicant> GetApplicants();
	}
}
