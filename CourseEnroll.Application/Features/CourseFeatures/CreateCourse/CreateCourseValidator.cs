using FluentValidation;

namespace CourseEnroll.Application.Features.CourseFeatures.CreateCourse;

public sealed class CreateCourseValidator : AbstractValidator<CreateCourseRequest>
{
    public CreateCourseValidator()
    {
        RuleFor(x => x.CourseCode).NotEmpty();
        RuleFor(x => x.CourseName).NotEmpty();
    }
}
