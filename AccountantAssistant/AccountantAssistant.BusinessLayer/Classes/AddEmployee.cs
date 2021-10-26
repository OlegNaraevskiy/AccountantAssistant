/*===================================================================
 * Copyright (c) 2021 Oleg Naraevskiy                   Date: 10.2021
 * Version IDE: MS VS 2019
 * Designed by: Oleg Naraevskiy / noa.oleg96@gmail.com      [10.2021]
 *===================================================================*/

namespace AccountantAssistant.BusinessLayer.Classes
{
	public class AddEmployee
	{
		public string EmployeeName { get; set; }

		public decimal EmployeeSalary { get; set; }

		public int? DepartmentId { get; set; }

		public AddEmployee(string employeeName, decimal employeeSalary, int departmentId)
		{
			EmployeeName = employeeName;
			EmployeeSalary = employeeSalary;
			DepartmentId = departmentId;
		}
	}
}
