using ErrorOr;
using GA_Intergado.CR2.App.ServerIntegration.Commom;
using GA_Intergado.CR2.Domain.Common.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GA_Intergado.CR2.App.ServerIntegration.Commands
{
    public record DownloadEtitiesCommand(List<ItemEntityData> ItemEntities) : IRequest<string>;

}
