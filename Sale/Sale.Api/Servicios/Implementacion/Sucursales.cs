using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Sale.Api.Intefaz;
using Sale.Shared.Modelo.DTO;
using Sale.Shared.Modelo.Entidades;

namespace Sale.Api.Servicios.Implementacion
{
    public class Sucursales: ISucursales
    {
        public readonly IGenericoModelo<Sucursal> _modeloRepositorio;
        public readonly IMapper _mapper;
        // private object fromDBmodelo;
        public Sucursales(IGenericoModelo<Sucursal> modeloRepositorio, IMapper mapper)
        {
            _modeloRepositorio = modeloRepositorio;
            _mapper = mapper;
        }
        public async Task<SucursalDTO> CreateSucursal(SucursalDTO modelo)
        {
            try
            {
                var dbModelo = _mapper.Map<Sucursal>(modelo);

                var RspModelo = await _modeloRepositorio.CreateReg(dbModelo);
                if (RspModelo.Id_sucursal != 0)
                    return _mapper.Map<SucursalDTO>(RspModelo);
                else
                    throw new TaskCanceledException("Nose puede crear");

            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<bool> DeleteSucursal(int id)
        {
            try
            {
                var consulta = _modeloRepositorio.GetAllWithWhere(p => p.Id_sucursal == id);
                var fromDbmodelo = await consulta.FirstOrDefaultAsync();
                if (fromDbmodelo != null)
                {
                    var respuesta = await _modeloRepositorio.Delete(fromDbmodelo);
                    if (!respuesta)
                        throw new TaskCanceledException("No se puedo Eliminar");
                    return respuesta;
                }
                else
                { throw new TaskCanceledException("No nose encontraron datos"); }

            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<bool> DeleteSucursalLogica(int id)
        {
            try
            {
                var consulta = _modeloRepositorio.GetAllWithWhere(p => p.Id_sucursal == id);
                var fromDbmodelo = await consulta.FirstOrDefaultAsync();
                if (fromDbmodelo != null)
                {
                    fromDbmodelo.Estado_sucursal = "I";
                    var respuesta = await _modeloRepositorio.Upadate(fromDbmodelo);
                    if (!respuesta)
                        throw new TaskCanceledException("No se puedo Eliminar");
                    return respuesta;
                }
                else
                { throw new TaskCanceledException("No nose encontraron datos"); }

            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<List<SucursalDTO>> GetListaAllSucursales()
        {

            try
            {
                var consulta = _modeloRepositorio.GetAll().OrderBy(m => m.Id_sucursal);
                List<SucursalDTO> lista = _mapper.Map<List<SucursalDTO>>(await consulta.ToListAsync());
                return lista;

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public async Task<List<SucursalDTO>> GetListSucursalActivo(string Estado_Activo)
        {
            try
            {
                ///con referencia
                var consulta = _modeloRepositorio.GetAllWithWhere(p => p.Estado_sucursal == Estado_Activo);

                var fromDBmodelo = await consulta.ToListAsync();
                if (fromDBmodelo != null && fromDBmodelo.Any())
                {
                    return _mapper.Map<List<SucursalDTO>>(fromDBmodelo);
                }
                else
                { throw new TaskCanceledException("No nose encontraron considencia"); }

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<SucursalDTO> GetSucursal(int id)
        {
            try
            {
                var consulta = _modeloRepositorio.GetAllWithWhere(p => p.Id_sucursal == id);
                var fromDBmodelo = await consulta.FirstOrDefaultAsync();
                if (fromDBmodelo != null)
                {
                    return _mapper.Map<SucursalDTO>(fromDBmodelo);
                }
                else
                { throw new TaskCanceledException("No nose encontraron considencia"); }

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<List<SucursalDropDTO>> GetSucursalCombo(string Estado_Activo)
        {
            try
            {
                var consulta = _modeloRepositorio.GetAllWithWhere(x => x.Estado_sucursal == Estado_Activo).OrderBy(m => m.Id_sucursal);
                List<SucursalDropDTO> lista = _mapper.Map<List<SucursalDropDTO>>(await consulta.ToListAsync());
                return lista;

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<string> GetSucursalName(int id)
        {
            try
            {
                var consulta = await _modeloRepositorio.GetAllWithWhere(p => p.Id_sucursal == id).FirstOrDefaultAsync();
                if (consulta != null)
                {
                    return consulta.Nombre_sucursal ?? "";

                }
                else
                { throw new TaskCanceledException("No nose encontraron datos"); }

            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<bool> UpdateSucursal(SucursalDTO modelo)
        {
            try
            {
                var consulta = _modeloRepositorio.GetAllWithWhere(p => p.Id_sucursal == modelo.Id_sucursal);
                var fromDbmodelo = await consulta.FirstOrDefaultAsync();
                if (fromDbmodelo != null)
                {
                    fromDbmodelo.Nombre_sucursal = modelo.Nombre_sucursal;
                    fromDbmodelo.Id_empresa = modelo.Id_empresa;
                    fromDbmodelo.Id_pais = modelo.Id_pais;
                    fromDbmodelo.Id_provincia = modelo.Id_provincia;
                    fromDbmodelo.Id_ciudad = modelo.Id_ciudad;
                    fromDbmodelo.Direccion_sucursal = modelo.Direccion_sucursal;
                    fromDbmodelo.Cap_sucursal = modelo.Cap_sucursal;
                    fromDbmodelo.Telefono = modelo.Telefono;
                    fromDbmodelo.Telefono_secundario = modelo.Telefono_secundario;
                    fromDbmodelo.Email = modelo.Email;
                    fromDbmodelo.Id_persona = modelo.Id_persona;
                    fromDbmodelo.Horario_atencion = modelo.Horario_atencion;
                    fromDbmodelo.Informacion_sucursal = modelo.Informacion_sucursal;
                    fromDbmodelo.Estado_sucursal = modelo.Estado_sucursal;
                    var respuesta = await _modeloRepositorio.Upadate(fromDbmodelo);
                    if (!respuesta)
                        throw new TaskCanceledException("No se puedo Editar");
                    return respuesta;
                }
                else
                { throw new TaskCanceledException("No nose encontraron datos"); }

            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
