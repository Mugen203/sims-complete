namespace ischool_backend.Core.Enums;

public enum GradeValue
{
    A = 1, // 4.00
    A_minus = 2, // 3.67
    B_plus = 3, // 3.33
    B = 4, // 3.00
    B_minus = 5, // 2.67
    C_plus = 6, // 2.33
    C = 7, // 2.00
    C_minus = 8, // 1.67
    D_plus = 9, // 1.33
    D = 10, // 1.00
    F = 11, // 0.00 (Fail)
    P = 12, // Pass (no impact on GPA)
    NP = 13, // No Pass (no impact on GPA)
    I = 14, // Incomplete (no impact)
    W = 15, // Withdrawn (no impact)
    NA = 16 // Not Available (default)
}