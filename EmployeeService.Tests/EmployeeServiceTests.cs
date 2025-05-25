using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using EmployeeService.Services;
using EmployeeService.Models;
using Moq;
using EmployeeService.Repositories;


namespace EmployeeService.Tests
{
    public class EmployeeServiceTests
    {
        private readonly Mock<IEmployeeRepository> _repoMock;
        private readonly EmployeeService.Services.EmployeeService _empSvc;

        public EmployeeServiceTests()
        {
            _repoMock = new Mock<IEmployeeRepository>();
            _empSvc = new EmployeeService.Services.EmployeeService(_repoMock.Object);
        }

        [Fact]
        public async Task GetByIdAsync_ReturnsEmployee_WhenFound()
        {
            //Arrange
            var emp = new Employee
            {
                EmployeeID = 42,
                FirstName = "Alice",
                LastName = "Anderson",
                Email = "alice@example.com",
                EmploymentType = new EmploymentType { EmploymentType1 = "FullTime" }
            };
            _repoMock.Setup(s => s.GetEmployeeByIdAsync(42))
                    .ReturnsAsync(emp);
            //Act
            var result =await _empSvc.GetEmployeeByIdAsync(42);
            
            //Assert
            Assert.NotNull(result);
            Assert.Equal(emp.EmployeeID, result.EmployeeID);
            Assert.Equal(emp.FirstName, result.FirstName);
            Assert.Equal(emp.LastName, result.LastName);
        }

        [Fact]
        public async Task GetEmployeeByIdAsync_ReturnsNull_WhenNotFound()
        {
            //Arrange
            _repoMock.Setup(s => s.GetEmployeeByIdAsync(It.IsAny<int>()))
                    .ReturnsAsync((Employee?) null);

            //Act
            var result = await _empSvc.GetEmployeeByIdAsync(999);

            Assert.Null(result);
        }

        [Fact]
        public async Task GetEmployeesByGroupIdAsync_MapsToDtoList()
        {
            // Arrange
            var list = new List<Employee>
            {
                new Employee
                {
                    EmployeeID = 1,
                    FirstName = "Bob",
                    LastName = "Brown",
                    Email = "bob@company.com",
                    EmploymentType = new EmploymentType { EmploymentType1 = "PartTime" }
                },
                new Employee
                {
                    EmployeeID = 2,
                    FirstName = "Carol",
                    LastName = "Clark",
                    Email = "carol@company.com",
                    EmploymentType = new EmploymentType { EmploymentType1 = "Contract" }
                }
            };
            _repoMock.Setup(s => s.GetEmployeesByGroupIdAsync(10))
                .ReturnsAsync(list.AsEnumerable());

            // Act
            var dtos = await _empSvc.GetEmployeesByGroupIdAsync(10);

            // Assert
            var dtoList = dtos.ToList();
            Assert.Equal(2, dtoList.Count);

            Assert.Equal(1, dtoList[0].EmployeeID);
            Assert.Equal("Bob", dtoList[0].FirstName);
            Assert.Equal("PartTime", dtoList[0].EmploymentType);

            Assert.Equal(2, dtoList[1].EmployeeID);
            Assert.Equal("Carol", dtoList[1].FirstName);
            Assert.Equal("Contract", dtoList[1].EmploymentType);
        }

        [Fact]
        public async Task GetEmployeesByGroupIdAsync_ReturnsEmpty_WhenNoEmployees()
        {
            // Arrange
            _repoMock
                .Setup(r => r.GetEmployeesByGroupIdAsync(It.IsAny<int>()))
                .ReturnsAsync(Enumerable.Empty<Employee>());

            // Act
            var result = await _empSvc.GetEmployeesByGroupIdAsync(123);

            // Assert
            Assert.Empty(result);
        }

    }
}
