using System;
using System.Collections.Generic;
using System.Text;
using Infraestructura.Datos.Repositorios;

namespace Infraestructura.Utils
{
    public class UnitOfWork : IDisposable
    {
        private readonly SgpContext context = new SgpContext();

        private ActividadRepository actividadRepository = null;
        private CertificadoDeDisponibilidadPresupuestalRepository CDPRepository = null;
        private ComponenteRepository componenteRepository = null;
        private CompromisoRepository compromisoRepository = null;
        private ComunidadRepository comunidadRepository = null;
        private ConvenioRepository convenioRepository = null;
        private DimensionRepository dimensionRepository = null;
        private DocumentoPresupuestalRepository documentoPresupuestalRepository = null;
        private EstrategiaRepository estrategiaRepository = null;
        private ProgramaRepository programaRepository = null;
        private ProyectoRepository proyectoRepository = null;
        private RegistroPresupuestalRepository registroPresupuestalRepository = null;
        private TransaccionRepository transaccionRepository = null;
        private PropuestaRepository propuestaRepository = null;

        public ActividadRepository ActividadRepository
        {
            get {
                if (actividadRepository == null)
                {
                    actividadRepository = new ActividadRepository(context);
                    return actividadRepository;
                }
            }
        }

        public CertificadoDeDisponibilidadPresupuestalRepository CertificadoDeDisponibilidadPresupuestalRepository
        {
            get
            {
                if (certificadoDeDisponibilidadPresupuestalRepository == null)
                {
                    CDPRepository = new CertificadoDeDisponibilidadPresupuestalRepository(context);
                    return CDPRepository;
                }
            }
        }

        public ComponenteRepository ComponenteRepository
        {
            get
            {
                if (componenteRepository == null)
                {
                    componenteRepository = new ComponenteRepository(context);
                    return componenteRepository;
                }
            }
        }

        public CompromisoRepository CompromisoRepository
        {
            get
            {
                if (compromisoRepository == null)
                {
                    compromisoRepository = new CompromisoRepository(context);
                    return compromisoRepository;
                }
            }
        }

        public ComunidadRepository ComunidadRepository
        {
            get
            {
                if (comunidadRepository == null)
                {
                    comunidadRepository = new ComunidadRepository(context);
                    return comunidadRepository;
                }
            }
        }

        public ConvenioRepository ConvenioRepository
        {
            get
            {
                if (convenioRepository == null)
                {
                    convenioRepository = new ConvenioRepository(context);
                    return convenioRepository;
                }
            }
        }

        public DimensionRepository DimensionRepository
        {
            get
            {
                if (dimensionRepository == null)
                {
                    dimensionRepository = new DimensionRepository(context);
                    return dimensionRepository;
                }
            }
        }

        public DocumentoPresupuestalRepository DocumentoPresupuestalRepository
        {
            get
            {
                if (documentoPresupuestalRepository == null)
                {
                    documentoPresupuestalRepository = new DocumentoPresupuestalRepository(context);
                    return documentoPresupuestalRepository;
                }
            }
        }

        public EstrategiaRepository EstrategiaRepository
        {
            get
            {
                if (estrategiaRepository == null)
                {
                    estrategiaRepository = new EstrategiaRepository(context);
                    return estrategiaRepository;
                }
            }
        }

        public ProgramaRepository ProgramaRepository
        {
            get
            {
                if (programaRepository == null)
                {
                    programaRepository = new ProgramaRepository(context);
                    return programaRepository;
                }
            }
        }

        public PropuestaRepository PropuestaRepository
        {
            get {
                if (propuestaRepository == null) {
                    propuestaRepository = new PropuestaRepository(context);
                    return propuestaRepository;
                }
            }
        }

        public ProyectoRepository ProyectoRepository
        {
            get
            {
                if (proyectoRepository == null)
                {
                    proyectoRepository = new ProyectoRepository(context);
                    return proyectoRepository;
                }
            }
        }

        public RegistroPresupuestalRepository RegistroPresupuestalRepository
        {
            get
            {
                if (registroPresupuestalRepository == null)
                {
                    registroPresupuestalRepository = new RegistroPresupuestalRepository(context);
                    return registroPresupuestalRepository;
                }
            }

        }

        public TransaccionRepository TransaccionRepository{
            get
            {
                if(transaccionRepository == null){
                    transaccionRepository = new TransaccionRepository(context);
                    return transaccionRepository;
                }
            }
        }

        public void Save()
        {
            context.SaveChanges();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
