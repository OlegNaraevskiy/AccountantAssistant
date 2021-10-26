/*===================================================================
 * Copyright (c) 2021 Oleg Naraevskiy                   Date: 10.2021
 * Version IDE: MS VS 2019
 * Designed by: Oleg Naraevskiy / noa.oleg96@gmail.com      [10.2021]
 *===================================================================*/

using AutoMapper;
using System;

namespace AccountantAssistant.BusinessLayer.AutoMapper
{
	public static class SMapper 
	{
		private static readonly Lazy<IMapper> _instance = new Lazy<IMapper>(() => 
		{
			var config = new MapperConfiguration(cfg => {
				cfg.ShouldMapProperty = p => p.GetMethod.IsPublic || p.GetMethod.IsAssembly;
				cfg.AddProfile<AutoMapperProfile>();
			});

			var mapper = config.CreateMapper();

			return mapper;
		});

		public static IMapper Mapper { get { return _instance.Value; } }
	}
}
