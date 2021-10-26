/*===================================================================
 * Copyright (c) 2021 Oleg Naraevskiy                   Date: 10.2021
 * Version IDE: MS VS 2019
 * Designed by: Oleg Naraevskiy / noa.oleg96@gmail.com      [10.2021]
 *===================================================================*/

using System;
using System.Collections.Generic;

namespace AccountantAssistant.DataLayer.Services
{
	public interface IRepository<T> : IDisposable 
		where T : class
	{
		public List<T> GetAll();

		public T GetOne(int id);

		public T Create(T item);

		public T Update(T item);

		public int Delete(int id);

		public int Save(); 
	}
}
