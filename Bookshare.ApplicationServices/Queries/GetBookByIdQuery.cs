using Bookshare.Domain.Constants;
using Bookshare.Domain.General;
using Bookshare.Domain.Models;
using Bookshare.DomainServices;
using MediatR;

namespace Bookshare.ApplicationServices.Queries
{
    public sealed class GetBookByIdQuery : IRequest<OperationResult<Book>>
    {
        public int Id { get; set; }
    }

    public sealed class GetBookByIdQueryHandler : IRequestHandler<GetBookByIdQuery, OperationResult<Book>>
    {
        private readonly BookshareDbContext _context;

        public GetBookByIdQueryHandler(BookshareDbContext bookshareDbContext)
        {
            _context = bookshareDbContext;
        }

        public async Task<OperationResult<Book>> Handle(GetBookByIdQuery request, CancellationToken cancellationToken)
        {
            var book = await _context.Books.FindAsync(request.Id, cancellationToken);
            if (book == null)
            {
                return OperationResult.Fail<Book>(string.Format(ErrorConstants.EntityNotFound, nameof(Book), nameof(Book.Id), request.Id));
            }

            return OperationResult.Ok(book);
        }
    }
}