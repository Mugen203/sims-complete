using ischool_backend.Core.Interfaces.Repository;

namespace ischool_backend.Infrastructure.Repositories;

/// <summary>
/// Repository Manager class, responsible for instantiating and providing access to all repository implementations.
/// It acts as a central point for data access layer within the application.
/// </summary>
public class RepositoryManager : IRepositoryManager
{
    private readonly RepositoryContext _repositoryContext;
    private readonly Lazy<IAttendanceRecordRepository> _attendanceRecordRepository;
    private readonly Lazy<IBookRepository> _bookRepository;
    private readonly Lazy<IBorrowRequestRepository> _borrowRequestRepository;
    private readonly Lazy<IClassEnrollmentRepository> _classEnrollmentRepository;
    private readonly Lazy<IClassScheduleRepository> _classScheduleRepository;
    private readonly Lazy<IClassSessionRepository> _classSessionRepository;
    private readonly Lazy<IClassRepository> _classRepository;
    private readonly Lazy<ICourseRepository> _courseRepository;
    private readonly Lazy<IFeeAccountRepository> _feeAccountRepository;
    private readonly Lazy<IFeePaymentRepository> _feePaymentRepository;
    private readonly Lazy<IGradeRepository> _gradeRepository;
    private readonly Lazy<ILecturerEvaluationRepository> _lecturerEvaluationRepository;
    private readonly Lazy<ILecturerRepository> _lecturerRepository;
    private readonly Lazy<IStudentRepository> _studentRepository;

    /// <summary>
    /// Initializes a new instance of the <see cref="RepositoryManager"/> class.
    /// </summary>
    /// <param name="repositoryContext">The <see cref="RepositoryContext"/> to be injected, providing database access.</param>
    public RepositoryManager(RepositoryContext repositoryContext)
    {
        _repositoryContext = repositoryContext;

        _attendanceRecordRepository = new Lazy<IAttendanceRecordRepository>(() => new AttendanceRecordRepository(_repositoryContext));
        _bookRepository = new Lazy<IBookRepository>(() => new BookRepository(_repositoryContext));
        _borrowRequestRepository = new Lazy<IBorrowRequestRepository>(() => new BorrowRequestRepository(_repositoryContext));
        _classEnrollmentRepository = new Lazy<IClassEnrollmentRepository>(() => new ClassEnrollmentRepository(_repositoryContext));
        _classScheduleRepository = new Lazy<IClassScheduleRepository>(() => new ClassScheduleRepository(_repositoryContext));
        _classSessionRepository = new Lazy<IClassSessionRepository>(() => new ClassSessionRepository(_repositoryContext));
        _classRepository = new Lazy<IClassRepository>(() => new ClassRepository(_repositoryContext));
        _courseRepository = new Lazy<ICourseRepository>(() => new CourseRepository(_repositoryContext));
        _feeAccountRepository = new Lazy<IFeeAccountRepository>(() => new FeeAccountRepository(_repositoryContext));
        _feePaymentRepository = new Lazy<IFeePaymentRepository>(() => new FeePaymentRepository(_repositoryContext));
        _gradeRepository = new Lazy<IGradeRepository>(() => new GradeRepository(_repositoryContext));
        _lecturerRepository = new Lazy<ILecturerRepository>(() => new LecturerRepository(_repositoryContext));
        _lecturerEvaluationRepository = new Lazy<ILecturerEvaluationRepository>(() => new LecturerEvaluationRepository(_repositoryContext));
        _studentRepository = new Lazy<IStudentRepository>(() => new StudentRepository(_repositoryContext));
    }

    /// <inheritdoc />
    public IAttendanceRecordRepository AttendanceRecordRepository => _attendanceRecordRepository.Value;

    /// <inheritdoc />
    public IBookRepository BookRepository => _bookRepository.Value;

    /// <inheritdoc />
    public IBorrowRequestRepository BorrowRequestRepository => _borrowRequestRepository.Value;

    /// <inheritdoc />
    public IClassEnrollmentRepository ClassEnrollmentRepository => _classEnrollmentRepository.Value;

    /// <inheritdoc />
    public IClassScheduleRepository ClassScheduleRepository => _classScheduleRepository.Value;

    /// <inheritdoc />
    public IClassSessionRepository ClassSessionRepository => _classSessionRepository.Value;

    /// <inheritdoc />
    public IClassRepository ClassRepository => _classRepository.Value;

    /// <inheritdoc />
    public ICourseRepository CourseRepository => _courseRepository.Value;

    /// <inheritdoc />
    public IFeeAccountRepository FeeAccountRepository => _feeAccountRepository.Value;

    /// <inheritdoc />
    public IFeePaymentRepository FeePaymentRepository => _feePaymentRepository.Value;

    /// <inheritdoc />
    public IGradeRepository GradeRepository => _gradeRepository.Value;

    /// <inheritdoc />
    public ILecturerEvaluationRepository LecturerEvaluationRepository => _lecturerEvaluationRepository.Value;

    /// <inheritdoc />
    public ILecturerRepository LecturerRepository => _lecturerRepository.Value;

    /// <inheritdoc />
    public IStudentRepository StudentRepository => _studentRepository.Value;

    /// <inheritdoc />
    public void Save() => _repositoryContext.SaveChanges();
}