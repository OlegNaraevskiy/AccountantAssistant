/*===================================================================
 * Copyright (c) 2021 Oleg Naraevskiy                   Date: 10.2021
 * Version IDE: MS VS 2019
 * Designed by: Oleg Naraevskiy / noa.oleg96@gmail.com      [10.2021]
 *===================================================================*/

using System;

namespace AccountantAssistant.BusinessLayer.Classes.Results
{
	public class BaseResult
	{
		public int Code { get; set; }

		public string Message { get; set; }

		public Exception ExceptionDetails { get; set; }

		public BaseResult()
		{
			Code = -1;
			Message = "Неизвестная ошибка";
			ExceptionDetails = null;
		}

		public BaseResult(int code, string message, Exception exceptionDetails)
		{
			Code = code;
			Message = message;
			ExceptionDetails = exceptionDetails;
		}
	}
}
