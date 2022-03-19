namespace Bookshare.Domain.ValidationRules
{
    public interface IBookRules : IValidationRule
    {
        Task<bool> IsBookIdExistAsync(int id, CancellationToken cancellationToken);
    }
}
