using ConsoleTools;
using GCWG06_HFT_2021221.Models;
using System;
using System.Collections.Generic;

namespace GCWG06_HFT_2021221.Client
{
    class Program
    {
        static RestService rest;

        static void Create(string entity)
        {
            if (entity == "Employee")
            {
                Console.Write("Enter employee's name: ");
                string name = Console.ReadLine();
                rest.Post(new Employee() { Name = name }, "employee");
            }
        }

        static void List(string entity)
        {
            if (entity == "Employee")
            {
                List<Employee> employees = rest.Get<Employee>("employee");
                foreach (var item in employees)
                {
                    Console.WriteLine(item.Employee_id + ": " + item.Name);
                }
            }
            Console.ReadLine();
        }

        static void Update(string entity)
        {
            if (entity == "Employee")
            {
                Console.Write("Enter employee's id: ");
                int id = int.Parse(Console.ReadLine());
                Employee one = rest.Get<Employee>(id, "employee");
                Console.Write($"New name [old: {one.Name}]: ");
                string name = Console.ReadLine();
                one.Name = name;
                rest.Put(one, "employee");
            }
        }

        static void Delete(string entity)
        {
            if (entity == "Employee")
            {
                Console.Write("Enter employee's id: ");
                int id = int.Parse(Console.ReadLine());
                rest.Delete(id, "employee");
            }
        }

        static void Main(string[] args)
        {
            //Console.WriteLine("Hello World!");
            rest = new RestService("http://localhost:63187/","employee");

            var employeeSubMenu = new ConsoleMenu(args, level: 1)
                .Add("List", () => List("Employee"))
                .Add("Create", () => Create("Employee"))
                .Add("Delete", () => Delete("Employee"))
                .Add("Update", () => Update("Employee"))
                .Add("Exit", ConsoleMenu.Close);

            var departmentSubMenu = new ConsoleMenu(args, level: 1)
                .Add("List", () => List("Department"))
                .Add("Create", () => Create("Department"))
                .Add("Delete", () => Delete("Department"))
                .Add("Update", () => Update("Department"))
                .Add("Exit", ConsoleMenu.Close);

            var hospitalSubMenu = new ConsoleMenu(args, level: 1)
                .Add("List", () => List("Hospital"))
                .Add("Create", () => Create("Hospital"))
                .Add("Delete", () => Delete("Hospital"))
                .Add("Update", () => Update("Hospital"))
                .Add("Exit", ConsoleMenu.Close);

            var menu = new ConsoleMenu(args, level: 0)
                .Add("Employee", () => employeeSubMenu.Show())
                .Add("Department", () => departmentSubMenu.Show())
                .Add("Hospital", () => hospitalSubMenu.Show())
                .Add("Exit", ConsoleMenu.Close);

            menu.Show();

            //restService.Post<Department>(new Department()
            //{
            //    Department_name = "Patology"
            //}, "department");
            //restService.Post<Hospital>(new Hospital()
            //{
            //    Hospital_name = "Honvéd"
            //}, "department");

            //var departments = restService.Get<Department>("department");
            //var employees = restService.Get<Employee>("employee");
            //var hospitals = restService.Get<Hospital>("hospital");
            //;
        }
    }
}
