/*===================================================================
 * Copyright (c) 2021 Oleg Naraevskiy                   Date: 10.2021
 * Version IDE: MS VS 2019
 * Designed by: Oleg Naraevskiy / noa.oleg96@gmail.com      [10.2021]
 *===================================================================*/

using AccountantAssistant.BusinessLayer.Classes;
using FluentValidation;

namespace AccountantAssistant.Validations
{
	public class EmployeeValidator : AbstractValidator<AddEmployee>
	{
		public EmployeeValidator()
		{
			RuleFor(x => x.EmployeeName).NotNull().NotEmpty().Length(1, 250);
			RuleFor(x => x.EmployeeSalary).NotNull().NotEmpty().GreaterThanOrEqualTo(1);
			RuleFor(x => x.DepartmentId).Must(BeValidDepartmentId).WithMessage("Отдел указан неверно. Необходимо создать новый отдел.");

#warning	УБРАТЬ ПРИМЕР!!!
			//RuleFor(x => x.PhoneNumber).NotEmpty().WithMessage("Please specify a phone number.");
			//RuleFor(x => x.Age).InclusiveBetween(18, 60);

			// Complex Properties
			//RuleFor(x => x.Address).InjectValidator();

			// Other way
			//RuleFor(x => x.Address).SetValidator(new AddressValidator());

			// Collections of Complex Types
			//RuleForEach(x => x.Addresses).SetValidator(new AddressValidator());
		}

		private bool BeValidDepartmentId(int? departmentId)
		{
			if (departmentId != null && departmentId < 0)
			{
				return false;
			}
			else
			{
				return true;
			}
		}
	}
}
