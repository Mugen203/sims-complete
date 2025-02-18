using System;
using ischool_backend.Common.Enums;

namespace ischool_backend.Common.Models;

public class GpaCalculationDto
{
    public CommonGrade? Grade { get; set; }
    public int CreditHours { get; set; }
}
