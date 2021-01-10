using Hahn.ApplicatonProcess.December2020.Domain.Application.Dto.Model;
using Hahn.ApplicatonProcess.December2020.Domain.Application.Dto.Request;
using Hahn.ApplicatonProcess.December2020.Domain.Application.Dto.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hahn.ApplicatonProcess.December2020.Infrastructure.Interfaces
{
    public interface IFacade
    {
        int RegisterApplicant(Request<Applicant> applicantRequest);
        Response<Applicant> GetApplicantByID(int applicantID);
        int UpdateApplicant(int applicantID, Applicant applicantRequest);
        int DeleteApplicant(int applicantID);

        Response<List<Applicant>> GetApplicants();

    }
}
