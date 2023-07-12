// using AutoMapper;
// using CourseEnroll.Application.Features.StudentFeatures.CreateStudent;
// using CourseEnroll.Application.Features.StudentFeatures.DeleteStudent;
// using CourseEnroll.Application.Features.StudentFeatures.GetAllStudent;
// using CourseEnroll.Application.Features.StudentFeatures.UpdateStudent;
// using CourseEnroll.Persistence.Context;
// using CourseEnroll.Persistence.Repositories;
// using Microsoft.EntityFrameworkCore;
// using Moq;
//
// namespace CourseEnroll.UnitTest;
//
// public class StudentTests
// {
//     private DbContextOptions<DataContext> _dbContextOptions;
//     private DataContext _dataContext;
//     private Mock<UnitOfWork> _unitOfWork;
//
//     private Mock<StudentRepository> _studentRepository;
//     
//     private CreateStudentHandler _createStudentHandler;
//     private CreateStudentValidator _createStudentValidator;
//
//     private UpdateStudentHandler _updateStudentHandler;
//     private UpdateStudentValidator _updateStudentValidator;
//         
//     private GetAllStudentHandler _getAllStudentHandler;
//     private DeleteStudentHandler _deleteStudentHandler;
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
//         _studentRepository = new Mock<StudentRepository>(_dataContext);
//
//         _createStudentHandler = new CreateStudentHandler(_unitOfWork.Object, _studentRepository.Object, 
//             new MapperConfiguration(cfg =>
//             {
//                 cfg.AddProfile<CreateStudentMapper>();
//             }).CreateMapper());
//         _createStudentValidator = new CreateStudentValidator();
//
//         _updateStudentHandler = new UpdateStudentHandler(_unitOfWork.Object, _studentRepository.Object,
//             new MapperConfiguration(cfg =>
//             {
//                 cfg.AddProfile<UpdateStudentMapper>();
//             }).CreateMapper());
//         _updateStudentValidator = new UpdateStudentValidator();
//         
//         _getAllStudentHandler = new GetAllStudentHandler(_studentRepository.Object);
//         
//         _deleteStudentHandler = new DeleteStudentHandler(_unitOfWork.Object, _studentRepository.Object,
//             new MapperConfiguration(cfg =>
//             {
//                 cfg.AddProfile<DeleteStudentMapper>();
//             }).CreateMapper());
//     }
//     
//     [TestCase("test_brand", "test_model")]
//     public async Task CreateStudentHandler(string brand, string model)
//     {
//         // Arrange
//         var request = new CreateStudentRequest(brand, model);
//
//         // Act
//         var response = await _createStudentHandler.Handle(request, default);
//         
//         // Assert
//         Assert.That(request.Brand, Is.EqualTo(response.Brand));
//     }
//
//     [TestCase("test_brand", "test_model")]
//     public async Task CreateStudentValidator(string brand, string model)
//     {
//         // Arrange
//         var request = new CreateStudentRequest(brand, model);
//         
//         // Act
//         var validationResult = await _createStudentValidator.ValidateAsync(request);
//         
//         // Assert
//         Assert.That(validationResult.IsValid, Is.True);
//     }
//
//     [TestCase("00000000-0000-0000-0000-000000000100", "test_brand", "test_model")]
//     public async Task UpdateStudentHandler(string guid, string brand, string model)
//     {
//         // Arrange
//         var createStudentRequest = new CreateStudentRequest("oldBrand", "oldModel");
//         var createStudentResponse = await _createStudentHandler.Handle(createStudentRequest, default);
//     
//         // Act
//         var request = new UpdateStudentRequest(createStudentResponse.Id, brand, model);
//         var response = await _updateStudentHandler.Handle(request, default);
//     
//         // Assert
//         Assert.That(brand, Is.EqualTo(response.Brand));
//     }
//
//     [TestCase("test_brand", "test_model")]
//     public async Task UpdateStudentValidator(string brand, string model)
//     {
//         // Arrange
//         var request = new UpdateStudentRequest(Guid.NewGuid(), brand, model);
//         
//         // Act
//         var validationResult = await _updateStudentValidator.ValidateAsync(request);
//         
//         // Assert
//         Assert.That(validationResult.IsValid, Is.True);
//     }
//
//     [Test]
//     public async Task GetAllStudentHandler()
//     {
//         // Arrange
//         var request = new GetAllStudentRequest();
//
//         // Act
//         var response = await _getAllStudentHandler.Handle(request, default);
//         
//         // Assert
//         Assert.That(response.Students, Is.Not.Null);
//     }
//     
//     [Test]
//     public async Task DeleteStudentHandler()
//     {
//         // Arrange
//         var createStudentRequest = new CreateStudentRequest("oldBrand", "oldModel");
//         var createStudentResponse = await _createStudentHandler.Handle(createStudentRequest, default);
//         
//         // Act
//         var request = new DeleteStudentRequest(createStudentResponse.Id);
//         await _deleteStudentHandler.Handle(request, default);
//
//         var deletedStudent = await _studentRepository.Object.Get(request.Id, default);
//         
//         // Assert
//         Assert.That(deletedStudent, Is.Null);
//     }
// }
