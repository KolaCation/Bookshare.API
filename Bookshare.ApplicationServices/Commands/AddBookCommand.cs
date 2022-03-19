using Bookshare.Domain.General;
using Bookshare.Domain.Models;
using Bookshare.DomainServices;
using MediatR;

namespace Bookshare.ApplicationServices.Commands
{
    public sealed class AddBookCommand : IRequest<OperationResult>
    {
        public string Name { get; set; }
    }

    public sealed class AddBookCommandHandler : IRequestHandler<AddBookCommand, OperationResult>
    {
        private readonly BookshareDbContext _context;

        public AddBookCommandHandler(BookshareDbContext bookshareDbContext)
        {
            _context = bookshareDbContext;
        }

        public async Task<OperationResult> Handle(AddBookCommand request, CancellationToken cancellationToken)
        {
            await _context.Books.AddAsync(
                new Book
                {
                    Name = request.Name,
                }, cancellationToken);

            await _context.SaveChangesAsync(cancellationToken);
            return OperationResult.Ok();
        }
    }
}
