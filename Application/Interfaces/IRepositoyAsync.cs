using Ardalis.Specification;

namespace Application.Interfaces;

public interface IRepositoyAsync<T> : IRepositoryBase<T> where T : class
{
}

public interface IReadRepositoryAsync<T> : IReadRepositoryBase<T> where T : class
{
}
