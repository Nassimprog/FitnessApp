using Autofac;
using Autofac.Extras.Moq;
using FitnessApp;
using FitnessApp.ViewModels;
using FitnessAppTests.Services;
using NUnit.Framework;
using System.Threading.Tasks;
using Xamarin.Forms;
using Moq;


namespace FitnessAppTests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
            
        }

        [Test]
        public void Test_BMI_Using_M_Kg()
        {

            
            //arrange

            using var mock = AutoMock.GetStrict();
            var viewModelTest = mock.Create<ProfilePageViewModel>();
            viewModelTest.Height = 2;
            viewModelTest.HeightUnit = "M";
            viewModelTest.Weight = 70;
            viewModelTest.WeightUnit = "Kg";

            //act
            //Xamarin.Forms.Forms.Init();

            //Assert
            Assert.IsTrue(viewModelTest.BMI == 17.5);
            Assert.IsFalse(viewModelTest.BMI == 2);



        }
    }
}