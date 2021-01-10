using Hahn.ApplicatonProcess.December2020.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hahn.ApplicatonProcess.December2020.Domain.Application.Applicant
{
    public static class Mapper
    {
        public static Data.Entities.Applicant MapToData(this Dto.Model.Applicant applicant)
        {
            return new Data.Entities.Applicant()
            {
                Name = applicant.Name,
                FamilyName = applicant.FamilyName,
                Address = applicant.Address,
                EmailAddress = applicant.EmailAddress,
                Age = applicant.Age,
                CountryOfOrigin = applicant.CountryOfOrigin,
                Hired = applicant.Hired,
                DOB = applicant.DOB
            };
        }

		public static Dto.Model.Applicant MapToDto(this Data.Entities.Applicant applicant)
		{
			return new Dto.Model.Applicant()
			{
                ID = applicant.ID,
                Name = applicant.Name,
                FamilyName = applicant.FamilyName,
                Address = applicant.Address,
                EmailAddress = applicant.EmailAddress,
                Age = applicant.Age,
                CountryOfOrigin = applicant.CountryOfOrigin,
                Hired = applicant.Hired,
                DOB = applicant.DOB
            };
		}

        public static List<Dto.Model.Applicant> MapToDtos(this List<Data.Entities.Applicant> applicants)
        {
            var items = new List<Dto.Model.Applicant>();
            foreach(var applicant in applicants)
			{
                items.Add(new Dto.Model.Applicant()
                {
                    ID = applicant.ID,
                    Name = applicant.Name,
                    FamilyName = applicant.FamilyName,
                    Address = applicant.Address,
                    EmailAddress = applicant.EmailAddress,
                    Age = applicant.Age,
                    CountryOfOrigin = applicant.CountryOfOrigin,
                    Hired = applicant.Hired,
                    DOB = applicant.DOB
                });
			}

            return items;
        }
    }
}
