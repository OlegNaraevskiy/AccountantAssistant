/*===================================================================
 * Copyright (c) 2021 Oleg Naraevskiy                   Date: 10.2021
 * Version IDE: MS VS 2019
 * Designed by: Oleg Naraevskiy / noa.oleg96@gmail.com      [10.2021]
 *===================================================================*/

using AccountantAssistant.BusinessLayer.Classes;
using AccountantAssistant.BusinessLayer.DTO;
using AccountantAssistant.BusinessLayer.DTO.Basic;
using AccountantAssistant.DataLayer;
using AutoMapper;

namespace AccountantAssistant.BusinessLayer.AutoMapper
{
	public class AutoMapperProfile : Profile
	{
		public AutoMapperProfile()
		{
			CreateMap<Department, DepartmentDto>();

			CreateMap<Employee, EmployeeDto>();

			CreateMap<AddEmployee, Employee>()
				.ForMember(dest => dest.DepartmentId, opt => opt.MapFrom(src => src.DepartmentId > 0 ? src.DepartmentId : null));

			CreateMap<EmployeeDto, Employee>()
				.ForMember(dest => dest.Department, opt => opt.MapFrom(src => new Department()
				{
					DepartmentId = src.Department != null ? src.Department.DepartmentId : 0,
					DepartmentName = src.Department != null ? src.Department.DepartmentName : null
				}));

#warning УБРАТЬ ПРИМЕР
			//CreateMap<Employee, EmployeesListResult>()
			//	.ForMember(dest => dest.Employees, opt => opt.MapFrom(src => new EmployeeDto()
			//		{
			//			EmployeeId = src.EmployeeId,
			//			EmployeeName = src.EmployeeName,
			//			EmployeeSalary = src.EmployeeSalary,
			//			//Department = src.Department ?? null
			//		}
			//	));

#warning УБРАТЬ ПРИМЕР
			//Mapper.CreateMap<Pps.AdygRegionGaz.Classes.ChargesResult, PayerInfo50Dto>()
			//	.ForMember(dest => dest.Payer, opt => opt.MapFrom(src => new Payer50Dto()
			//	{
			//		FcNumber = src.AccountNumber,
			//		Address = src.Address,
			//		Balance = src.Debit,
			//	}))
			//	.ForMember(dest => dest.Counters, opt => opt.MapFrom(src => src.IsIntake ? null : new List<PayerCounter50Dto> { new PayerCounter50Dto
			//		{
			//			PreValue = src.CounterCurrValue.GetValueOrDefault(0),
			//			LastValue = src.CounterCurrValue,
			//			CounterProviderId = src.CounterProviderId
			//		}
			//	}));
			//.ForMember(dest => dest.Counters, opt => opt.MapFrom(src => src.IsIntake ? null : new List<PayerCounter50Dto> { new PayerCounter50Dto
			//		{
			//			PreValue = src.CounterCurrValue.GetValueOrDefault(0),
			//			LastValue = src.CounterCurrValue,
			//			CounterProviderId = src.CounterProviderId
			//		}
			//	}));
		}
	}
}
