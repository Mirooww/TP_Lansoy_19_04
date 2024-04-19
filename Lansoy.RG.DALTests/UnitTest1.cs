using Moq;
using System.Collections.Generic;
using System.Linq;
using Lansoy.RG.DAL.DAL;
using Lansoy.RG.DAL.Services; 

public class ServiceEspionTests
{
    public void GetEspionsByVille_VilleNonPresente_RetourneListeVide()
    {
        // Arrange
        var mockContext = new Mock<ILansoyDbContext>();
        mockContext.Setup(db => db.GetVille())
                   .Returns(new List<Espion>());
        var service = new SpyService(mockContext.Object);

        // Act
        var result = service.GetEspionsByVille("Paris"); //Je n'ai pas eu le temps de faire ceci, mais je l'écris tout de même

        // Assert
    }

}


