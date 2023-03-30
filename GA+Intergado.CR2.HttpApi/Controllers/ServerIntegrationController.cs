using GA_Intergado.CR2.App.ServerIntegration.Commands;
using GA_Intergado.CR2.App.ServerIntegration.DTOs;
using GA_Intergado.CR2.Domain.Recipes;
using GA_Intergado.CR2.IntegrationService.Model;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace GA_Intergado.CR2.HttpApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ServerIntegrationController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

        private readonly IMediator _mediator;

        public ServerIntegrationController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet(Name = "GetEntities")]
        public async void Get()
        {
            List<ServerIntegrationItemDTO> ListaParaDownload = new List<ServerIntegrationItemDTO>
            {
                new ServerIntegrationItemDTO(typeof(Recipe), typeof(ReceitaCR1VM),"Recipes","view_receitas")

            };

            var command = new DownloadEtitiesCommand(ListaParaDownload);


            var RecipeValues = await _mediator.Send(command);

            foreach(ServerIntegrationItemDTO a in ListaParaDownload)
            {

            }

        }
    }
}