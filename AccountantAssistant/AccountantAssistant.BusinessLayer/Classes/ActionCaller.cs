/*===================================================================
 * Copyright (c) 2021 Oleg Naraevskiy                   Date: 10.2021
 * Version IDE: MS VS 2019
 * Designed by: Oleg Naraevskiy / noa.oleg96@gmail.com      [10.2021]
 *===================================================================*/

using AccountantAssistant.BusinessLayer.Classes.Results;
using System;

namespace AccountantAssistant.BusinessLayer.Classes
{
	public class ActionCaller
	{
		public static T CallMethod<T>(Func<T> action)
			where T : BaseResult
		{
			T result = (T)Activator.CreateInstance(typeof(T));

			try
			{
				result = action();
			}
			catch (Exception ex)
			{
				result.Code = -1;
				result.Message = "Error";
				result.ExceptionDetails = ex;
			}

			return result;
		}
	}
}
