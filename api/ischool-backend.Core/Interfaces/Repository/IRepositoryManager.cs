using ischool_backend.Core.Interfaces.Service;

namespace ischool_backend.Core.Interfaces.Repository;

public interface IRepositoryManager
{
    IAttendanceRecordRepository AttendanceRecordRepository { get; }
    IBookRepository BookRepository { get; }
    IBorrowRequestRepository BorrowRequestRepository { get; }
    IClassEnrollmentRepository ClassEnrollmentRepository { get; }
    IClassScheduleRepository ClassScheduleRepository { get; }
    IClassSessionRepository ClassSessionRepository { get; }
    IClassRepository ClassRepository { get; }
    ICourseRepository CourseRepository { get; }
    IFeeAccountRepository FeeAccountRepository { get; }
    IFeePaymentRepository FeePaymentRepository { get; }
    IGradeRepository GradeRepository { get; }
    ILecturerEvaluationRepository LecturerEvaluationRepository { get; }
    ILecturerRepository LecturerRepository { get; }
    IStudentRepository StudentRepository { get; }

    void Save();
}