using System;
using ischool_backend.Common.Enums;
using ischool_backend.Common.Models;

namespace ischool_backend.Common.Utils;

public class GpaCalculator
{
    private static readonly Dictionary<CommonGrade, double> GradePointMapping = new()
    {
        { CommonGrade.A, 4.00 },
        { CommonGrade.A_Minus, 3.67 },
        { CommonGrade.B_Plus, 3.33 },
        { CommonGrade.B, 3.00 },
        { CommonGrade.B_Minus, 2.67 },
        { CommonGrade.C_Plus, 2.33 },
        { CommonGrade.C, 2.00 },
        { CommonGrade.C_Minus, 1.67 },
        { CommonGrade.D_Plus, 1.33 },
        { CommonGrade.D, 1.00 },
        { CommonGrade.F, 0.00 },
        { CommonGrade.P, 0.00 }, // Pass does not affect GPA
        { CommonGrade.NP, 0.00 }, // No Pass does not affect GPA
        { CommonGrade.I, 0.00 }, // Incomplete does not affect GPA
        { CommonGrade.W, 0.00 }, // Withdrawn does not affect GPA
        { CommonGrade.NA, 0.00 } // Not Available does not affect GPA
    };

    public static double CalculateGpa(IEnumerable<GpaCalculationDto> enrollments)
    {
        double totalPoints = 0;
        int totalCredits = 0;

        foreach (var enrollment in enrollments)
        {
            if (enrollment.Grade.HasValue && GradePointMapping.ContainsKey(enrollment.Grade.Value))
            {
                double gradePoint = GradePointMapping[enrollment.Grade.Value];
                int creditHours = enrollment.CreditHours;

                totalPoints += gradePoint * creditHours;
                totalCredits += creditHours;
            }
        }

        return totalCredits == 0 ? 0.0 : totalPoints / totalCredits;
    }
}
