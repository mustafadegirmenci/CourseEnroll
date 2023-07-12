// using AutoMapper;
// using CourseEnroll.Application.Features.CourseFeatures.CreateCourse;
// using CourseEnroll.Application.Features.CourseFeatures.GetAllCourse;
// using CourseEnroll.Persistence.Context;
// using CourseEnroll.Persistence.Repositories;
// using Microsoft.EntityFrameworkCore;
// using Moq;
//
// namespace CourseEnroll.UnitTest;
//
// public class CourseTests
// {
//     private DbContextOptions<DataContext> _dbContextOptions;
//     private DataContext _dataContext;
//     private Mock<UnitOfWork> _unitOfWork;
//     
//     private Mock<CourseRepository> _courseRepository;
//     private Mock<StudentRepository> _studentRepository;
//     
//     private CreateCourseHandler _createCourseHandler;
//     private CreateCourseValidator _createCourseValidator;
//     
//     private GetAllCourseHandler _getAllCourseHandler;
//
//     [SetUp]
//     public void Setup()
//     {
//         _dbContextOptions = new DbContextOptionsBuilder<DataContext>()
//             .UseInMemoryDatabase(databaseName: "test")
//             .Options;
//         _dataContext = new DataContext(_dbContextOptions);
//         _unitOfWork = new Mock<UnitOfWork>(_dataContext);
//
//         _courseRepository = new Mock<CourseRepository>(_dataContext);
//         _studentRepository = new Mock<StudentRepository>(_dataContext);
//
//         _createCourseHandler = new CreateCourseHandler(_unitOfWork.Object, _courseRepository.Object, 
//             new MapperConfiguration(cfg =>
//             {
//                 cfg.AddProfile<CreateCourseMapper>();
//             }).CreateMapper());
//         _createCourseValidator = new CreateCourseValidator();
//         
//         _getAllCourseHandler = new GetAllCourseHandler(_courseRepository.Object);
//     }
//
//     [Test]
//     public async Task CreateCourseHandler()
//     {
//         // Arrange
//         var startTime = DateTime.Now;
//         var endTime = DateTime.Now + TimeSpan.FromHours(1);
//         var request = new CreateCourseRequest(Guid.NewGuid(), startTime, endTime);
//
//         // Act
//         var response = await _createCourseHandler.Handle(request, default);
//         
//         // Assert
//         Assert.That(response.StartTime, Is.EqualTo(startTime));
//     }
//
//     [TestCase(1, true)]
//     [TestCase(3, false)]
//     public async Task CreateCourseValidator(int timeDifferenceInHours, bool shouldBeValid)
//     {
//         // Arrange
//         var startTime = DateTime.Now;
//         var endTime = startTime + TimeSpan.FromHours(timeDifferenceInHours);
//         var request = new CreateCourseRequest(Guid.NewGuid(), startTime, endTime);
//         
//         // Act
//         var validationResult = await _createCourseValidator.ValidateAsync(request);
//         
//         // Assert
//         Assert.That(shouldBeValid, Is.EqualTo(validationResult.IsValid));
//     }
//     
//     [Test]
//     public async Task GetAllCourseHandler()
//     {
//         // Arrange
//         var request = new GetAllCourseRequest();
//
//         // Act
//         var response = await _getAllCourseHandler.Handle(request, default);
//         
//         // Assert
//         Assert.That(response.Courses, Is.Not.Null);
//     }
// }
