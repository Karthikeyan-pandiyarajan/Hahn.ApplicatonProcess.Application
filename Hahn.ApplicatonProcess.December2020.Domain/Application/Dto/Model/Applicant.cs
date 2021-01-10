using System;
using System.Collections.Generic;
using System.Text;

namespace Hahn.ApplicatonProcess.December2020.Domain.Application.Dto.Model
{
	public class Applicant
	{
		/// <summary>
		/// Unique ID of the applicant
		/// </summary>
		public int ID { get; set; }

		/// <summary>
		/// Name of the applicant
		/// </summary>
		public string Name { get; set; }

		/// <summary>
		/// FamilyName of the applicant
		/// </summary>
		public string FamilyName { get; set; }

		/// <summary>
		/// Address of the applicant
		/// </summary>
		public string Address { get; set; }

		/// <summary>
		/// Country of the applicant
		/// </summary>
		public string CountryOfOrigin { get; set; }

		/// <summary>
		/// Email address of the applicant
		/// </summary>
		public string EmailAddress { get; set; }

		/// <summary>
		/// Age of the applicant
		/// </summary>
		public int Age { get; set; }

		public bool? Hired { get; set; }

		public string? DOB { get; set; }
	}
}
