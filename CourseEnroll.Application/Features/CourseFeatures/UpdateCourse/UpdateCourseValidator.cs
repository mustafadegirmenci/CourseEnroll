using FluentValidation;

namespace CourseEnroll.Application.Features.CourseFeatures.UpdateCourse;

public sealed class UpdateCourseValidator : AbstractValidator<UpdateCourseRequest>
{
    public UpdateCourseValidator()
    {
        RuleFor(x => x.CourseCode).NotEmpty();
        RuleFor(x => x.CourseName).NotEmpty();
    }
}
