using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NUnit.Framework;

namespace addressBookRepo;
public class addressBookTest
{
    [SetUp]
    public void Setup()
    {
        _addressBookTest = new addressBookTest
        }

    [Test]
    public void AddData_ValidInput_DataAddedSuccessfully()
    {
        //Arange 
        string data = "Test Data"

            //Act 
            _addressBookTest.AddData(data);

        //Assert
        Assert.IsTrue(_addressBookTest.GetData().Contains(data));
    }

    [Test]
    public void GetData_EmptyRepository_ReturnsEmptyList()
    {
        // Act
        List<string> dataList = _addressBookTest.GetData();

        //Assert
        Assert.IsNotNull(dataList);
        Assert.IsEmpty(dataList);
    }

    [Test]
    public void GetData_NonEmptyRepository_ReturnsCorrectData()
    {
        //Arrange
        string data1 = "Data 1";
        string data2 = "Data 2";
        _addressBookTest.AddData(data1);
        _addressBookTest.AddData(data2);

        //Act
        List<string> dataList = _addressBookTest.GetData();

        //Assert
        Assert.IsNotNull(dataList);
        Assert.AreEqual(2, dataList.Count);
        Assert.Contains(data1, dataList);
        Assert.Contains(data2, dataList);
    }
}


//3 methods here for testing "AddData_ValidInput_DataAddedSuccessfully" "GetData_EmptyRepo_ReturnsEmptyList" and "GetData_NonEmptyRepo_ReturnsCorrectData
//"Setup()" runs before each test to init the addressBookRepo
//Each test has Arrange, Act then assert to verify the expected behavior of assert