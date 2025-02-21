using ischool_backend.Common.Interfaces;
using ischool_backend.Core.Interfaces.Repository;
using ischool_backend.Core.Interfaces.Service;

namespace ischool_backend.Services;

public sealed class ServiceManager : IServiceManager
{
    private readonly Lazy<IAttendanceRecordService> _attendanceRecordService;
    private readonly Lazy<IBookService> _bookService;
    private readonly Lazy<IBorrowRequestService> _borrowRequestService;
    private readonly Lazy<IClassEnrollmentService> _classEnrollmentService;
    private readonly Lazy<IClassScheduleService> _classScheduleService;
    private readonly Lazy<IClassService> _classService;
    private readonly Lazy<IClassSessionService> _classSessionService;
    private readonly Lazy<ICourseService> _courseService;
    private readonly Lazy<IFeeAccountService> _feeAccountService;
    private readonly Lazy<IFeePaymentService> _feePaymentService;
    private readonly Lazy<IGradeService> _gradeService;
    private readonly Lazy<ILecturerEvaluationService> _lecturerEvaluationService;
    private readonly Lazy<ILecturerService> _lecturerService;
    private readonly Lazy<IStudentService> _studentService;

    public ServiceManager(IRepositoryManager repositoryManager, ILoggerManager logger)
    {
        _attendanceRecordService = new Lazy<IAttendanceRecordService>(() => new AttendanceRecordService(repositoryManager, logger));
        _bookService = new Lazy<IBookService>(() => new BookService(repositoryManager, logger));
        _borrowRequestService = new Lazy<IBorrowRequestService>(() => new BorrowRequestService(repositoryManager, logger));
        _classEnrollmentService = new Lazy<IClassEnrollmentService>(() => new ClassEnrollmentService(repositoryManager, logger));
        _classScheduleService = new Lazy<IClassScheduleService>(() => new ClassScheduleService(repositoryManager, logger));
        _classSessionService = new Lazy<IClassSessionService>(() => new ClassSessionService(repositoryManager, logger));
        _classService = new Lazy<IClassService>(() => new ClassService(repositoryManager, logger));
        _courseService = new Lazy<ICourseService>(() => new CourseService(repositoryManager, logger));
        _feeAccountService = new Lazy<IFeeAccountService>(() => new FeeAccountService(repositoryManager, logger));
        _feePaymentService = new Lazy<IFeePaymentService>(() => new FeePaymentService(repositoryManager, logger));
        _gradeService = new Lazy<IGradeService>(() => new GradeService(repositoryManager, logger));
        _lecturerService = new Lazy<ILecturerService>(() => new LecturerService(repositoryManager, logger));
        _lecturerEvaluationService = new Lazy<ILecturerEvaluationService>(() => new LecturerEvaluationService(repositoryManager, logger));
        _studentService = new Lazy<IStudentService>(() => new StudentService(repositoryManager, logger));
    }
    
    public IAttendanceRecordService AttendanceRecordService => _attendanceRecordService.Value;
    public IBookService BookService => _bookService.Value;
    public IBorrowRequestService BorrowRequestService => _borrowRequestService.Value;
    public IClassEnrollmentService ClassEnrollmentService => _classEnrollmentService.Value;
    public IClassScheduleService ClassScheduleService => _classScheduleService.Value;
    public IClassSessionService ClassSessionService => _classSessionService.Value;
    public IClassService ClassService => _classService.Value;
    public ICourseService CourseService => _courseService.Value;
    public IFeeAccountService FeeAccountService => _feeAccountService.Value;
    public IFeePaymentService FeePaymentService => _feePaymentService.Value;
    public IGradeService GradeService => _gradeService.Value;
    public ILecturerEvaluationService LecturerEvaluationService => _lecturerEvaluationService.Value;
    public ILecturerService LecturerService => _lecturerService.Value;
    public IStudentService StudentService => _studentService.Value;
}