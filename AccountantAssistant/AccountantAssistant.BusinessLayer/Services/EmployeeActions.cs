/*===================================================================
 * Copyright (c) 2021 Oleg Naraevskiy                   Date: 10.2021
 * Version IDE: MS VS 2019
 * Designed by: Oleg Naraevskiy / noa.oleg96@gmail.com      [10.2021]
 *===================================================================*/

using AccountantAssistant.BusinessLayer.AutoMapper;
using AccountantAssistant.BusinessLayer.Classes;
using AccountantAssistant.BusinessLayer.Classes.Results;
using AccountantAssistant.BusinessLayer.DTO.Basic;
using AccountantAssistant.BusinessLayer.Services.Interfaces;
using AccountantAssistant.DataLayer;
using AccountantAssistant.DataLayer.Services;
using System.Collections.Generic;

namespace AccountantAssistant.BusinessLayer.Services
{
	public class EmployeeActions : ActionCaller, IEmployeeActions
	{
		private readonly IRepository<Employee> _employeeDb;
		private readonly IRepository<Department> _departmentDb;

		public EmployeeActions()
		{
			_employeeDb = new EmployeerRepository();
			_departmentDb = new DepartmentRepository();
		}

		public EmployeesListResult GetAll()
		{
			EmployeesListResult result = CallMethod<EmployeesListResult>(
			() => {
				EmployeesListResult resAction = new EmployeesListResult();

				List<EmployeeDto> employees = null;

				using (_employeeDb)
				{
					employees = SMapper.Mapper.Map<List<EmployeeDto>>(_employeeDb.GetAll());
				}

				if (employees != null && employees.Count > 0)
				{
					resAction.Code = 0;
					resAction.Message = "Успех";

					resAction.Employees = employees;
				}
				else
				{
					resAction.Code = 1;
					resAction.Message = "Данные отсутствуют";
				}

				return resAction;
			});

			return result;
		}

		public EmployeeResult Get(int Id)
		{
			EmployeeResult result = CallMethod<EmployeeResult>(
			() => {
				EmployeeResult resAction = new EmployeeResult();

				EmployeeDto employeer = null;

				using (_employeeDb)
				{
					employeer = SMapper.Mapper.Map<EmployeeDto>(_employeeDb.GetOne(Id));
				}

				if (employeer != null && employeer.EmployeeId > 0)
				{
					resAction.Code = 0;
					resAction.Message = "Успех";

					resAction.Employee = employeer;
				}
				else
				{
					resAction.Code = 1;
					resAction.Message = "Данные отсутствуют";
				}

				return resAction;
			});

			return result;
		}

		public BaseResult Delete(int Id)
		{
			BaseResult result = CallMethod<BaseResult>(
			() => {
				BaseResult resAction = new BaseResult();

				using (_employeeDb)
				{
					resAction.Code = _employeeDb.Delete(Id);
				}

				if (resAction.Code == 1)
				{
					resAction.Message = "Успех";
				}
				else
				{
					resAction.Message = "Ошибка при удалении";
				}

				return resAction;
			});

			return result;
		}

		public EmployeeResult Set(AddEmployee employee)
		{
			EmployeeResult result = CallMethod<EmployeeResult>(
			() => {
				EmployeeResult resAction = new EmployeeResult();

				EmployeeDto resEmployee = null;

				using (_employeeDb)
				{
					Employee dEmployee = SMapper.Mapper.Map<Employee>(employee);

					var addEmplresult = _employeeDb.Create(dEmployee);

					resEmployee = SMapper.Mapper.Map<EmployeeDto>(addEmplresult);
				}

				if (resEmployee != null && resEmployee.EmployeeId > 0)
				{
					resAction.Code = 0;
					resAction.Message = "Успех";

					resAction.Employee = resEmployee;
				}
				else
				{
					resAction.Code = 1;
					resAction.Message = "Данные не записаны";
				}

				return resAction;
			});

			return result;
		}

		public EmployeeResult Update(EmployeeDto employee)
		{
			throw new System.NotImplementedException();
		}
	}
}
