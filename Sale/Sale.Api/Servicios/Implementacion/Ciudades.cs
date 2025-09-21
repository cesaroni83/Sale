using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Sale.Api.Intefaz;
using Sale.Shared.Modelo.DTO;
using Sale.Shared.Modelo.Entidades;

namespace Sale.Api.Servicios.Implementacion
{
    public class Ciudades:ICiudades
    {
        public readonly IGenericoModelo<Ciudad> _modeloRepositorio;
        public readonly IMapper _mapper;
        // private object fromDBmodelo;
        public Ciudades(IGenericoModelo<Ciudad> modeloRepositorio, IMapper mapper)
        {
            _modeloRepositorio = modeloRepositorio;
            _mapper = mapper;
        }

        public async Task<CiudadDTO> CreateCiudad(CiudadDTO modelo)
        {
            try
            {
                var dbModelo = _mapper.Map<Ciudad>(modelo);

                var RspModelo = await _modeloRepositorio.CreateReg(dbModelo);
                if (RspModelo.Id_pais != 0)
                    return _mapper.Map<CiudadDTO>(RspModelo);
                else
                    throw new TaskCanceledException("Nose puede crear");

            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<bool> DeleteCiudad(int id)
        {
            try
            {
                var consulta = _modeloRepositorio.GetAllWithWhere(p => p.Id_ciudad == id);
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

        public async Task<bool> DeleteCiudadLogica(int id_ciudad)
        {
            try
            {
                var consulta = _modeloRepositorio.GetAllWithWhere(p => p.Id_ciudad == id_ciudad);
                var fromDbmodelo = await consulta.FirstOrDefaultAsync();
                if (fromDbmodelo != null)
                {
                    fromDbmodelo.Estado_ciudad = "I";
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

        public async Task<List<CiudadDTO>> GetListaAllCiudades()
        {

            try
            {
                var consulta = _modeloRepositorio.GetAll().OrderBy(m => m.Id_ciudad);
                List<CiudadDTO> lista = _mapper.Map<List<CiudadDTO>>(await consulta.ToListAsync());
                return lista;

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public async Task<List<CiudadDTO>> GetListCiudadActivo(string Estado_Activo)
        {
            try
            {
                ///con referencia
                var consulta = _modeloRepositorio.GetAllWithWhere(p => p.Estado_ciudad == Estado_Activo);

                var fromDBmodelo = await consulta.ToListAsync();
                if (fromDBmodelo != null && fromDBmodelo.Any())
                {
                    return _mapper.Map<List<CiudadDTO>>(fromDBmodelo);
                }
                else
                { throw new TaskCanceledException("No nose encontraron considencia"); }

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<CiudadDTO> GetCiudad(int id)
        {
            try
            {
                var consulta = _modeloRepositorio.GetAllWithWhere(p => p.Id_ciudad == id);
                var fromDBmodelo = await consulta.FirstOrDefaultAsync();
                if (fromDBmodelo != null)
                {
                    return _mapper.Map<CiudadDTO>(fromDBmodelo);
                }
                else
                { throw new TaskCanceledException("No nose encontraron considencia"); }

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<List<CiudadDropDTO>> GetCiudadCombo(string Estado_Activo)
        {
            try
            {
                var consulta = _modeloRepositorio.GetAllWithWhere(x => x.Estado_ciudad == Estado_Activo).OrderBy(m => m.Id_pais);
                List<CiudadDropDTO> lista = _mapper.Map<List<CiudadDropDTO>>(await consulta.ToListAsync());
                return lista;

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<string> GetCiudadName(int id_ciudad)
        {
            try
            {
                var consulta = await _modeloRepositorio.GetAllWithWhere(p => p.Id_ciudad == id_ciudad).FirstOrDefaultAsync();
                if (consulta != null)
                {
                    return consulta.Nombre_ciudad ?? "";

                }
                else
                { throw new TaskCanceledException("No nose encontraron datos"); }

            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<bool> UpdateCiudad(CiudadDTO modelo)
        {
            try
            {
                var consulta = _modeloRepositorio.GetAllWithWhere(p => p.Id_ciudad == modelo.Id_ciudad);
                var fromDbmodelo = await consulta.FirstOrDefaultAsync();
                if (fromDbmodelo != null)
                {
                    fromDbmodelo.Id_pais = modelo.Id_pais;
                    fromDbmodelo.Id_provincia = modelo.Id_provincia;
                    fromDbmodelo.Nombre_ciudad = modelo.Nombre_ciudad;
                    fromDbmodelo.Informacion_ciudad = modelo.Informacion_ciudad;
                    fromDbmodelo.Estado_ciudad = modelo.Estado_ciudad;
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
