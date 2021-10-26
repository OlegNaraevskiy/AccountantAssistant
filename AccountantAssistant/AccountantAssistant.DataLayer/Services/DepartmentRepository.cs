/*===================================================================
 * Copyright (c) 2021 Oleg Naraevskiy                   Date: 10.2021
 * Version IDE: MS VS 2019
 * Designed by: Oleg Naraevskiy / noa.oleg96@gmail.com      [10.2021]
 *===================================================================*/

using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AccountantAssistant.DataLayer.Services
{
	public class DepartmentRepository : IRepository<Department>
	{
		private accountant_dbContext dbContext;

		public DepartmentRepository()
		{
			this.dbContext = new accountant_dbContext();
		}

		public List<Department> GetAll()
		{
			var dept = dbContext.Departments.ToList();

			return dept;
		}

		public Department GetOne(int id)
		{
			var dept = dbContext.Departments.Where(p => p.DepartmentId == id).Include(p => p.Employees).FirstOrDefault();

			return dept;
		}

		public Department Create(Department item)
		{
			dbContext.Add(item);

			var deptId = Save();

			return GetOne(deptId);
		}

		public int Delete(int id)
		{
			var dept = GetOne(id);
			
			if (dept != null && dept.DepartmentId > 0)
			{
				dbContext.Remove(dept);

				return Save();
			}
			else
			{
				return -1;
			}
		}

		public Department Update(Department item)
		{
			dbContext.Entry(item).State = EntityState.Modified;

			var deptId = Save();

			return GetOne(deptId);
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
