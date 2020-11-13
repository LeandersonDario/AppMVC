using ApiCore.Controllers;
using AppMVC.Models;
using Microsoft.EntityFrameworkCore;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace TesteMVCApi
{
    public class CategoriasControllerTeste
    {
        public readonly Mock<DbSet<Categoria>> _mockSet;

        public readonly Mock<Context> _mockContext;

        public readonly Categoria _categoria;


        public CategoriasControllerTeste()
        {
            _mockSet = new Mock<DbSet<Categoria>>();

            _mockContext = new Mock<Context>();

            _categoria = new Categoria {Id = 14, Descricao = "Teste e teste" };

            _mockContext.Setup(mck => mck.Categorias).Returns(_mockSet.Object);

            _mockContext.Setup(mck => mck.Categorias.FindAsync(14)).ReturnsAsync(_categoria);

            _mockContext.Setup(mck => mck.SetModified(_categoria));

            _mockContext.Setup(mck => mck.SaveChangesAsync(It.IsAny<CancellationToken>()))
                .ReturnsAsync(14);
        }


        [Fact]
        public async Task Get_Categoria()
        {
            var service = new CategoriasController(_mockContext.Object);

            await service.GetCategoria(14);

            _mockSet.Verify(mck => mck.FindAsync(14), Times.Once());

        }

        [Fact]
        public async Task Post_Categoria()
        {
            var service = new CategoriasController(_mockContext.Object);

            await service.PostCategoria(_categoria);

            _mockSet.Verify(xAdicionar => xAdicionar.Add(_categoria), Times.Once());

            _mockContext.Verify(mck => mck.SaveChangesAsync(It.IsAny<CancellationToken>()), Times.Once());

        }

        [Fact]
        public async Task Put_Categoria()
        {
            var service = new CategoriasController(_mockContext.Object);

            await service.PutCategoria(14, _categoria);

            _mockContext.Verify(mck => mck.SaveChangesAsync(It.IsAny<CancellationToken>()), Times.Once());
        }

        [Fact]
        public async Task Delete_Categoria()
        {
            var service = new CategoriasController(_mockContext.Object);

            await service.DeleteCategoria(14);

            _mockSet.Verify(xExcluir => xExcluir.Remove(_categoria), Times.Once());

            _mockContext.Verify(mck => mck.SaveChangesAsync(It.IsAny<CancellationToken>()), Times.Once());

        }

    }
}
