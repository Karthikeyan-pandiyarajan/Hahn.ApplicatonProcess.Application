using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Hahn.ApplicatonProcess.December2020.Data.Repository
{
	public class ApplicantRepository : IApplicantRepository
	{

		private ApplicationDbContext _context;

		public ApplicantRepository(ApplicationDbContext context)
		{
			_context = context;
		}

		public int InsertApplicant(Entities.Applicant applicant)
		{
			_context.Applicants.Add(applicant);
			_context.SaveChanges();
			return applicant.ID;
		}

		public Entities.Applicant GetApplicantByID(int applicantID)
		{
			return GetApplicantInformartion(applicantID);
		}
		public int UpdateApplicant(int applicantID, Entities.Applicant applicant)
		{
			var applicantToUpdate = GetApplicantInformartion(applicantID);
			if (applicantToUpdate == null)
				throw new ArgumentException();

			applicantToUpdate.Name = applicant.Name;
			applicantToUpdate.FamilyName = applicant.FamilyName;
			applicantToUpdate.EmailAddress = applicant.EmailAddress;
			applicantToUpdate.Address = applicant.Address;
			applicantToUpdate.Age = applicant.Age;
			applicantToUpdate.CountryOfOrigin = applicant.CountryOfOrigin;
			applicantToUpdate.Hired = applicant.Hired;
			applicantToUpdate.DOB = applicant.DOB;

			_context.Applicants.Update(applicantToUpdate);
			_context.SaveChanges();
			return 0;
		}
		public int DeleteApplicant(int applicantID)
		{
			var applicantToDelete = GetApplicantInformartion(applicantID);
			if (applicantToDelete == null)
				throw new ArgumentException();

			_context.Applicants.Remove(applicantToDelete);
			_context.SaveChanges();

			return 0;
		}

		private Entities.Applicant GetApplicantInformartion(int applicantID)
		{
			return _context.Applicants.FirstOrDefault(applicant => applicant.ID == applicantID);
		}

		public List<Entities.Applicant> GetApplicants()
		{
			return new List<Entities.Applicant>(_context.Applicants.AsEnumerable<Entities.Applicant>());
		}
	}
}
