/*===================================================================
 * Copyright (c) 2021 Oleg Naraevskiy                   Date: 10.2021
 * Version IDE: MS VS 2019
 * Designed by: Oleg Naraevskiy / noa.oleg96@gmail.com      [10.2021]
 *===================================================================*/

using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AccountantAssistant.DataLayer.Services
{
	public class EmployeerRepository : IRepository<Employee>
	{
		private readonly accountant_dbContext dbContext;

		public EmployeerRepository()
		{
			this.dbContext = new accountant_dbContext();
		}

		public List<Employee> GetAll()
		{
			var employeers = dbContext.Employees.Include(p => p.Department).ToList();

			return employeers;
		}

		public Employee GetOne(int id)
		{
			var employeer = dbContext.Employees
				.Where(o => o.EmployeeId == id)
				.Include(p => p.Department).FirstOrDefault();

			return employeer;
		}

		public Employee Create(Employee item)
		{
			dbContext.Add(item);
			Save();

			return GetOne(item.EmployeeId);
		}

		public int Delete(int id)
		{
			var employeer = GetOne(id);

			if (employeer != null && employeer.EmployeeId != 0)
			{
				dbContext.Remove(employeer);

				return Save();
			}
			else
			{
				return -1;
			}
		}

		public Employee Update(Employee item)
		{
			dbContext.Entry(item).State = EntityState.Modified;

			var employeerId = Save();

			return GetOne(employeerId);
		}

		public int Save()
		{
			return dbContext.SaveChanges();
		}
		
		#region Disposing
		private bool disposed = false;

		public virtual void Dispose(bool disposing)
		{
			if (!this.disposed)
			{
				if (disposing)
				{
					dbContext.Dispose();
				}
			}
			this.disposed = true;
		}

		public void Dispose()
		{
			Dispose(true);
			GC.SuppressFinalize(this);
		}
		#endregion
	}
}
