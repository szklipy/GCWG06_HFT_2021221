using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GCWG06_HFT_2021221.Logic;
using GCWG06_HFT_2021221.Models;
using GCWG06_HFT_2021221.Repository;
using Moq;
using NUnit.Framework;

namespace GCWG06_HFT_2021221.Test
{
    
    class Tester
    {

        #region Test with fake
        [TestFixture]
        class TestWithFake
        {
            EmployeeLogic empLogic;
            class FakeEmpRepo : IEmployeeRepository
            {
                public void Create(Employee employee)
                {
                }

                public void Delete(int id)
                {
                    throw new NotImplementedException();
                }

                public IQueryable<Employee> GetAll()
                {
                    Department fakeDepartment = new Department()
                    {
                        Department_name = "Patology",
                        Department_id = 1
                    };
                    Hospital fakeHospital = new Hospital()
                    {
                        Hospital_name = "Honvéd",
                        Hospital_location = "Budapest",
                        Hospital_id = 2
                    };
                    return new List<Employee>()
                    {
                        new Employee()
                        {
                            Name = "Long John",
                            Job_title = "Doctor",
                            Department = fakeDepartment,
                            Hire_date = "2001.01.05",
                            Hospital = fakeHospital,
                            Salary = 4000

                        },
                        new Employee()
                        {
                            Name = "Sam from Lord of the rings",
                            Job_title = "gardener",
                            Department = fakeDepartment,
                            Hire_date = "2001.01.05",
                            Hospital = fakeHospital,
                            Salary = 2000
                        },
                    }.AsQueryable();
                }

                public Employee GetOne(int id)
                {
                    throw new NotImplementedException();
                }

                public void Update(Employee employee)
                {
                    throw new NotImplementedException();
                }
            }
            public TestWithFake()
            {
                empLogic = new EmployeeLogic(new FakeEmpRepo());
            }
            [Test]
            public void TestAVGSalary()
            {
                var result = empLogic.AVGSalary();

                Assert.That(result, Is.EqualTo(3000));
            }
            [Test]
            public void TestAVGSalaryByDepartmentsKeyValue()
            {
                var result = empLogic.AVGSalaryByDepartments()
                    .ToArray();
                Assert.That(result[0],
                    Is.EqualTo(
                        new KeyValuePair<int, double>
                        (1,3000)
                        )
                    );
            }
            [TestCase(-1000,false)]
            [TestCase(null,false)]
            [TestCase(1000,true)]
            public void CreateEmployeeTest(int? price
                , bool result)
            {
                Department fakeDepartment = new Department()
                {
                    Department_name = "Patology",
                    Department_id = 1
                };
                Hospital fakeHospital = new Hospital()
                {
                    Hospital_name = "Honvéd",
                    Hospital_location = "Budapest",
                    Hospital_id = 2
                };
                if (result)
                {
                    Assert.That(
                        () =>
                        {
                            empLogic.Create(
                                new Employee()
                                {
                                    Name = "Asd Dsa",
                                    Salary = price,
                                    Department = fakeDepartment,
                                    Hire_date = "2001.01.05",
                                    Hospital = fakeHospital,
                                }
                                );
                        },Throws.Nothing
                    );
                }
                else
                {
                    Assert.That(
                        () =>
                        {
                            empLogic.Create(
                                new Employee()
                                {
                                    Name = "Asd Dsa",
                                    Salary = price,
                                    Department = fakeDepartment,
                                    Hire_date = "2001.01.05",
                                    Hospital = fakeHospital,
                                }
                                );
                        }, Throws.Exception
                    );
                }
            }
        }
        #endregion

        #region Test with mock
        [TestFixture]
        public class TestWithMock
        {
            EmployeeLogic empLogic;
            public TestWithMock()
            {
                Mock<IEmployeeRepository> mockEmpRepository =
                    new Mock<IEmployeeRepository>();
                Department fakeDepartment = new Department()
                {
                    Department_name = "Patology",
                    Department_id = 1
                };
                Hospital fakeHospital = new Hospital()
                {
                    Hospital_name = "Honvéd",
                    Hospital_location = "Budapest",
                    Hospital_id = 2
                };
                mockEmpRepository.Setup(t => t.Create(It.IsAny<Employee>()));
                mockEmpRepository.Setup(t => t.GetAll()).Returns(
                    new List<Employee>()
                    {
                        new Employee()
                        {
                            Name = "Long John",
                            Job_title = "Doctor",
                            Department = fakeDepartment,
                            Hire_date = "2001.01.05",
                            Hospital = fakeHospital,
                            Salary = 4000

                        },
                        new Employee()
                        {
                            Name = "Sam from Lord of the rings",
                            Job_title = "gardener",
                            Department = fakeDepartment,
                            Hire_date = "2001.01.05",
                            Hospital = fakeHospital,
                            Salary = 2000
                        },
                    }.AsQueryable()

                    );
                empLogic = new EmployeeLogic(mockEmpRepository.Object);
            }
            [Test]
            public void TestAVGSalary()
            {
                var result = empLogic.AVGSalary();

                Assert.That(result, Is.EqualTo(3000));
            }
            [Test]
            public void TestAVGSalaryByDepartmentsKeyValue()
            {
                var result = empLogic.AVGSalaryByDepartments()
                    .ToArray();
                Assert.That(result[0],
                    Is.EqualTo(
                        new KeyValuePair<int, double>
                        (1, 3000)
                        )
                    );
            }
            [TestCase(-1000, false)]
            [TestCase(null, false)]
            [TestCase(1000, true)]
            public void CreateEmployeeTest(int? price
                , bool result)
            {
                Department fakeDepartment = new Department()
                {
                    Department_name = "Patology",
                    Department_id = 1
                };
                Hospital fakeHospital = new Hospital()
                {
                    Hospital_name = "Honvéd",
                    Hospital_location = "Budapest",
                    Hospital_id = 2
                };
                if (result)
                {
                    Assert.That(
                        () =>
                        {
                            empLogic.Create(
                                new Employee()
                                {
                                    Name = "Asd Dsa",
                                    Salary = price,
                                    Department = fakeDepartment,
                                    Hire_date = "2001.01.05",
                                    Hospital = fakeHospital,
                                }
                                );
                        }, Throws.Nothing
                    );
                }
                else
                {
                    Assert.That(
                        () =>
                        {
                            empLogic.Create(
                                new Employee()
                                {
                                    Name = "Asd Dsa",
                                    Salary = price,
                                    Department = fakeDepartment,
                                    Hire_date = "2001.01.05",
                                    Hospital = fakeHospital,
                                }
                                );
                        }, Throws.Exception
                    );
                }
            }
        }
        #endregion
    }
}
