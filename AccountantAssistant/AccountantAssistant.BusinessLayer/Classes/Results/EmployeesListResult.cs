/*===================================================================
 * Copyright (c) 2021 Oleg Naraevskiy                   Date: 10.2021
 * Version IDE: MS VS 2019
 * Designed by: Oleg Naraevskiy / noa.oleg96@gmail.com      [10.2021]
 *===================================================================*/

using AccountantAssistant.BusinessLayer.DTO.Basic;
using System.Collections.Generic;

namespace AccountantAssistant.BusinessLayer.Classes.Results
{
	public class EmployeesListResult : BaseResult
	{
		public List<EmployeeDto> Employees { get; set; }
	}
}
