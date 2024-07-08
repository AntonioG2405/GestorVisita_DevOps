using GestorVisita.Data.Context;
using GestorVisita.Data.Daos;
using GestorVisita.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel;

namespace GestorVisitas.Data.Test
{
    public class Tests
    {
        private GV_Context _context;
        private DaoVisita _dao;


        [SetUp]
        public void ConfigurarContexto()
        {
            // Configurar un contexto en memoria para las pruebas
            var options = new DbContextOptionsBuilder<GV_Context>()
                .UseInMemoryDatabase(databaseName: "Gestor_Visita")
                .Options;
            _context = new GV_Context(options);
            _dao = new DaoVisita(_context);
        }

        [TearDown]
        public void LimpiarContexto()
        {
            // Limpiar el contexto después de cada prueba
            _context.Database.EnsureDeleted();
            _context.Dispose();
        }

        [Test]
        public void AgregarVisita_VisitaValida()
        {
            // Arrange
            var visita = new Visita { Id = 1, NombreVisitante = "Visita de prueba", MotivoVisita = "Emtregar Tarea", Fecha = DateTime.Now };

            // Act
            _dao.AddVisita(visita);

            // Assert
            Assert.AreEqual(1, _context.Visitas.Count());
            var visitaGuardada = _context.Visitas.First();
            Assert.AreEqual(visita.NombreVisitante, visitaGuardada.NombreVisitante);
        }

        [Test]
        public void ActualizarVisita_VisitaValida()
        {
            // Arrange
            var visitaOriginal = new Visita { Id = 1, NombreVisitante = "Visita original", MotivoVisita = "Motivo original", Fecha = DateTime.Now };
            _context.Visitas.Add(visitaOriginal);
            _context.SaveChanges();

            // Desvincular la entidad original del contexto
            _context.Entry(visitaOriginal).State = EntityState.Detached;

            var visitaActualizada = new Visita { Id = 1, NombreVisitante = "Visita actualizada", MotivoVisita = "Motivo Actualizado", Fecha = DateTime.Now };

            // Act
            _dao.UpdateVisita(visitaActualizada);

            // Assert
            var visitaGuardada = _context.Visitas.Find(1);
            Assert.AreEqual(visitaActualizada.NombreVisitante, visitaGuardada.NombreVisitante);
        }


        [Test]
        public void EliminarVisita_IdValido()
        {
            // Arrange
            var visita = new Visita { Id = 1, NombreVisitante = "Visita de prueba", MotivoVisita = "Emtregar Tarea", Fecha = DateTime.Now };
            _context.Visitas.Add(visita);
            _context.SaveChanges();

            // Act
            _dao.DeleteVisita(1);

            // Assert
            Assert.AreEqual(0, _context.Visitas.Count());
        }

        [Test]
        public void EliminarVisita_IdInvalido()
        {
            // Arrange & Act & Assert
            Assert.Throws<ArgumentNullException>(() => _dao.DeleteVisita(0));
        }

        [Test]
        public void ObtenerVisitas()
        {
            // Arrange
            _context.Visitas.Add(new Visita { Id = 1, NombreVisitante = "Visita 1", MotivoVisita = "Motivo1", Fecha = DateTime.Now });
            _context.Visitas.Add(new Visita { Id = 2, NombreVisitante = "Visita 2", MotivoVisita = "Motivo2", Fecha = DateTime.Now });
            _context.SaveChanges();

            // Act
            var visitas = _dao.GetVisitas();

            // Assert
            Assert.AreEqual(2, visitas.Count);
        }


        [Test]
        public void ObtenerVisitaPorId_IdValido()
        {
            // Arrange
            var visitaEsperada = new Visita { Id = 1, NombreVisitante = "Visita de prueba", MotivoVisita = "Emtregar Tarea", Fecha = DateTime.Now };
            _context.Visitas.Add(visitaEsperada);
            _context.SaveChanges();

            // Act
            var visitaObtenida = _dao.GetVisitaById(1);

            // Assert
            Assert.IsNotNull(visitaObtenida);
            Assert.AreEqual(visitaEsperada.Id, visitaObtenida.Id);
            Assert.AreEqual(visitaEsperada.NombreVisitante, visitaObtenida.NombreVisitante);
        }
    }
}