/*===================================================================
 * Copyright (c) 2021 Oleg Naraevskiy                   Date: 10.2021
 * Version IDE: MS VS 2019
 * Designed by: Oleg Naraevskiy / noa.oleg96@gmail.com      [10.2021]
 *===================================================================*/

using FluentValidation;

namespace AccountantAssistant.Validations
{
	public class DepartmentValidator //: AbstractValidator<AddDepartmentModel>
	{
		public DepartmentValidator()
		{
			//RuleFor(x => x.DepartmentName).NotNull().NotEmpty().Length(1, 250);
		}
	}
}
