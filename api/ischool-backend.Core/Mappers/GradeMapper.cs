using ischool_backend.Common.Enums;
using ischool_backend.Core.Enums;

namespace ischool_backend.Core.Mappers;

public static class GradeMapper
{
    public static CommonGrade ToCommonGrade(this GradeValue grade)
    {
        return (CommonGrade)grade;
    }

    public static GradeValue ToCoreGrade(this CommonGrade grade)
    {
        return (GradeValue)grade;
    }
}