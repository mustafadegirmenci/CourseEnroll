using FluentValidation;

namespace CourseEnroll.Application.Features.StudentFeatures.UpdateStudent;

public sealed class UpdateStudentValidator : AbstractValidator<UpdateStudentRequest>
{
    public UpdateStudentValidator()
    {
        RuleFor(x => x.FirstName).NotEmpty();
        RuleFor(x => x.LastName).NotEmpty();
        RuleFor(x => x.BirthDate).NotEmpty();
    }
}
