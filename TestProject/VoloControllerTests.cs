using System.IO.Compression;
using System.Net;
using AirRouteAdministrator.API;
using CompanyService;
using CompanyService.Controllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Moq;

namespace TestProject;

public class VoloControllerTests{
FlightSimulatorDBContext _dbContext;
IDatabaseService dbService;

   public VoloControllerTests(){
    var _dbInMemory = new DbContextOptionsBuilder<FlightSimulatorDBContext>()
            .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
            .Options;

    _dbContext = new FlightSimulatorDBContext(_dbInMemory);
    dbService = new EFDatabase(_dbContext);
   }


    [Fact]  
    public async void GetVolo_RecuperoUnVolo_RitornoUnVolo(){
        
        // ARRANGE
        var database = new Mock<IDatabaseService>();
        database.Setup(x => x.GetVoloByIdVolo(It.IsAny<long>())).ReturnsAsync(new Volo(1,100,15,"Napoli","New York",new DateTime(2024,5,3,10,30,0),new DateTime(2024,5,3,19,30,0)));
        var _voloController = new VoloController(database.Object);
        long idVolo = 1;

        // ACT
        var result = await _voloController.Get(idVolo) as ObjectResult;

        // ASSERT
        Assert.NotNull(result);
        Assert.Equal((int)HttpStatusCode.OK, result.StatusCode);
    }
 
    [Fact]  
    public async void GetVoloConPostiDisponibili_NessunVolo_RitornoTreVoli(){
        
        // ARRANGE

        var listaListaVolo = new List<Volo>(){
            new Volo(1,100,10, 16.30,"Napoli","New York",new DateTime(2024,5,3,10,30,0),new DateTime(2024,5,3,19,30,0)),
            new Volo(12,50,52, 421.60,"Rimini","Tokyo",new DateTime(2024,6,4,12,0,0),new DateTime(2024,6,4,23,20,0)),
            new Volo(26,498,27, 34.85,"Bologna","Londra",new DateTime(2024,11,20,14,0,0),new DateTime(2024,11,20,15,20,0)),
        };

        var database = new Mock<IDatabaseService>();
        database.Setup(x => x.GetListaVoli()).ReturnsAsync(listaListaVolo);

        var _voloController = new VoloController(database.Object);
        // ACT
        // POST
        var result = await _voloController.GetVoliConPostiDisponibili() as ObjectResult;

        // ASSERT
        Assert.NotNull(result);
        Assert.Equal((int)HttpStatusCode.OK, result.StatusCode);
    }

    [Fact]
    public async void PostVolo_CreoUnVolo_VoloTrovatoEVerificato()
    {
        // Given
        var database = new Mock<IDatabaseService>();
        database.Setup(x => x.AddVolo(It.IsAny<long>(),It.IsAny<int>(),It.IsAny<double>(),It.IsAny<string>(),It.IsAny<string>(),It.IsAny<DateTime>(),It.IsAny<DateTime>())).ReturnsAsync(new Volo(100,10, 16.30,"Napoli","New York",new DateTime(2024,5,3,10,30,0),new DateTime(2024,5,3,19,30,0)));
        
        var _voloController = new VoloController(database.Object);
        CreateVoloRequest createVoloRequest = new CreateVoloRequest(50,10, 421.60,"Rimini","Tokyo",new DateTime(2024,6,4,12,0,0),new DateTime(2024,6,4,23,20,0));
        
        // When
        var result = await _voloController.Post(createVoloRequest) as ObjectResult;

        // Then
        Assert.NotNull(result);
        Assert.NotNull(result.Value);
        Assert.Equal((int)HttpStatusCode.OK, result.StatusCode);
        
        //In questo punto dentro "a" non c'è il VoloId, nella creazione di "resultGet" a.VoloId è zero e non funziona, il .Value è quello dell'errore e quindi stringa
        VoloApi a = (VoloApi)result.Value;
        var resultGet = await _voloController.Get(a.VoloId) as ObjectResult;
        Assert.NotNull(resultGet);
        Assert.NotNull(resultGet.Value);

        //Fix System.InvalidCastException da System.String a CompanyService.VoloApi
        VoloApi b = (VoloApi)resultGet.Value;
        Assert.Equal(a.AereoId, b.AereoId);
        Assert.Equal(a.PostiResidui, b.PostiResidui);
        Assert.Equal(a.CostoPosto, b.CostoPosto);
        Assert.Equal(a.Partenza, b.Partenza);
        Assert.Equal(a.Destinazione, b.Destinazione);
        Assert.Equal(a.OrarioPartenza, b.OrarioPartenza);
        Assert.Equal(a.OrarioDestinazione, b.OrarioDestinazione);
    }

    [Fact]
    public async void DeleteVolo_CreoUnVolo_ ()
    {
        // Given
    
        // When
    
        // Then
    }

    [Fact]
    public void UpdateVolo_CreoUnVolo_RitornoUnVoloModificato()
    {
        // Given
    
        // When
    
        // Then
    }
}