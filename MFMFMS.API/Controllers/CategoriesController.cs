using MFMFMS.API.DTOs.Categories;
using MFMFMS.API.Utilities;
using MFMFMS.Application.Features.Categories.Commands.CreateCategories;
using MFMFMS.Application.Features.Categories.Commands.DeleteCategory;
using MFMFMS.Application.Features.Categories.Commands.UpdateCategory;
using MFMFMS.Application.Features.Categories.Queries.GetCategoryDetail;
using MFMFMS.Application.Features.Categories.Queries.GetCategoryLists;
using MFMFMS.Application.Utilities;
using Microsoft.AspNetCore.Mvc;

namespace MFMFMS.API.Controllers
{
    [ApiController]
    [Route("api/categories")]
    public class CategoriesController : ControllerBase
    {
        private readonly IMediator _mediator;
        public CategoriesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateCategoryDTO createCategoryDTO)
        {
            var command = new CreateCategoryCommand
            {
                Name = createCategoryDTO.Name,
            };
            await _mediator.Send(command);
            return Ok();
        }

        [HttpGet]
        public async Task<ActionResult<List<CategoryListsDTO>>> GetAll([FromQuery] GetCategoryListsQuery query)
        {
            var result = await _mediator.Send(query);
            HttpContext.InsertPaginationInformationInHeader(result.TotalAmountOfRecords);
            return result.Items;
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<CategoryDetailDTO>> GetById(Guid id)
        {
            var query = new GetCategoryDetailQuery { Id = id };
            return await _mediator.Send(query);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, UpdateCategoryDTO updateCategoryDTO)
        {
            var command = new UpdateCategoryCommand
            {
                Id = id,
                Name = updateCategoryDTO.Name,
            };

            await _mediator.Send(command);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _mediator.Send(new DeleteCategoryCommand { Id = id });
            return NoContent();
        }
    }
}
