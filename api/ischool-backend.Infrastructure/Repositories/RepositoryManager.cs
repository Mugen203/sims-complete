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
    
    public IAttendanceRecordRepository AttendanceRecordRepository => _attendanceRecordRepository.Value;
    public IBookRepository BookRepository => _bookRepository.Value;
    public IBorrowRequestRepository BorrowRequestRepository => _borrowRequestRepository.Value;
    public IClassEnrollmentRepository ClassEnrollmentRepository => _classEnrollmentRepository.Value;
    public IClassScheduleRepository ClassScheduleRepository => _classScheduleRepository.Value;
    public IClassSessionRepository ClassSessionRepository => _classSessionRepository.Value;
    public IClassRepository ClassRepository => _classRepository.Value;
    public ICourseRepository CourseRepository => _courseRepository.Value;
    public IFeeAccountRepository FeeAccountRepository => _feeAccountRepository.Value;
    public IFeePaymentRepository FeePaymentRepository => _feePaymentRepository.Value;
    public IGradeRepository GradeRepository => _gradeRepository.Value;
    public ILecturerEvaluationRepository LecturerEvaluationRepository => _lecturerEvaluationRepository.Value;
    public ILecturerRepository LecturerRepository => _lecturerRepository.Value;
    public IStudentRepository StudentRepository => _studentRepository.Value;
    
    public void Save() => _repositoryContext.SaveChanges();
}