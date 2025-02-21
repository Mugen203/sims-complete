namespace ischool_backend.Core.Interfaces.Repository;

public interface IRepositoryManager
{
    IBookRepository Book { get; }
    IBorrowRequestRepository BorrowRequest { get; }
    IClassRepository Class { get; }
    ICourseRepository Course { get; }
    ILecturerRepository Lecturer { get; }
    IStudentRepository Student { get; }

    void Save();
}