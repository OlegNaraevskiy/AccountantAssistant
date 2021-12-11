/*===================================================================
 * Copyright (c) 2021 Oleg Naraevskiy                   Date: 10.2021
 * Version IDE: MS VS 2019
 * Designed by: Oleg Naraevskiy / noa.oleg96@gmail.com      [10.2021]
 *===================================================================*/

namespace AccountantAssistant.BusinessLayer.Classes
{
	public class EditEmployee : AddEmployee
	{
		public int EmployeeId { get; set; }

		public EditEmployee(int employeeId, string employeeName, decimal employeeSalary, int departmentId) : base(employeeName, employeeSalary, departmentId)
		{
			EmployeeId = employeeId;
			EmployeeName = employeeName;
			EmployeeSalary = employeeSalary;
			DepartmentId = departmentId;
		}
	}
}
