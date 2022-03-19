using Bookshare.Domain.General;
using Bookshare.Domain.Models;
using Bookshare.DomainServices;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Bookshare.ApplicationServices.Queries
{
    public sealed class GetBooksQuery : IRequest<OperationResult<List<Book>>>
    {
    }

    public sealed class GetBooksQueryHandler : IRequestHandler<GetBooksQuery, OperationResult<List<Book>>>
    {
        private readonly BookshareDbContext _context;

        public GetBooksQueryHandler(BookshareDbContext bookshareDbContext)
        {
            _context = bookshareDbContext;
        }

        public async Task<OperationResult<List<Book>>> Handle(GetBooksQuery request, CancellationToken cancellationToken)
        {
            var books = await _context.Books.ToListAsync(cancellationToken);
            return OperationResult.Ok(books);
        }
    }
}