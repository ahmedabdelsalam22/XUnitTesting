using System;

namespace SW.Payroll.Tests
{
    public class SalarySlipProcessorTests
    {

        //1-Testing from CalculateBasicSalary method
        [Fact]
        public void CalculateBasicSalary_ForEmployeeObject_ReturnsBasicSalary()
        {
            //TRIPLE A -- (AAA)

            //Arrange
            var employee = new Employee() { Wage = 500m, WorkingDays = 20 };
            //Act
            SalarySlipProcessor salarySlipProcessor = new SalarySlipProcessor();

            var actual = salarySlipProcessor.CalculateBasicSalary(employee);
            var expected = 10000m;
            //Assert
            Assert.Equal(expected, actual);
        }
        [Fact]
        public void CalculateBasicSalary_ForEmployeeNull_ThrowArgumentNullException()
        {
            //TRIPLE A -- (AAA)

            //Arrange
            Employee employee = null;
            //Act
            SalarySlipProcessor salarySlipProcessor = new SalarySlipProcessor();

            Func<Employee, decimal> fun = (e) => salarySlipProcessor.CalculateBasicSalary(employee);

            //Assert
            Assert.Throws<ArgumentNullException>(() => fun(employee));
        }

        //2-Testing for CalculateTransportationAllowece method
        [Fact]
        public void CalculateTransportationAllowece_ForEmployeeWorkInOffice_ReturnsTransportationAllowece()
        {
            //TRIPLE A -- (AAA)

            //Arrange
            var employee = new Employee() { WorkPlatform = WorkPlatform.Office };
            //Act
            SalarySlipProcessor salarySlipProcessor = new SalarySlipProcessor();
            var actual = salarySlipProcessor.CalculateTransportationAllowece(employee);
            var expected = Constants.TransportationAllowanceAmount;
            //Assert
            Assert.Equal(expected, actual);

        }
        [Fact]
        public void CalculateTransportationAllowece_ForEmployeeWorkHybridMode_ReturnsTransportationAllowece()
        {
            //TRIPLE A -- (AAA)

            //Arrange
            var employee = new Employee() { WorkPlatform = WorkPlatform.Hybrid };
            //Act
            SalarySlipProcessor salarySlipProcessor = new SalarySlipProcessor();
            var actual = salarySlipProcessor.CalculateTransportationAllowece(employee);
            var expected = Constants.TransportationAllowanceAmount / 2;
            //Assert
            Assert.Equal(expected, actual);

        }
        [Fact]
        public void CalculateTransportationAllowece_ForEmployeeWorkRemote_ReturnsTransportationAllowece()
        {
            //TRIPLE A -- (AAA)

            //Arrange
            var employee = new Employee() { WorkPlatform = WorkPlatform.Remote };
            //Act
            SalarySlipProcessor salarySlipProcessor = new SalarySlipProcessor();
            var actual = salarySlipProcessor.CalculateTransportationAllowece(employee);
            var expected = 0m;
            //Assert
            Assert.Equal(expected, actual);

        }
        [Fact]
        public void CalculateTransportationAllowece_ForEmployeeNull_ThrowArgumentNullException()
        {
            //TRIPLE A -- (AAA)

            //Arrange
            Employee employee = null;
            //Act
            SalarySlipProcessor salarySlipProcessor = new SalarySlipProcessor();

            Func<Employee, decimal> fun = (e) => salarySlipProcessor.CalculateTransportationAllowece(employee);

            //Assert
            Assert.Throws<ArgumentNullException>(() => fun(employee));
        }

        //3-Testing for CalculateSpouseAllowance method
        [Fact]
        public void CalculateSpouseAllowance_ForEmployeeThatMarried_ReturnSpouseAllowanceAmount()
        {
            //Arrange
            var employee = new Employee() { IsMarried = true };
            //Act
            SalarySlipProcessor salarySlipProcessor = new SalarySlipProcessor();

            var actual = salarySlipProcessor.CalculateSpouseAllowance(employee);
            var expected = Constants.SpouseAllowanceAmount;
            //Assert
            Assert.Equal(actual, expected);
        }
        [Fact]
        public void CalculateSpouseAllowance_ForEmployeeThatNotMarried_ReturnSpouseAllowanceAmount()
        {
            //Arange
            var employee = new Employee() { IsMarried = false };
            //Act
            SalarySlipProcessor salarySlipProcessor = new SalarySlipProcessor();
            var actual = salarySlipProcessor.CalculateSpouseAllowance(employee);
            var expected = 0m;
            //Assert
            Assert.Equal(actual, expected);
        }
        [Fact]
        public void CalculateSpouseAllowance_ForEmployeeNull_ThrowArgumentNullException()
        {
            //Arrange
            Employee employee = null;
            //Act 
            SalarySlipProcessor salarySlipProcessor = new SalarySlipProcessor();

            Func<Employee, decimal> func = (e) => salarySlipProcessor.CalculateSpouseAllowance(employee);

            //Assert

            Assert.Throws<ArgumentNullException>(() => func(employee));

        }

    }
}