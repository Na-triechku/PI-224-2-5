using Jobs.DAL.Entities;
using Jobs.DAL.Interfaces;
using Jobs.Tests.ServicesTests.TestsData;
using Moq;
using Newtonsoft.Json;

namespace Jobs.Tests.ServicesTests.Tests
{
    public class CVServiceTests
    {
        [Fact]
        public void GetAllCVsAsyncReturnCVsList()
        {
            //Arrange
            var unitOfWorkMock = new Mock<IUnitOfWork>();
            unitOfWorkMock.Setup(unitOfWork => unitOfWork.CVs.GetAllAsync()).Returns(GetTestCVsAsync());

            //Act
            var cvs = unitOfWorkMock.Object.CVs.GetAllAsync().Result;

            //Assert
            Assert.NotNull(cvs);
            Assert.IsType<List<CV>>(cvs);
        }

        [Theory]
        [ClassData(typeof(EditCVTestsData))]
        public async Task EditCVAsync(CV cv, Task expected)
        {
            //Arrange
            var unitOfWorkMock = new Mock<IUnitOfWork>();
            unitOfWorkMock.Setup(unitOfWork => unitOfWork.CVs.UpdateAsync(cv)).Returns(EditTestCV(cv));

            //Act
            var actual = unitOfWorkMock.Object.CVs.UpdateAsync(cv);

            //Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [ClassData(typeof(AddCVTestsData))]
        public async Task AddCVAsync(CV cv, CV expected)
        {
            //Arrange
            var unitOfWorkMock = new Mock<IUnitOfWork>();
            unitOfWorkMock.Setup(unitOfWork => unitOfWork.CVs.CreateAsync(cv)).Returns(AddTestCVAsync(cv));

            //Act
            var actual = await unitOfWorkMock.Object.CVs.CreateAsync(cv);
            var actualJson = JsonConvert.SerializeObject(actual);
            var expectedJson = JsonConvert.SerializeObject(expected);

            //Assert
            Assert.Equal(expectedJson, actualJson);
        }

        [Theory]
        [ClassData(typeof(DeleteCVTestsData))]
        public async Task DeleteCVAsync(CV cv, Task expected)
        {
            //Arrange
            var unitOfWorkMock = new Mock<IUnitOfWork>();
            unitOfWorkMock.Setup(unitOfWork => unitOfWork.CVs.DeleteAsync(cv)).Returns(DeleteTestCV(cv));

            //Act
            var actual = unitOfWorkMock.Object.CVs.DeleteAsync(cv);

            //Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [ClassData(typeof(GetCVByIdTestsData))]
        public async Task GetCVByIdAsyncReturnCV(int id, CV expected)
        {
            //Arrange
            var unitOfWorkMock = new Mock<IUnitOfWork>();
            unitOfWorkMock.Setup(unitOfWork => unitOfWork.CVs.GetByIdAsync(id)).Returns(GetTestCVByIdAsync(id));

            //Act
            var cv = await unitOfWorkMock.Object.CVs.GetByIdAsync(id);
            var actualJson = JsonConvert.SerializeObject(cv);
            var expectedJson = JsonConvert.SerializeObject(expected);

            //Assert
            Assert.Equal(expectedJson, actualJson);
        }

        private Task EditTestCV(CV cv)
        {
            return Task.CompletedTask;
        }

        private async Task<CV> AddTestCVAsync(CV cv)
        {
            return cv;
        }

        private Task DeleteTestCV(CV cv)
        {
            return Task.CompletedTask;
        }

        private async Task<CV> GetTestCVByIdAsync(int id)
        {
            if (id == 0) return null;

            return new CV
            {
                Id = 3,
                Name = ".Net Traineeship",
                Position = "Trainee software engineer",
                ExpectedSalary = 400,
                Experience = 0,
                Skills = ".Net, C#, OOP, SQL"
            };
        }

        private async Task<List<CV>> GetTestCVsAsync()
        {
            var cvs = new List<CV>
            {
                new CV
                {
                    Id = 2,
                    Name = ".Net Junior",
                    Position = "Junior software engineer",
                    Skills = ".Net, C#, OOP, SQL, ASP.NET, .Net Core, React",
                    Experience = 1,
                    ExpectedSalary = 800
                },

                new CV
                {
                    Id = 3,
                    Name = ".Net Traineeship",
                    Position = "Trainee software engineer",
                    ExpectedSalary = 400,
                    Experience = 0,
                    Skills = ".Net, C#, OOP, SQL"
                }
            };

            return cvs;
        }
    }
}