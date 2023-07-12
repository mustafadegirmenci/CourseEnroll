﻿using System.ComponentModel.DataAnnotations;

namespace CourseEnroll.Domain.Common;

public abstract class BaseEntity
{
    [Required] public int Id { get; set; }
    public DateTimeOffset DateCreated { get; set; }
    public DateTimeOffset? DateUpdated { get; set; }
    public DateTimeOffset? DateDeleted { get; set; }
}