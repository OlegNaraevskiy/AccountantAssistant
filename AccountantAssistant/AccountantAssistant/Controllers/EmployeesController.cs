/*===================================================================
 * Copyright (c) 2021 Oleg Naraevskiy                   Date: 10.2021
 * Version IDE: MS VS 2019
 * Designed by: Oleg Naraevskiy / noa.oleg96@gmail.com      [10.2021]
 *===================================================================*/

using AccountantAssistant.BusinessLayer.Classes;
using AccountantAssistant.BusinessLayer.DTO.Basic;
using AccountantAssistant.BusinessLayer.Services;
using AccountantAssistant.BusinessLayer.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AccountantAssistant.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class EmployeesController : ControllerBase
	{
		private readonly IEmployeeActions _employeeActions;

		public EmployeesController()
		{
			_employeeActions = new EmployeeActions();
		}

		// GET: api/<EmployeesController>
		[HttpGet]
		public List<EmployeeDto> Get()
		{
			return _employeeActions.GetAll().Employees;
		}

		// GET api/<EmployeesController>/5
		[HttpGet("{id}")]
		public EmployeeDto Get(int id)
		{
			return _employeeActions.Get(id).Employee;
		}

		// POST api/<EmployeesController>
		[HttpPost]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
		[ProducesResponseType(StatusCodes.Status500InternalServerError)]
		public ActionResult<EmployeeDto> Post([FromBody] AddEmployee value)
		{
			EmployeeDto resultModel = new EmployeeDto();

			if (!ModelState.IsValid)
			{
				return BadRequest(ModelState); 
			}
			else
			{
				var employeeResult = _employeeActions.Set(value);
				
				if (employeeResult.Code == 0)
				{
					resultModel = employeeResult.Employee;

					return resultModel;
				}
				else
				{
					return new StatusCodeResult(500);
				}
			}
		}

		// PUT api/<EmployeesController>/5
		[HttpPut]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
		[ProducesResponseType(StatusCodes.Status500InternalServerError)]
		public ActionResult<EmployeeDto> Put([FromBody] EmployeeDto value)
		{
			EmployeeDto resultModel = new EmployeeDto();

			if (!ModelState.IsValid)
			{
				return BadRequest(ModelState);
			}
			else
			{
				var employee = _employeeActions.Get(value.EmployeeId);

				if (employee == null || employee.Employee == null || employee.Code != 0)
				{
					return BadRequest(ModelState);
				}

				//employee.

				var employeeResult = _employeeActions.Update(null);

				if (employeeResult.Code == 0)
				{
					resultModel = employeeResult.Employee;

					return resultModel;
				}
				else
				{
					return new StatusCodeResult(500);
				}
			}
		}

		// DELETE api/<EmployeesController>/5
		[HttpDelete("{id}")]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		public ActionResult Delete(int id)
		{
			int resCode = _employeeActions.Delete(id).Code;

			if (resCode == 0)
			{
				return Ok();
			}
			else
			{
				return NotFound();
			}
		}
	}
}
