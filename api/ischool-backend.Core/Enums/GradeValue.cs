namespace ischool_backend.Core.Enums;

public enum GradeValue
{
    A = 1,        // 4.00
    A_Minus = 2,  // 3.67
    B_Plus = 3,   // 3.33
    B = 4,        // 3.00
    B_Minus = 5,  // 2.67
    C_Plus = 6,   // 2.33
    C = 7,        // 2.00
    C_Minus = 8,  // 1.67
    D_Plus = 9,   // 1.33
    D = 10,       // 1.00
    F = 11,       // 0.00 (Fail)
    P = 12,       // Pass (no impact on GPA)
    NP = 13,      // No Pass (no impact on GPA)
    I = 14,       // Incomplete (no impact)
    W = 15,       // Withdrawn (no impact)
    NA = 16       // Not Available (default)
}
