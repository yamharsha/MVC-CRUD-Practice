﻿using System;
using System.Text.Json;
namespace Mwh.Sample.Domain.Tests.Models;

[TestClass]
public class DepartmentDtoTests
{
    [TestMethod]
    public void DepartmentDto_ConstructWithValidValues_Success()
    {
        // Arrange
        var dept = EmployeeDepartmentEnum.IT;

        // Act
        var department = new DepartmentDto(dept);

        var mytest = department.ToString();

        // Assert
        Assert.AreEqual("Department Id=2, Name=IT", mytest);
        Assert.AreEqual((int)dept, department.Id);
        Assert.AreEqual(dept.GetDisplayName(), department.Name);
        Assert.AreEqual(dept.GetDescription(), department.Description);
    }

    [TestMethod]
    public void DepartmentDto_SetValidName_Success()
    {
        // Arrange
        DepartmentDto department = new(EmployeeDepartmentEnum.IT);

        // Act
        string newName = "New Department Name";
        department.Name = newName;

        // Assert
        Assert.AreEqual(newName, department.Name);
    }

    [TestMethod]
    public void DepartmentDto_SetInvalidName_ThrowsArgumentException()
    {
        // Arrange
        DepartmentDto department = new DepartmentDto(EmployeeDepartmentEnum.IT);

        // Act and Assert
        Assert.ThrowsException<ArgumentException>(() => department.Name = "   ");
    }

    [TestMethod]
    public void DepartmentDto_ExpectedResults()
    {
        // Arrange
        var departmentDto = new DepartmentDto(EmployeeDepartmentEnum.IT)
        {
            Employees = new EmployeeDto[]
        {
            new EmployeeDto(1,
                "Test",
                22,
                "TX",
                "USA",
                EmployeeDepartmentEnum.IT),
            new EmployeeDto(
                2,
                "Test Two",
                33,
                "TX",
                "USA",
                EmployeeDepartmentEnum.IT)
        },

            // Act
            Name = "Test Name",
            Description = "Test Description"
        };

        // Assert
        Assert.IsNotNull(departmentDto);
        Assert.AreEqual(2, departmentDto.Id);
        Assert.AreEqual("Test Name", departmentDto.Name);
        Assert.AreEqual("Test Description", departmentDto.Description);
        Assert.IsNotNull(departmentDto.Employees);
        Assert.AreEqual(2, departmentDto.Employees.Length);
    }

    [TestMethod]
    public void DepartmentDto_Equality()
    {
        // Arrange
        var dept1 = new DepartmentDto(EmployeeDepartmentEnum.IT);

        var dept1_copy = new DepartmentDto(EmployeeDepartmentEnum.IT);

        var areEqual = (dept1 == dept1_copy);

        // Assert
        Assert.IsTrue(areEqual);
    }
    [TestMethod]
    public void DepartmentDto_Serialize()
    {
        // Arrange
        var dept1 = new DepartmentDto(EmployeeDepartmentEnum.IT);

        var deptString = JsonSerializer.Serialize(dept1);

        var dept1_copy = JsonSerializer.Deserialize<DepartmentDto>(deptString);

        var areEqual = (dept1 == dept1_copy);

        // Assert
        Assert.IsTrue(areEqual);
        Assert.IsNotNull(deptString);

    }
}
