namespace Lecture3;

/// <summary>
/// Interface for simple repository that allow save entities
/// </summary>
public interface ISaveRepository<T> where T : notnull
{
    /// <summary>
    /// Method for saving new entity to repository
    /// </summary>
    /// <param name="item">New entity for save. </param>
    /// <returns>Generated Id of new entity. </returns>
    /// <exception cref="ArgumentException"> If argument is already in repository. </exception>
    Guid Save(T item);
}

/// <inheritdoc cref="ISaveRepository{T}"/>
public class SaveRepositoryStub<T> : ISaveRepository<T> where T : notnull
{
    public Guid Save(T item) => Guid.NewGuid();
}