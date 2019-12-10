using System;
using System.Collections.Generic;
using System.Text;
using Dominio;
using Dominio.Entities;
using Infraestructura.Datos.Repositorios;

namespace Infraestructura.Utils
{
    public class UnitOfWork : IDisposable
    {
        public UnitOfWork()
        {
        }

        private readonly SgpContext context = new SgpContext();

        private List<GenericRepository<BaseEntity>> repositorios;

        private ActividadRepository actividadRepository = null;
        private CDPRepository _CDPRepository = null;
        private ComponenteRepository componenteRepository = null;
        private CompromisoRepository compromisoRepository = null;
        private ComunidadRepository comunidadRepository = null;
        private ConvenioRepository convenioRepository = null;
        private DimensionRepository dimensionRepository = null;
        private DocumentoRepository documentoRepository = null;
        private DocumentoPresupuestalRepository documentoPresupuestalRepository = null;
        private EstrategiaRepository estrategiaRepository = null;
        private ProgramaRepository programaRepository = null;
        private PropuestaRepository propuestaRepository = null;
        private ProyectoRepository proyectoRepository = null;
        private ProyectoComunidadRepository proyectoComunidadRepository = null;
        private RegistroPresupuestalRepository registroPresupuestalRepository = null;
        private TransaccionRepository transaccionRepository = null;
        private TransaccionUnariaRepository transaccionUnariaRepository = null;
        private TransaccionBinariaRepository transaccionBinariaRepository = null;
        private BeneficicarioRepository beneficicarioRepository = null;
        private IngresoOnceavaRepository ingresoOnceavaRepository = null;
        private EgresoRepository egresoRepository = null;
        private UserRepository userRepository = null;

        public BeneficicarioRepository BeneficicarioRepository
        {
            get
            {
                if (beneficicarioRepository == null)
                {
                    beneficicarioRepository = new BeneficicarioRepository(context);
                }
                return beneficicarioRepository;
            }
        }

        public ActividadRepository ActividadRepository
        {
            get
            {
                if (actividadRepository == null)
                {
                    actividadRepository = new ActividadRepository(context);
                }
                return actividadRepository;
            }
        }

        public CDPRepository CDPRepository
        {
            get
            {
                if (_CDPRepository == null)
                {
                    _CDPRepository = new CDPRepository(context);
                }
                return _CDPRepository;
            }
        }

        public ComponenteRepository ComponenteRepository
        {
            get
            {
                if (componenteRepository == null)
                {
                    componenteRepository = new ComponenteRepository(context);
                }
                return componenteRepository;
            }
        }

        public CompromisoRepository CompromisoRepository
        {
            get
            {
                if (compromisoRepository == null)
                {
                    compromisoRepository = new CompromisoRepository(context);
                }
                return compromisoRepository;
            }
        }

        public ComunidadRepository ComunidadRepository
        {
            get
            {
                if (comunidadRepository == null)
                {
                    comunidadRepository = new ComunidadRepository(context);
                }
                return comunidadRepository;
            }
        }

        public ConvenioRepository ConvenioRepository
        {
            get
            {
                if (convenioRepository == null)
                {
                    convenioRepository = new ConvenioRepository(context);
                }
                return convenioRepository;
            }
        }

        public DimensionRepository DimensionRepository
        {
            get
            {
                if (dimensionRepository == null)
                {
                    dimensionRepository = new DimensionRepository(context);
                }
                return dimensionRepository;
            }
        }

        public DocumentoRepository DocumentoRepository
        {
            get
            {
                if (documentoRepository == null)
                {
                    documentoRepository = new DocumentoRepository(context);
                }
                return documentoRepository;
            }
        }

        public DocumentoPresupuestalRepository DocumentoPresupuestalRepository
        {
            get
            {
                if (documentoPresupuestalRepository == null)
                {
                    documentoPresupuestalRepository = new DocumentoPresupuestalRepository(context);
                }
                return documentoPresupuestalRepository;
            }
        }

        public EstrategiaRepository EstrategiaRepository
        {
            get
            {
                if (estrategiaRepository == null)
                {
                    estrategiaRepository = new EstrategiaRepository(context);
                }
                return estrategiaRepository;
            }
        }

        public ProgramaRepository ProgramaRepository
        {
            get
            {
                if (programaRepository == null)
                {
                    programaRepository = new ProgramaRepository(context);
                }
                return programaRepository;
            }
        }

        public PropuestaRepository PropuestaRepository
        {
            get
            {
                if (propuestaRepository == null)
                {
                    propuestaRepository = new PropuestaRepository(context);
                }
                return propuestaRepository;
            }
        }

        public ProyectoRepository ProyectoRepository
        {
            get
            {
                if (proyectoRepository == null)
                {
                    proyectoRepository = new ProyectoRepository(context);
                }
                return proyectoRepository;
            }
        }

        public ProyectoComunidadRepository ProyectoComunidadRepository
        {
            get
            {
                if (proyectoComunidadRepository == null)
                {
                    proyectoComunidadRepository = new ProyectoComunidadRepository(context);
                }
                return proyectoComunidadRepository;
            }
        }

        public RegistroPresupuestalRepository RegistroPresupuestalRepository
        {
            get
            {
                if (registroPresupuestalRepository == null)
                {
                    registroPresupuestalRepository = new RegistroPresupuestalRepository(context);
                }
                return registroPresupuestalRepository;
            }

        }

        public TransaccionRepository TransaccionRepository
        {
            get
            {
                if (transaccionRepository == null)
                {
                    transaccionRepository = new TransaccionRepository(context);
                }
                return transaccionRepository;
            }
        }

        public TransaccionUnariaRepository TransaccionUnariaRepository
        {
            get
            {
                if (transaccionUnariaRepository == null)
                {
                    transaccionUnariaRepository = new TransaccionUnariaRepository(context);
                }
                return transaccionUnariaRepository;
            }
        }

        public TransaccionBinariaRepository TransaccionBinariaRepository{
            get
            {
                if(transaccionBinariaRepository == null)
                {
                    transaccionBinariaRepository = new TransaccionBinariaRepository(context);
                }
                return transaccionBinariaRepository;
            }
        }
        public IngresoOnceavaRepository IngresoOnceavaRepository
        {
            get
            {
                if (ingresoOnceavaRepository == null)
                {
                    ingresoOnceavaRepository = new IngresoOnceavaRepository(context);
                }
                return ingresoOnceavaRepository;
            }
        }

        public EgresoRepository EgresoRepository{
            get{
                if(egresoRepository == null){
                    egresoRepository = new EgresoRepository(context);
                }
                return egresoRepository;
            }
        }

        public UserRepository UserRepository{
            get{
                if(userRepository == null){
                    userRepository = new UserRepository(context);
                }
                return userRepository;
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
