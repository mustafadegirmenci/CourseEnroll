using AutoMapper;
using CourseEnroll.Application.Features.StudentFeatures.CreateStudent;
using CourseEnroll.Application.Features.StudentFeatures.DeleteStudent;
using CourseEnroll.Application.Features.StudentFeatures.GetAllStudent;
using CourseEnroll.Application.Features.StudentFeatures.UpdateStudent;
using CourseEnroll.Domain.Entities;
using CourseEnroll.Persistence.Context;
using CourseEnroll.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Moq;

namespace CourseEnroll.UnitTest;

public class StudentTests
{
    private DbContextOptions<DataContext> _dbContextOptions;
    private DataContext _dataContext;
    private Mock<UnitOfWork> _unitOfWork;

    private Mock<StudentRepository> _studentRepository;
    
    private CreateStudentHandler _createStudentHandler;
    private CreateStudentValidator _createStudentValidator;

    private UpdateStudentHandler _updateStudentHandler;
    private UpdateStudentValidator _updateStudentValidator;
        
    private GetAllStudentHandler _getAllStudentHandler;
    private DeleteStudentHandler _deleteStudentHandler;

    [SetUp]
    public void Setup()
    {
        _dbContextOptions = new DbContextOptionsBuilder<DataContext>()
            .UseInMemoryDatabase(databaseName: "test")
            .Options;
        _dataContext = new DataContext(_dbContextOptions);
        _unitOfWork = new Mock<UnitOfWork>(_dataContext);

        _studentRepository = new Mock<StudentRepository>(_dataContext);

        _createStudentHandler = new CreateStudentHandler(_unitOfWork.Object, _studentRepository.Object, 
            new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<CreateStudentMapper>();
            }).CreateMapper());
        _createStudentValidator = new CreateStudentValidator();

        _updateStudentHandler = new UpdateStudentHandler(_unitOfWork.Object, _studentRepository.Object,
            new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<UpdateStudentMapper>();
            }).CreateMapper());
        _updateStudentValidator = new UpdateStudentValidator();
        
        _getAllStudentHandler = new GetAllStudentHandler(_studentRepository.Object);
        
        _deleteStudentHandler = new DeleteStudentHandler(_unitOfWork.Object, _studentRepository.Object,
            new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<DeleteStudentMapper>();
            }).CreateMapper());
    }
    
    [TestCase("Donald", "Trump", "01.02.1946")]
    public async Task CreateStudentHandler(string firstName, string lastName, DateTime birthDate)
    {
        // Arrange
        var request = new CreateStudentRequest(firstName, lastName, birthDate);

        // Act
        var response = await _createStudentHandler.Handle(request, default);
        
        // Assert
        Assert.That(request.FirstName, Is.EqualTo(response.FirstName));
    }

    [TestCase("Donald", "Trump", "01.02.1946", true)]
    public async Task CreateStudentValidator(string firstName, string lastName, DateTime birthDate, bool shouldBeValid)
    {
        // Arrange
        var request = new CreateStudentRequest(firstName, lastName, birthDate);
        
        // Act
        var validationResult = await _createStudentValidator.ValidateAsync(request);
        
        // Assert
        Assert.That(validationResult.IsValid, Is.EqualTo(shouldBeValid));
    }

    [TestCase("Donald", "Trump", "01.02.1946")]
    public async Task UpdateStudentHandler(string firstName, string lastName, DateTime birthDate)
    {
        // Arrange
        var createStudentRequest = new CreateStudentRequest("oldName", "oldSurname", birthDate);
        var createStudentResponse = await _createStudentHandler.Handle(createStudentRequest, default);

        // Act
        var request = new UpdateStudentRequest(createStudentResponse.Id, firstName, lastName, birthDate, new List<Course>());
        var response = await _updateStudentHandler.Handle(request, default);

        // Assert
        Assert.That(lastName, Is.EqualTo(response.LastName));
    }

    [TestCase("Donald", "Trump", "01.02.1946", true)]
    public async Task UpdateStudentValidator(string firstName, string lastName, DateTime birthDate, bool shouldBeValid)
    {
        // Arrange
        var request = new UpdateStudentRequest(111, firstName, lastName, birthDate, new List<Course>());
        
        // Act
        var validationResult = await _updateStudentValidator.ValidateAsync(request);
        
        // Assert
        Assert.That(validationResult.IsValid, Is.EqualTo(shouldBeValid));
    }

    [Test]
    public async Task GetAllStudentHandler()
    {
        // Arrange
        var request = new GetAllStudentRequest();

        // Act
        var response = await _getAllStudentHandler.Handle(request, default);
        
        // Assert
        Assert.That(response.Students, Is.Not.Null);
    }
    
    [Test]
    public async Task DeleteStudentHandler()
    {
        // Arrange
        var createStudentRequest = new CreateStudentRequest("firstName", "lastName", DateTime.Now);
        var createStudentResponse = await _createStudentHandler.Handle(createStudentRequest, default);
        
        // Act
        var request = new DeleteStudentRequest(createStudentResponse.Id);
        await _deleteStudentHandler.Handle(request, default);

        var deletedStudent = await _studentRepository.Object.Get(request.Id, default);
        
        // Assert
        Assert.That(deletedStudent, Is.Null);
    }
}
