using Bookshare.Domain.Constants;
using Bookshare.Domain.General;
using Bookshare.DomainServices;
using MediatR;

namespace Bookshare.ApplicationServices.Commands
{
    public sealed class RemoveBookByIdCommand : IRequest<OperationResult>
    {
        public int Id { get; set; }
    }

    public sealed class RemoveBookByIdCommandHandler : IRequestHandler<RemoveBookByIdCommand, OperationResult>
    {
        private readonly BookshareDbContext _context;

        public RemoveBookByIdCommandHandler(BookshareDbContext bookshareDbContext)
        {
            _context = bookshareDbContext;
        }

        public async Task<OperationResult> Handle(RemoveBookByIdCommand request, CancellationToken cancellationToken)
        {
            var book = await _context.Books.FindAsync(request.Id, cancellationToken);

            if (book == null)
            {
                return OperationResult.Fail(string.Format(ErrorConstants.EntityNotFound, nameof(book), nameof(book.Name), request.Id));
            }

            _context.Books.Remove(book);
            await _context.SaveChangesAsync(cancellationToken);
            return OperationResult.Ok();
        }
    }
}