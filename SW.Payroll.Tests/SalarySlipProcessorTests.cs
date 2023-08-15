using System;
using Xunit.Sdk;

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
            SalarySlipProcessor salarySlipProcessor = new SalarySlipProcessor(null);

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
            SalarySlipProcessor salarySlipProcessor = new SalarySlipProcessor(null);

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
            SalarySlipProcessor salarySlipProcessor = new SalarySlipProcessor(null);
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
            SalarySlipProcessor salarySlipProcessor = new SalarySlipProcessor(null);
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
            SalarySlipProcessor salarySlipProcessor = new SalarySlipProcessor(null);
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
            SalarySlipProcessor salarySlipProcessor = new SalarySlipProcessor(null);

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
            SalarySlipProcessor salarySlipProcessor = new SalarySlipProcessor(null);

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
            SalarySlipProcessor salarySlipProcessor = new SalarySlipProcessor(null);
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
            SalarySlipProcessor salarySlipProcessor = new SalarySlipProcessor(null);

            Func<Employee, decimal> func = (e) => salarySlipProcessor.CalculateSpouseAllowance(employee);

            //Assert

            Assert.Throws<ArgumentNullException>(() => func(employee));

        }

        //4- Testing for CalculateDependancyAllowance method
        [Fact]
        public void CalculateDependancyAllowance_ForEmployeeNull_ThrowArgumentNullException()
        {
            //Arrange
            Employee employee = null;
            //Act
            SalarySlipProcessor salarySlipProcessor = new SalarySlipProcessor(null);

            Func<Employee, decimal> func = (e) => salarySlipProcessor.CalculateDependancyAllowance(employee);

            //Assert
            Assert.Throws<ArgumentNullException>(() => func(employee));
        }
        [Fact]
        public void CalculateDependancyAllowance_TotalDependanciesLessthanZero_ReturnsArgumentOutOfRangeException()
        {
            //Arrange
            var employee = new Employee() { TotalDependancies = -5 };
            //Act
            SalarySlipProcessor salarySlipProcessor = new SalarySlipProcessor(null);

            Func<Employee, decimal> func = (e) => salarySlipProcessor.CalculateDependancyAllowance(employee);
            //Assert 
            Assert.Throws<ArgumentOutOfRangeException>(()=> func(employee));
        }
        [Fact]
        public void CalculateDependancyAllowance_TotalDependanciesGreaterthanMaxDependantsFactor_ReturnsMaxDependancyAllowanceAmount()
        {
            // Arrange
            var employee = new Employee() { TotalDependancies = 8};
            // Act 
            SalarySlipProcessor salarySlipProcessor = new SalarySlipProcessor(null);

            var actual = salarySlipProcessor.CalculateDependancyAllowance(employee);
            var expected = Constants.MaxDependancyAllowanceAmount;
            // Assert
            Assert.Equal(expected, actual);
        }
        [Fact]
        public void CalculateDependancyAllowance_TotalDependanciesEqualZero_Returns0m()
        {
            // Arrange
            var employee = new Employee() { TotalDependancies = 0 };
            // Act 
            SalarySlipProcessor salarySlipProcessor = new SalarySlipProcessor(null);

            var actual = salarySlipProcessor.CalculateDependancyAllowance(employee);
            var expected = 0m;
            // Assert
            Assert.Equal(expected, actual);
        }
        [Fact]
        public void CalculateDependanciesAllowance_TotalDependanciesBetweenZeroAndFive()
        {
            //Arrange
            var employee = new Employee() { TotalDependancies = 3};
            //Act
            SalarySlipProcessor salarySlipProcessor = new SalarySlipProcessor(null);
            //Assert
            var actual = salarySlipProcessor.CalculateDependancyAllowance(employee);
            var expected = 3 * Constants.DependancyAllowancePerChildAmount;
            //Assert
            Assert.Equal(expected, actual);
        }

        //5- Testing for CalculatePension method
        [Fact]
        public void CalculatePension_ForEmployeeIsNull_ReturnsArgumentNullException()
        {
            //Arrange
            Employee employee = null;
            //Act 
            SalarySlipProcessor salarySlipProcessor = new SalarySlipProcessor(null);
            Func<Employee, decimal> func = (e) => salarySlipProcessor.CalculatePension(employee);
            //Assert
            Assert.Throws<ArgumentNullException>(()=>func(employee));
        }
        [Fact]
        public void CalculatePension_ForEmployeeWhenHasPensionPlanIsFalse_Returns0m()
        {
            //Arrange
            var employee = new Employee() {HasPensionPlan = false};
            //Act
            SalarySlipProcessor salarySlipProcessor = new SalarySlipProcessor(null);
            var actual = salarySlipProcessor.CalculatePension(employee);
            var expected = 0m;
            //Assert
            Assert.Equal(actual,expected);
        }
        [Fact]
        public void CalculatePension_ForEmployeeWhenHasPensionPlanIsTrue_Returns_PensionRate_star_BassicSallary()
        {
            //Arrange
            var employee = new Employee() {HasPensionPlan = true};
            //Act
            SalarySlipProcessor salarySlipProcessor = new SalarySlipProcessor(null);

            var actual = salarySlipProcessor.CalculatePension(employee);
            var expected = Constants.PensionRate * (salarySlipProcessor.CalculateBasicSalary(employee));
            //Assert
            Assert.Equal(actual,expected);
        }

        //6- Testing for CalculateDangerPay method
        [Fact]
        public void CalculateDangerPay_ForEmployeeIsNull_ReturnsArgumentNullException()
        {
            //Arrange
            Employee employee = null;
            //Act 
            SalarySlipProcessor salarySlipProcessor = new SalarySlipProcessor(null);

            Func<Employee, decimal> func = (e) => salarySlipProcessor.CalculateDangerPay(employee);
            //Assert
            Assert.Throws<ArgumentNullException>(()=>func(employee));
        }
        [Fact]
        public void CalculateDangerPay_WhenIsDangerIsTrue_ReturnsDangerPayAmount()
        {
            // Arrange
            var employee = new Employee() {IsDanger = true};
            //Act
            SalarySlipProcessor salarySlipProcessor = new SalarySlipProcessor(null);

            var actual = salarySlipProcessor.CalculateDangerPay(employee);
            var expected = Constants.DangerPayAmount;
            //Assert
            Assert.Equal(expected,actual);
        }
    }
}