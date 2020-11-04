using DnsClient.Internal;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TOS.Common.DataModel;
using TOS.CQRS.Dispatchers.Commands;
using TOS.CQRS.Dispatchers.Queries;
using TOS.NiceReads.Application.Commands.Books;
using TOS.NiceReads.Application.Queries.Books;
using TOS.NiceReads.Models;
using TOS.NiceReads.Web.Models;

namespace TOS.NiceReads.Web.Controllers
{
    [Authorize]
    [ApiController]
    [Route("books")]
    public class BookController : Controller
    {
        private readonly ICommandDispatcher _commandDispatcher;
        private readonly IQueryDispatcher _queryDispatcher;
        private readonly ILogger<BookController> _logger;

        public BookController(ICommandDispatcher commandDispatcher, IQueryDispatcher queryDispatcher, ILogger<BookController> logger)
        {
            _commandDispatcher = commandDispatcher;
            _queryDispatcher = queryDispatcher;
            _logger = logger;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateBookModel bookModel)
        {
            CreateBookAsyncCommand createBookAsyncCommand = new CreateBookAsyncCommand(
                bookModel.Title, bookModel.Synopsis, bookModel.AuthorId, User.Identity.Name, bookModel.Tags);
            try
            {
                string bookId = await _commandDispatcher.ExecuteAsync<CreateBookAsyncCommand, string>(createBookAsyncCommand);
                return Ok(new { Success = true, Id = bookId });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error when creating new book.");
                throw;
            }
        }        

        [HttpGet]
        public async Task<IActionResult> Get()
        {            
            try
            {
                IPagedResult<Book> books = await _queryDispatcher.ExecuteAsync<GetBooksAsyncQuery, IPagedResult<Book>>(new GetBooksAsyncQuery());
                IReadOnlyCollection<BookModel> bookModels = books.Items.Select(b => new BookModel()
                {
                    AuthorId = b.AuthorId.ToString(),
                    CreatedBy = b.CreatedBy.ToString(),
                    Id = b.Id.ToString(),
                    Synopsis = b.Synopsis,
                    Tags = b.Tags.ToArray(),
                    Title = b.Title
                }).ToArray();
                return Ok(bookModels);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error when getting books from author.");
                throw;
            }
        }
    }
}
