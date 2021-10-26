/*===================================================================
 * Copyright (c) 2021 Oleg Naraevskiy                   Date: 10.2021
 * Version IDE: MS VS 2019
 * Designed by: Oleg Naraevskiy / noa.oleg96@gmail.com      [10.2021]
 *===================================================================*/

using AccountantAssistant.BusinessLayer.Classes.Results;
using AccountantAssistant.BusinessLayer.DTO.Basic;
using System.Collections.Generic;

namespace AccountantAssistant.BusinessLayer.Services.Interfaces
{
	public interface IDepartmentActions
	{
		public List<DepartmentDto> GetAll();

		public DepartmentDto Get(int Id);

		public DepartmentDto Set(DepartmentDto employee);

		public DepartmentDto Update(DepartmentDto employee);

		public BaseResult Delete(int Id);
	}
}
