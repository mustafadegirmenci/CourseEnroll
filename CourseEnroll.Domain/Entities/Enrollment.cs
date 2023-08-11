using System.ComponentModel.DataAnnotations;
using CourseEnroll.Domain.Common;

namespace CourseEnroll.Domain.Entities;

public sealed class Enrollment : BaseEntity
{
    [Required] public int CourseId { get; set; }
    [Required] public int StudentId { get; set; }
}
