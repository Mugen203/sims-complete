using ischool_backend.Core.Interfaces.Repository;

namespace ischool_backend.Infrastructure.Repositories;

public class RepositoryManager : IRepositoryManager
{
    private readonly RepositoryContext _repositoryContext;
    private readonly Lazy<IBookRepository> _bookRepository;
    private readonly Lazy<IBorrowRequestRepository> _borrowRequestRepository;
    private readonly Lazy<IClassRepository> _classRepository;
    private readonly Lazy<ICourseRepository> _courseRepository;
    private readonly Lazy<LecturerRepository> _lecturerRepository;
    private readonly Lazy<IStudentRepository> _studentRepository;

    public RepositoryManager(RepositoryContext repositoryContext)
    {
        _repositoryContext = repositoryContext;
        _bookRepository = new Lazy<IBookRepository>(() => new BookRepository(repositoryContext));
        _borrowRequestRepository = new Lazy<IBorrowRequestRepository>(() => new BorrowRequestRepository(repositoryContext));
        _classRepository = new Lazy<IClassRepository>(() => new ClassRepository(repositoryContext));
        _courseRepository = new Lazy<ICourseRepository>(() => new CourseRepository(repositoryContext));
        _lecturerRepository = new Lazy<LecturerRepository>(() => new LecturerRepository(repositoryContext));
        _studentRepository = new Lazy<IStudentRepository>(() => new StudentRepository(repositoryContext));
    }
    
    public IBookRepository Book => _bookRepository.Value;
    public IBorrowRequestRepository BorrowRequest => _borrowRequestRepository.Value;
    public IClassRepository Class => _classRepository.Value;
    public ICourseRepository Course => _courseRepository.Value;
    public ILecturerRepository Lecturer => _lecturerRepository.Value;
    public IStudentRepository Student => _studentRepository.Value;
    
    public void Save() => _repositoryContext.SaveChanges();
}