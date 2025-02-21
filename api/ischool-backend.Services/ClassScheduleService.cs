using ischool_backend.Common.Interfaces;
using ischool_backend.Core.Interfaces.Repository;
using ischool_backend.Core.Interfaces.Service;

namespace ischool_backend.Services;

internal sealed class ClassScheduleService : IClassScheduleService
{
    private readonly IRepositoryManager _repository;
    private readonly ILoggerManager _logger;

    public ClassScheduleService(IRepositoryManager repository, ILoggerManager logger)
    {
        _repository = repository;
        _logger = logger;
    }
}