using GA_Intergado.CR2.App.ServerIntegration.Commands;
using GA_Intergado.CR2.App.ServerIntegration.Commom;
using GA_Intergado.CR2.Domain.Recipes;
using MapsterMapper;
using ErrorOr;
using MediatR;
using GA_Intergado.CR2.EntityFrameworkCore.Persistence.UnitOfWork;
using GA_Intergado.CR2.IntegrationApi2;

namespace GA_Intergado.CR2.MAUI
{
    public partial class MainPage : ContentPage
    {
        int count = 0;
        public MainPage()
        {
            InitializeComponent();
        }

        private void OnCounterClicked(object sender, EventArgs e)
        {

            List<ItemEntityData> ListaParaDownload = new List<ItemEntityData>
            {
                new ItemEntityData(typeof(Recipe),"Recipes","view_receitas")
            };

            var command = new DownloadEtitiesCommand(ListaParaDownload);
            UnitOfWork unitOfWork = new UnitOfWork();
            IntegrationService integrationService = new IntegrationService();
            var handler = new DownloadEtitiesCommandHandler(unitOfWork, integrationService);
            CounterLabel.Text = handler.Handle(command, CancellationToken.None).Result;
            ReceitasIntegradas.Text = "Receitas Integradas:";

            return;
        }
    }
}