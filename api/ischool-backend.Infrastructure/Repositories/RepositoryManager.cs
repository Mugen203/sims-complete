using ischool_backend.Core.Interfaces.Repository;

namespace ischool_backend.Infrastructure.Repositories;

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
    
    public IAttendanceRecordRepository AttendanceRecord => _attendanceRecordRepository.Value;
    public IBookRepository Book => _bookRepository.Value;
    public IBorrowRequestRepository BorrowRequest => _borrowRequestRepository.Value;
    public IClassEnrollmentRepository ClassEnrollment => _classEnrollmentRepository.Value;
    public IClassScheduleRepository ClassSchedule => _classScheduleRepository.Value;
    public IClassSessionRepository ClassSession => _classSessionRepository.Value;
    public IClassRepository Class => _classRepository.Value;
    public ICourseRepository Course => _courseRepository.Value;
    public IFeeAccountRepository FeeAccount => _feeAccountRepository.Value;
    public IFeePaymentRepository FeePayment => _feePaymentRepository.Value;
    public IGradeRepository Grade => _gradeRepository.Value;
    public ILecturerEvaluationRepository LecturerEvaluation => _lecturerEvaluationRepository.Value;
    public ILecturerRepository Lecturer => _lecturerRepository.Value;
    public IStudentRepository Student => _studentRepository.Value;
    
    public void Save() => _repositoryContext.SaveChanges();
}