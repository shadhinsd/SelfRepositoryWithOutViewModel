using AutoMapper;
using SelfRepositoryAsp.DatabaseContext;
using SelfRepositoryAsp.Models;
using SelfRepositoryAsp.service;

namespace SelfRepositoryAsp.repositoryService;

public class EmployeeRepository:RepositoryService<Employee>, IEmployeeRepository
{
    public EmployeeRepository(EmployeeDbContext dbContext):base(dbContext)
    {
        
    }
}
