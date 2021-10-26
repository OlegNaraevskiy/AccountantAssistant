/*===================================================================
 * Copyright (c) 2021 Oleg Naraevskiy                   Date: 10.2021
 * Version IDE: MS VS 2019
 * Designed by: Oleg Naraevskiy / noa.oleg96@gmail.com      [10.2021]
 *===================================================================*/

using Microsoft.EntityFrameworkCore;

#nullable disable

namespace AccountantAssistant.DataLayer
{
	public partial class accountant_dbContext : DbContext
	{
		public accountant_dbContext()
		{
		}

		public accountant_dbContext(DbContextOptions<accountant_dbContext> options)
			: base(options)
		{
		}

		public virtual DbSet<Department> Departments { get; set; }
		public virtual DbSet<Employee> Employees { get; set; }

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			if (!optionsBuilder.IsConfigured)
			{
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
				optionsBuilder.UseSqlServer("Server=PC-N7\\SQLEXPRESS;Database=accountant_db;Trusted_Connection=True;");
			}
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.HasAnnotation("Relational:Collation", "Cyrillic_General_CI_AS");

			modelBuilder.Entity<Department>(entity =>
			{
				entity.ToTable("Department");

				entity.Property(e => e.DepartmentId).HasColumnName("department_id");

				entity.Property(e => e.DepartmentName)
					.HasMaxLength(250)
					.HasColumnName("department_name");
			});

			modelBuilder.Entity<Employee>(entity =>
			{
				entity.ToTable("Employee");

				entity.Property(e => e.EmployeeId).HasColumnName("employee_id");

				entity.Property(e => e.DepartmentId).HasColumnName("department_id");

				entity.Property(e => e.EmployeeName)
					.HasMaxLength(250)
					.HasColumnName("employee_name");

				entity.Property(e => e.EmployeeSalary)
					.HasColumnType("money")
					.HasColumnName("employee_salary");

				entity.HasOne(d => d.Department)
					.WithMany(p => p.Employees)
					.HasForeignKey(d => d.DepartmentId)
					.HasConstraintName("FK_Employee_Department");
			});

			OnModelCreatingPartial(modelBuilder);
		}

		partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
	}
}
