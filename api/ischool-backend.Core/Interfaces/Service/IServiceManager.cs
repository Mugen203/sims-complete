namespace ischool_backend.Core.Interfaces.Service;

public interface IServiceManager
{
    IAttendanceRecordService AttendanceRecordService { get; }
    IBookService BookService { get; }
    IBorrowRequestService BorrowRequestService { get; }
    IClassEnrollmentService ClassEnrollmentService { get; }
    IClassScheduleService ClassScheduleService { get; }
    IClassSessionService ClassSessionService { get; }
    IClassService ClassService { get; }
    ICourseService CourseService { get; }
    IFeeAccountService FeeAccountService { get; }
    IFeePaymentService FeePaymentService { get; }
    IGradeService GradeService { get; }
    ILecturerService LecturerService { get; }
    ILecturerEvaluationService LecturerEvaluationService { get; }
    IStudentService StudentService { get; }
}