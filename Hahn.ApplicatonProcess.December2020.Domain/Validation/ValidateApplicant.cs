using FluentValidation;
using Hahn.ApplicatonProcess.December2020.Domain.Application.Dto.Model;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;

namespace Hahn.ApplicatonProcess.December2020.Domain.Validation
{
	public class ValidateApplicant : AbstractValidator<Applicant>
	{
		private const string uri = "https://restcountries.eu/rest/v2/name/";
		public ValidateApplicant()
		{
			RuleFor(x => x.Name).Must(ValidateName).WithMessage("Applicant Name is at least 5 Characters");
			RuleFor(x => x.FamilyName).Must(ValidateName).WithMessage("Applicant Family Name is at least 5 Characters");
			RuleFor(x => x.Address).Must(ValidateAddress).WithMessage("Applicant Address is at least 10 Characters");
			RuleFor(x => x.CountryOfOrigin).Must(CountryOfOrigin).WithMessage("The country is not valid");
			RuleFor(x => x.EmailAddress).EmailAddress().WithMessage("Email Address is not correct");
			RuleFor(x => x.Age).Must(ValidateAge).WithMessage("Age – must be between 20 and 60");
		}

		private bool ValidateName(string name)
		{
			return name.Length >= 5;
		}

		private bool ValidateAddress(string address)
		{
			return address.Length >= 10;
		}

		private bool ValidateAge(int age)
		{
			return (age >= 20 || age <= 60);
		}

		private bool CountryOfOrigin(string orgin)
		{

			using (var client = new HttpClient())
			{
				client.BaseAddress = new Uri(string.Format("{0}{1}?fullText=true", uri, orgin));
				client.DefaultRequestHeaders.Accept.Clear();
				client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
				HttpResponseMessage response = client.GetAsync("").Result;
				return response.IsSuccessStatusCode;
			}
		}
	}
}
