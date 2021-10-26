/*===================================================================
 * Copyright (c) 2021 Oleg Naraevskiy                   Date: 10.2021
 * Version IDE: MS VS 2019
 * Designed by: Oleg Naraevskiy / noa.oleg96@gmail.com      [10.2021]
 *===================================================================*/

using Microsoft.EntityFrameworkCore.Migrations;

namespace AccountantAssistant.DataLayer.Migrations
{
    public partial class AddInitialData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"SET IDENTITY_INSERT[dbo].[Department] ON
                                    INSERT[dbo].[Department]([department_id], [department_name]) VALUES(1, N'Юридический отдел')
                                    INSERT[dbo].[Department]([department_id], [department_name]) VALUES(2, N'Отдел кадров')
                                    INSERT[dbo].[Department]([department_id], [department_name]) VALUES(3, N'Отдел продаж')
                                    INSERT[dbo].[Department]([department_id], [department_name]) VALUES(4, N'IT отдел')
                                    INSERT[dbo].[Department]([department_id], [department_name]) VALUES(5, N'Бухгалтерия')
                                    INSERT[dbo].[Department]([department_id], [department_name]) VALUES(6, N'Отдел технической поддержки')
                                    SET IDENTITY_INSERT[dbo].[Department] OFF
                                    GO", true);

            migrationBuilder.Sql(@"SET IDENTITY_INSERT [dbo].[Employee] ON 
                                    INSERT [dbo].[Employee] ([employee_id], [employee_name], [employee_salary], [department_id]) VALUES (1, N'Иванов Иван Иванович', 10000.0000, 1)
                                    INSERT [dbo].[Employee] ([employee_id], [employee_name], [employee_salary], [department_id]) VALUES (2, N'Васильев Василий Васильевич', 25000.0000, 1)
                                    INSERT [dbo].[Employee] ([employee_id], [employee_name], [employee_salary], [department_id]) VALUES (3, N'Сергеев Сергей Сергеевич', 15000.0000, 1)
                                    INSERT [dbo].[Employee] ([employee_id], [employee_name], [employee_salary], [department_id]) VALUES (4, N'Антонов Антон Антонович', 25000.0000, 5)
                                    INSERT [dbo].[Employee] ([employee_id], [employee_name], [employee_salary], [department_id]) VALUES (5, N'Оксанова Оксана Олеговна', 30000.0000, 5)
                                    INSERT [dbo].[Employee] ([employee_id], [employee_name], [employee_salary], [department_id]) VALUES (6, N'Ильяшук Иван Игоревич', 40000.0000, 2)
                                    INSERT [dbo].[Employee] ([employee_id], [employee_name], [employee_salary], [department_id]) VALUES (7, N'Ворукова Ольга Александровна', 70000.0000, 2)
                                    INSERT [dbo].[Employee] ([employee_id], [employee_name], [employee_salary], [department_id]) VALUES (8, N'Гаврилов Тарас Иванович', 27000.0000, 3)
                                    INSERT [dbo].[Employee] ([employee_id], [employee_name], [employee_salary], [department_id]) VALUES (9, N'Работник_1', 24000.0000, 3)
                                    INSERT [dbo].[Employee] ([employee_id], [employee_name], [employee_salary], [department_id]) VALUES (10, N'Работник_2', 23500.0000, 3)
                                    INSERT [dbo].[Employee] ([employee_id], [employee_name], [employee_salary], [department_id]) VALUES (11, N'Работник_3', 80000.0000, 4)
                                    INSERT [dbo].[Employee] ([employee_id], [employee_name], [employee_salary], [department_id]) VALUES (12, N'Работник_4', 100000.0000, 4)
                                    INSERT [dbo].[Employee] ([employee_id], [employee_name], [employee_salary], [department_id]) VALUES (13, N'Работник_5', 110000.0000, 4)
                                    INSERT [dbo].[Employee] ([employee_id], [employee_name], [employee_salary], [department_id]) VALUES (14, N'Работник_6', 120000.0000, 4)
                                    INSERT [dbo].[Employee] ([employee_id], [employee_name], [employee_salary], [department_id]) VALUES (15, N'Работник_7', 50000.0000, 6)
                                    INSERT [dbo].[Employee] ([employee_id], [employee_name], [employee_salary], [department_id]) VALUES (16, N'Работник_8', 60000.0000, 6)
                                    INSERT [dbo].[Employee] ([employee_id], [employee_name], [employee_salary], [department_id]) VALUES (17, N'Работник_9', 70000.0000, 6)
                                    INSERT [dbo].[Employee] ([employee_id], [employee_name], [employee_salary], [department_id]) VALUES (18, N'Работник_10', 75000.0000, 6)
                                    SET IDENTITY_INSERT [dbo].[Employee] OFF
                                    GO", true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE [dbo].[Employee]", true);

            migrationBuilder.Sql("DELETE[dbo].[Department]", true);
        }
    }
}
