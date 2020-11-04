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
using TOS.NiceReads.Application.Commands.Authors;
using TOS.NiceReads.Application.Queries.Authors;
using TOS.NiceReads.Application.Queries.Books;
using TOS.NiceReads.Models;
using TOS.NiceReads.Web.Models;

namespace TOS.NiceReads.Web.Controllers
{
    [Authorize]
    [ApiController]
    [Route("authors")]
    public class AuthorController : Controller
    {
        private readonly ICommandDispatcher _commandDispatcher;
        private readonly IQueryDispatcher _queryDispatcher;
        private readonly ILogger<AuthorController> _logger;

        public AuthorController(ICommandDispatcher commandDispatcher, IQueryDispatcher queryDispatcher, ILogger<AuthorController> logger)
        {
            _commandDispatcher = commandDispatcher;
            _queryDispatcher = queryDispatcher;
            _logger = logger;
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateAuthorModel authorModel)
        {
            try
            {
                CreateAuthorAsyncCommand createAuthorAsyncCommand = new CreateAuthorAsyncCommand(
                    authorModel.FirstName, 
                    authorModel.MiddleName,
                    authorModel.LastName, 
                    authorModel.KnownAs,
                    authorModel.Biography, 
                    User.Identity.Name);
                string authorId = await _commandDispatcher.ExecuteAsync<CreateAuthorAsyncCommand, string>(createAuthorAsyncCommand);
                return Ok(new { AuthorId = authorId });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error when creating author.");
                throw;
            }
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                GetAuthorsAsyncQuery getAuthorsAsyncQuery = new GetAuthorsAsyncQuery();
                IPagedResult<Author> authors = await _queryDispatcher.ExecuteAsync<GetAuthorsAsyncQuery, IPagedResult<Author>>(getAuthorsAsyncQuery);
                IReadOnlyCollection<AuthorModel> authorModels = authors.Items.Select(a => new AuthorModel()
                {
                    Biography = a.Biography,
                    CreatedBy = a.CreatedBy.ToString(),
                    FirstName = a.FirstName,
                    MiddleName = a.MiddleName,
                    LastName = a.LastName,
                    KnownAs = a.KnownAs,
                    Id = a.Id.ToString()
                }).ToArray();
                return Ok(authorModels);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error when get Authors.");
                throw;
            }
        }

        [HttpGet("{authorId}")]
        public async Task<IActionResult> Get(string authorId)
        {
            try
            {
                GetAuthorByIdAsyncQuery getAuthorByIdAsyncQuery = new GetAuthorByIdAsyncQuery(authorId);
                Author author = await _queryDispatcher.ExecuteAsync<GetAuthorByIdAsyncQuery, Author>(getAuthorByIdAsyncQuery);
                return Ok(author);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error when get Author for id '{authorId}'");
                throw;
            }
        }

        [HttpPut]
        public async Task<IActionResult> Put(string authorId, CreateAuthorModel createAuthorModel)
        {
            try
            {
                UpdateAuthorAsyncCommand updateAuthorAsyncCommand = new UpdateAuthorAsyncCommand(
                    authorId,
                    createAuthorModel.FirstName,
                    createAuthorModel.LastName,
                    createAuthorModel.MiddleName,
                    createAuthorModel.Biography,
                    createAuthorModel.KnownAs,
                    User.Identity.Name);
                await _commandDispatcher.ExecuteAsync<UpdateAuthorAsyncCommand>(updateAuthorAsyncCommand);
                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error when get Author for id '{authorId}'");
                throw;
            }
        }

        [Route("{authorId}/books")]
        [HttpGet()]
        public async Task<IActionResult> GetBooks([FromRoute] string authorId)
        {
            GetBooksByAuthorAsyncQuery getBooksByAuthorAsyncQuery = new GetBooksByAuthorAsyncQuery(authorId);
            try
            {
                IReadOnlyCollection<Book> books = await _queryDispatcher.ExecuteAsync<GetBooksByAuthorAsyncQuery, IReadOnlyCollection<Book>>(getBooksByAuthorAsyncQuery);
                IReadOnlyCollection<BookModel> bookModels = books.Select(b => new BookModel()
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

        [HttpDelete("{authorId}")]
        public async Task<IActionResult> Delete([FromRoute] string authorId)
        {
            DeleteAuthorAsyncCommand deleteAuthorAsyncCommand = new DeleteAuthorAsyncCommand(authorId);
            try
            {
                await _commandDispatcher.ExecuteAsync(deleteAuthorAsyncCommand);
                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error when getting books from author.");
                throw;
            }
        }
    }
}
