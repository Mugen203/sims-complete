using System;
using ischool_backend.Common.Enums;

namespace ischool_backend.Core.Mappers;

public static class GradeMapper
{
    public static CommonGrade ToCommonGrade(this Core.Enums.GradeValue grade) =>
        (CommonGrade)grade;

    public static Core.Enums.GradeValue ToCoreGrade(this CommonGrade grade) =>
        (Core.Enums.GradeValue)grade;
}
