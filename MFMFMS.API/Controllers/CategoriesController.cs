using MFMFMS.API.DTOs.Categories;
using MFMFMS.Application.Features.Categories.Commands.CreateCategories;
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
    }
}
