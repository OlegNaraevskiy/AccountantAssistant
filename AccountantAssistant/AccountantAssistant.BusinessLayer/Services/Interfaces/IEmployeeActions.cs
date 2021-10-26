/*===================================================================
 * Copyright (c) 2021 Oleg Naraevskiy                   Date: 10.2021
 * Version IDE: MS VS 2019
 * Designed by: Oleg Naraevskiy / noa.oleg96@gmail.com      [10.2021]
 *===================================================================*/

using AccountantAssistant.BusinessLayer.Classes;
using AccountantAssistant.BusinessLayer.Classes.Results;
using AccountantAssistant.BusinessLayer.DTO.Basic;

namespace AccountantAssistant.BusinessLayer.Services.Interfaces
{
	public interface IEmployeeActions
	{
		public EmployeesListResult GetAll();

		public EmployeeResult Get(int Id);

		public EmployeeResult Set(AddEmployee employee);

		public EmployeeResult Update(EmployeeDto employee);

		public BaseResult Delete(int Id);
	}
}
