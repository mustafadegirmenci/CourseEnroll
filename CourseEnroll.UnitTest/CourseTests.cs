using AutoMapper;
using CourseEnroll.Application.Features.CourseFeatures.CreateCourse;
using CourseEnroll.Application.Features.CourseFeatures.GetAllCourse;
using CourseEnroll.Persistence.Context;
using CourseEnroll.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Moq;

namespace CourseEnroll.UnitTest;

public class CourseTests
{
    private DbContextOptions<DataContext> _dbContextOptions;
    private DataContext _dataContext;
    private Mock<UnitOfWork> _unitOfWork;
    
    private Mock<CourseRepository> _courseRepository;
    private Mock<StudentRepository> _studentRepository;
    
    private CreateCourseHandler _createCourseHandler;
    private CreateCourseValidator _createCourseValidator;
    
    private GetAllCourseHandler _getAllCourseHandler;

    [SetUp]
    public void Setup()
    {
        _dbContextOptions = new DbContextOptionsBuilder<DataContext>()
            .UseInMemoryDatabase(databaseName: "test")
            .Options;
        _dataContext = new DataContext(_dbContextOptions);
        _unitOfWork = new Mock<UnitOfWork>(_dataContext);

        _courseRepository = new Mock<CourseRepository>(_dataContext);
        _studentRepository = new Mock<StudentRepository>(_dataContext);

        _createCourseHandler = new CreateCourseHandler(_unitOfWork.Object, _courseRepository.Object, 
            new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<CreateCourseMapper>();
            }).CreateMapper());
        _createCourseValidator = new CreateCourseValidator();
        
        _getAllCourseHandler = new GetAllCourseHandler(_courseRepository.Object);
    }

    [TestCase("TEST101", "Intro. to Testing")]
    public async Task CreateCourseHandler(string courseCode, string courseName)
    {
        // Arrange
        var request = new CreateCourseRequest(courseCode, courseName);

        // Act
        var response = await _createCourseHandler.Handle(request, default);
        
        // Assert
        Assert.That(response.CourseName, Is.EqualTo(request.CourseName));
    }
    
    [TestCase("TEST101", "Intro. to Testing", true)]
    public async Task CreateCourseValidator(string courseCode, string courseName, bool shouldBeValid)
    {
        // Arrange
        var request = new CreateCourseRequest(courseCode, courseName);
        
        // Act
        var validationResult = await _createCourseValidator.ValidateAsync(request);
        
        // Assert
        Assert.That(shouldBeValid, Is.EqualTo(validationResult.IsValid));
    }
    
    [Test]
    public async Task GetAllCourseHandler()
    {
        // Arrange
        var request = new GetAllCourseRequest();

        // Act
        var response = await _getAllCourseHandler.Handle(request, default);
        
        // Assert
        Assert.That(response.Courses, Is.Not.Null);
    }
}
