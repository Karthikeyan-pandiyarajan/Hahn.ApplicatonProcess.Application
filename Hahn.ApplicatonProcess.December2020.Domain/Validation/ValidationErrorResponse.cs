using System;
using System.Collections.Generic;
using System.Text;

namespace Hahn.ApplicatonProcess.December2020.Domain.Validation
{
	public class ValidationErrorResponse
	{
		public string propertyName { get; set; }
		public string ErrorMessage { get; set; }
	}
}
