using FluentValidation.Results;
using Hahn.ApplicatonProcess.December2020.Domain.Application.Dto.Model;
using Hahn.ApplicatonProcess.December2020.Domain.Application.Dto.Request;
using Hahn.ApplicatonProcess.December2020.Domain.Application.Dto.Response;
using Hahn.ApplicatonProcess.December2020.Domain.Validation;
using Hahn.ApplicatonProcess.December2020.Infrastructure.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace Hahn.ApplicatonProcess.December2020.Web.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class ApplicantController : ControllerBase
	{
		private readonly ILogger<ApplicantController> _logger;
		private readonly IFacade _facade;

		public ApplicantController(ILogger<ApplicantController> logger, IFacade facade)
		{
			_logger = logger;
			_facade = facade;
		}

		[HttpPost]
		//[Consumes("application/x-www-form-urlencoded")]
		public ActionResult Post(Domain.Application.Dto.Request.Request<Applicant> json)
		{
			//var json = JsonConvert.DeserializeObject<Domain.Application.Dto.Request.Request<Applicant>>(value);
			ValidateApplicant validateApplicant = new ValidateApplicant();
			ValidationResult validationResult = validateApplicant.Validate(json.Data);

			if (!validationResult.IsValid)
			{
				var errors = new List<ValidationErrorResponse>();
				foreach(ValidationFailure result in validationResult.Errors)
				{
					errors.Add(new ValidationErrorResponse()
					{
						propertyName = result.PropertyName,
						ErrorMessage = result.ErrorMessage
					});
				}

				Response<List<ValidationErrorResponse>> errorResponse = new Response<List<ValidationErrorResponse>> { Data = errors };
				return StatusCode((int)HttpStatusCode.BadRequest, errorResponse);
			}

			var registeredId = _facade.RegisterApplicant(json);
			string getUrl = "https://localhost:5001/Applicant/";
			string url = string.Format("{0}{1}", getUrl, registeredId);
			Response<AddResponse> response = new Response<AddResponse>() { Data = new AddResponse() { Url = url} };
			return CreatedAtAction(nameof(GetApplicant), new { id = registeredId }, response);
		}

		[HttpGet("{id}")]
		public ActionResult GetApplicant(int id)
		{
			try
			{				
				return Ok(_facade.GetApplicantByID(id));
			}
			catch
			{
				string message = string.Format("No applicants were found with specified id: {0}", id);
				return StatusCode((int)HttpStatusCode.BadRequest, new Response<string>() { Data = message });
			}
			
		}

		[HttpGet()]
		public ActionResult GetApplicants()
		{
			try
			{
				return Ok(_facade.GetApplicants());
			}
			catch
			{
				string message = string.Format("No applicants were found");
				return StatusCode((int)HttpStatusCode.BadRequest, new Response<string>() { Data = message });
			}

		}

		[HttpPut("{id}")]
		public ActionResult UpdateApplicant(int id, [FromBody] Applicant applicant)
		{

			try
			{
				ValidateApplicant validateApplicant = new ValidateApplicant();
				ValidationResult validationResult = validateApplicant.Validate(applicant);

				if (!validationResult.IsValid)
				{
					var errors = new List<ValidationErrorResponse>();
					foreach (ValidationFailure result in validationResult.Errors)
					{
						errors.Add(new ValidationErrorResponse()
						{
							propertyName = result.PropertyName,
							ErrorMessage = result.ErrorMessage
						});
					}

					Response<List<ValidationErrorResponse>> errorResponse = new Response<List<ValidationErrorResponse>> { Data = errors };
					return StatusCode((int)HttpStatusCode.BadRequest, errorResponse);
				}

				return Ok(_facade.UpdateApplicant(id, applicant));
			}
			catch
			{
				string message = string.Format("Unable to update applicant with specified id: {0}", id);
				return StatusCode((int)HttpStatusCode.BadRequest, new Response<string>() { Data = message });
			}
		}

		[HttpDelete("{id}")]
		public ActionResult DeleteApplicant(int id)
		{
			try
			{
				_facade.DeleteApplicant(id);
			}
			catch
			{
				string message = string.Format("unable to delete applicant with specified id: {0}", id);
				return StatusCode((int)HttpStatusCode.BadRequest, new Response<string>() { Data = message });
			}

			return new NoContentResult();
		}
	}
}
