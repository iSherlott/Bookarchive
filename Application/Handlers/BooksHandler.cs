using System.Net;

using Application.Utils;
using Application.Commands;
using Application.Exceptions;
using Application.Commands.Contracts;
using Application.Handlers.Contracts;

using Core.Entities;
using Core.IRepositories;

namespace Application.Handlers
{
    public class BooksHandler :
        IHandlerList
    {
        private readonly string[] _books;
        private readonly IMapper _mapper;
        public BooksHandler(IMapper mapper)
        {
            _mapper = mapper;
            _books = ["Clean Architecture", "Architecture SOLID", "Architecture CQRS"];
        }

        public async Task<ICommandResult> Handle()
        {
            BooksEntity entities = new BooksEntity() { Name = _books };

            return (ICommandResult)CommandResult<BooksEntity>.Success(entities);
        }

        public async Task<ICommandResult> Handle(string nameBook)
        {
            BooksEntity entities = new BooksEntity() { Name = _books };
            //entities.AddBooks(nameBook);

            return (ICommandResult)CommandResult<BooksEntity>.Success(entities);
        }

        public async Task<ICommandResult> HandleRemove(string nameToRemove)
        {
            BooksEntity entities = new BooksEntity() { Name = _books };
            entities.RemoveBook(nameToRemove);

            return (ICommandResult)CommandResult<BooksEntity>.Success(entities);
        }

    }
}
