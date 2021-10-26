/*===================================================================
 * Copyright (c) 2021 Oleg Naraevskiy                   Date: 10.2021
 * Version IDE: MS VS 2019
 * Designed by: Oleg Naraevskiy / noa.oleg96@gmail.com      [10.2021]
 *===================================================================*/

namespace AccountantAssistant.BusinessLayer.DTO.Basic
{
	public class EmployeeDto
	{
		public int EmployeeId { get; set; }

		public string EmployeeName { get; set; }

		public decimal EmployeeSalary { get; set; }

		public DepartmentDto Department { get; set; }
	}
}
