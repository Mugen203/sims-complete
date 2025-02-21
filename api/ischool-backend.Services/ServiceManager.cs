using ischool_backend.Common.Interfaces;
using ischool_backend.Core.Interfaces.Repository;
using ischool_backend.Core.Interfaces.Service;

namespace ischool_backend.Services;

/// <summary>
///  Service Manager class, responsible for instantiating and providing access to all service implementations.
///  It acts as a central point for service layer access within the application.
/// </summary>
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

    /// <summary>
    /// Initializes a new instance of the <see cref="ServiceManager"/> class.
    /// </summary>
    /// <param name="repositoryManager">The repository manager to be injected, providing access to repositories.</param>
    /// <param name="logger">The logger manager to be injected, for logging purposes within services.</param>
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

    /// <inheritdoc />
    public IAttendanceRecordService AttendanceRecordService => _attendanceRecordService.Value;

    /// <inheritdoc />
    public IBookService BookService => _bookService.Value;

    /// <inheritdoc />
    public IBorrowRequestService BorrowRequestService => _borrowRequestService.Value;

    /// <inheritdoc />
    public IClassEnrollmentService ClassEnrollmentService => _classEnrollmentService.Value;

    /// <inheritdoc />
    public IClassScheduleService ClassScheduleService => _classScheduleService.Value;

    /// <inheritdoc />
    public IClassSessionService ClassSessionService => _classSessionService.Value;

    /// <inheritdoc />
    public IClassService ClassService => _classService.Value;

    /// <inheritdoc />
    public ICourseService CourseService => _courseService.Value;

    /// <inheritdoc />
    public IFeeAccountService FeeAccountService => _feeAccountService.Value;

    /// <inheritdoc />
    public IFeePaymentService FeePaymentService => _feePaymentService.Value;

    /// <inheritdoc />
    public IGradeService GradeService => _gradeService.Value;

    /// <inheritdoc />
    public ILecturerEvaluationService LecturerEvaluationService => _lecturerEvaluationService.Value;

    /// <inheritdoc />
    public ILecturerService LecturerService => _lecturerService.Value;

    /// <inheritdoc />
    public IStudentService StudentService => _studentService.Value;
}