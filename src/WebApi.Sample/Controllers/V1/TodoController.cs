using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Formatter;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Results;
using Microsoft.AspNetCore.OData.Routing.Controllers;
using WebApi.Sample.Models.V1;
using static Microsoft.AspNetCore.Http.StatusCodes;
using static Microsoft.AspNetCore.OData.Query.AllowedQueryOptions;

namespace WebApi.Sample.Controllers.V1
{
    //[ApiController]
    //[Route("[controller]")]
    [ApiVersion("1.0")]
    [ApiVersion("0.9", Deprecated = true)]
    public class TodoController : ODataController
    {
        private static readonly string[] Summaries = new[]
        {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

        private readonly ILogger<WeatherForecastController> _logger;

        public TodoController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [EnableQuery(PageSize = 15)]
        public IQueryable<TodoModel> Get()
        {
            return new List<TodoModel>()
            {
                new TodoModel { Id = 1, Description = "All items" }
            }.AsQueryable();
        }

        /// <summary>
        /// Gets a single TodoModel.
        /// </summary>
        /// <param name="key">The requested TodoModel identifier.</param>
        /// <returns>The requested TodoModel.</returns>
        /// <response code="200">The TodoModel was successfully retrieved.</response>
        /// <response code="404">The TodoModel does not exist.</response>
        [Produces("application/json")]
        [ProducesResponseType(typeof(TodoModel), Status200OK)]
        [ProducesResponseType(Status404NotFound)]
        [EnableQuery(AllowedQueryOptions = Select)]
        public SingleResult<TodoModel> Get(int key) => SingleResult.Create(new[] { new TodoModel() { Id = key, Description = "John Doe" } }.AsQueryable());

        /// <summary>
        /// Places a new TodoModel.
        /// </summary>
        /// <param name="todoModel">The TodoModel to place.</param>
        /// <returns>The created TodoModel.</returns>
        /// <response code="201">The TodoModel was successfully placed.</response>
        /// <response code="400">The TodoModel is invalid.</response>
        [MapToApiVersion("1.0")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(TodoModel), Status201Created)]
        [ProducesResponseType(Status400BadRequest)]
        [EnableQuery]
        public IActionResult Post([FromBody] TodoModel todoModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            todoModel.Id = 42;

            return Created(todoModel);
        }

        /// <summary>
        /// update an existing TodoModel.
        /// </summary>
        /// <param name="key">The requested TodoModel identifier.</param>
        /// <param name="todoModel">The TodoModel to place.</param>
        /// <returns>The created TodoModel.</returns>
        /// <response code="201">The TodoModel was successfully placed.</response>
        /// <response code="400">The TodoModel is invalid.</response>
        [MapToApiVersion("1.0")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(TodoModel), Status201Created)]
        [ProducesResponseType(Status400BadRequest)]
        [EnableQuery]
        public IActionResult Patch([FromODataUri] int key, [FromBody] TodoModel todoModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            todoModel.Id = key;

            return Updated(todoModel);
        }

        /// <summary>
        /// update an existing TodoModel.
        /// </summary>
        /// <param name="key">The requested TodoModel identifier.</param>
        /// <param name="todoModel">The TodoModel to place.</param>
        /// <returns>The created TodoModel.</returns>
        /// <response code="201">The TodoModel was successfully placed.</response>
        /// <response code="400">The TodoModel is invalid.</response>
        [MapToApiVersion("1.0")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(TodoModel), Status201Created)]
        [ProducesResponseType(Status400BadRequest)]
        [EnableQuery]
        public IActionResult Delete([FromODataUri] int key)
        {
            if (key==0)
            {
                return NotFound();
            }

            return NoContent();
        }

        /*
        /// <summary>
        /// Gets the most expensive TodoModel.
        /// </summary>
        /// <returns>The most expensive TodoModel.</returns>
        /// <response code="200">The TodoModel was successfully retrieved.</response>
        /// <response code="404">The no TodoModels exist.</response>
        [MapToApiVersion("1.0")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(TodoModel), Status200OK)]
        [ProducesResponseType(Status404NotFound)]
        [EnableQuery(AllowedQueryOptions = Select)]
        public SingleResult<TodoModel> MostExpensive() => SingleResult.Create(new[] { new TodoModel() { Id = 42, Description = "Bill Mei" } }.AsQueryable());

        /// <summary>
        /// Gets the line items for the specified TodoModel.
        /// </summary>
        /// <param name="key">The TodoModel identifier.</param>
        /// <returns>The TodoModel line items.</returns>
        /// <response code="200">The line items were successfully retrieved.</response>
        /// <response code="404">The TodoModel does not exist.</response>
        [ODataRoute("{key}/LineItems")]
        [Produces("application/json")]
        //[ProducesResponseType(typeof(ODataValue<IEnumerable<TodoTaskModel>>), Status200OK)]
        [ProducesResponseType(Status404NotFound)]
        [EnableQuery(AllowedQueryOptions = Select)]
        public IActionResult GetLineItems(int key)
        {
            var lineItems = new[]
            {
                new TodoTaskModel() { Number = 1, Description = "Dry erase wipes" },
                new TodoTaskModel() { Number = 2, Description = "Dry erase eraser" },
                new TodoTaskModel() { Number = 3, Description = "Dry erase markers" },
            };

            return Ok(lineItems);
        }
        */
    }
}