using Application.Interfaces;
using Ardalis.Specification.EntityFrameworkCore;
using Infrastructure.Context;

namespace Infrastructure.Repository;

public class RepositoryAsync<T> : RepositoryBase<T>, IRepositoryAsync<T> where T : class
{
    private readonly DatabaseContext dbContext;

    public RepositoryAsync(DatabaseContext dbContext) : base(dbContext)
    {
        this.dbContext = dbContext;
    }
}
