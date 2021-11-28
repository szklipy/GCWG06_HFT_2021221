using GCWG06_HFT_2021221.Models;
using System;


namespace GCWG06_HFT_2021221.Client
{
    class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("Hello World!");
            RestService restService = new RestService("http://localhost:51716");

            restService.Post<Department>(new Department()
            {
                Department_name = "Patology"
            }, "department");
            restService.Post<Hospital>(new Hospital()
            {
                Hospital_name = "Honvéd"
            }, "department");

            var departments = restService.Get<Department>("department");
            var employees = restService.Get<Employee>("employee");
            var hospitals = restService.Get<Hospital>("hospital");
            ;
        }
    }
}
