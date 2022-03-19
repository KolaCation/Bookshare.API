using Bookshare.Domain.Constants;
using Bookshare.Domain.General;
using Bookshare.Domain.Models;
using Bookshare.DomainServices;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Bookshare.ApplicationServices.Commands
{
    public class UpdateBookCommand : IRequest<OperationResult>
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public sealed class UpdateBookCommandHandler : IRequestHandler<UpdateBookCommand, OperationResult>
    {
        private readonly BookshareDbContext _context;

        public UpdateBookCommandHandler(BookshareDbContext bookshareDbContext)
        {
            _context = bookshareDbContext;
        }

        public async Task<OperationResult> Handle(UpdateBookCommand request, CancellationToken cancellationToken)
        {
            var book = await _context.Books.FirstOrDefaultAsync(_ => _.Id == request.Id, cancellationToken);
            if (book == null)
            {
                return OperationResult.Fail(string.Format(ErrorConstants.EntityNotFound, nameof(Book), nameof(Book.Id), request.Id));
            }

            book.Name = request.Name;

            _context.Books.Update(book);
            await _context.SaveChangesAsync(cancellationToken);
            return OperationResult.Ok();
        }
    }
}