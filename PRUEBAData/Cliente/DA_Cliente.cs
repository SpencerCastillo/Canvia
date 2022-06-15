using Microsoft.Extensions.Configuration;
using PRUEBAImplementacion.Cliente;
using RRHHMethods;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PRUEBAEntity;
namespace PRUEBAData.Cliente
{
    public class DA_Cliente
    {
        //public readonly IConfiguration Configuration;
        private SQLServer sqlServer;

        public DA_Cliente()
        {
            sqlServer = new SQLServer();
        }
        /*
        public DA_Cliente(IConfiguration config)
        {
            Configuration = config;
            sqlServer = new SQLServer(config);
        }
        */


        public ClienteResponse CreateUpdateCliente(ClienteRequest request)
        {
            var response = new ClienteResponse();
            SqlDataReader result = null;
            var tipo = request.Cliente.inIdCliente == 0 ? 1 : 2;

            try
            {
                List<SqlParameter> sp = new List<SqlParameter>() {
                    new SqlParameter { ParameterName = "@inIdCliente", Value = request.Cliente.inIdCliente},
                    new SqlParameter { ParameterName = "@chTipoPersona", Value = request.Cliente.chTipoPersona},
                    new SqlParameter { ParameterName = "@vcNumeroDocumento", Value = request.Cliente.vcNumeroDocumento},
                    new SqlParameter { ParameterName = "@nvApellidoPaterno", Value = request.Cliente.nvApellidoPaterno},
                    new SqlParameter { ParameterName = "@nvApellidoMaterno", Value = request.Cliente.nvApellidoMaterno},
                    new SqlParameter { ParameterName = "@nvNombres", Value = request.Cliente.nvNombres},
                    new SqlParameter { ParameterName = "@vcRazonSocial", Value = request.Cliente.vcRazonSocial},
                    new SqlParameter { ParameterName = "@vcEmail", Value = request.Cliente.vcEmail},
                    new SqlParameter { ParameterName = "@vcDireccion", Value = request.Cliente.vcDireccion},
                    new SqlParameter { ParameterName = "@chSexo", Value = request.Cliente.chSexo},
                    new SqlParameter { ParameterName = "@inType", Value = tipo },

                    new SqlParameter { ParameterName = "@inCodUsuario_Aud", Value = request.Cliente.inCodUsuario_Aud },
                    new SqlParameter { ParameterName = "@vcNomSistemaOperacion_Aud", Value = "PRUEBA" },
                    new SqlParameter { ParameterName = "@vcModuloSistema_Aud", Value = "CLIENTES" },
                    new SqlParameter { ParameterName = "@vcNomTerminalRegistro_Aud", Value = Environment.MachineName },
                    new SqlParameter { ParameterName = "@vcIPTerminalRegistro_Aud", Value = sqlServer.ObtenerIP() }
                };

                result = sqlServer.CRUDValues("[FACT].[usp_insertar_update_cliente]", sp);

                if (result.Read())
                {
                    response.inCodigoRespuesta = LeerReader.getCampoReader<int>(result, "inCodigoRespuesta", 0);
                    response.vcMensaje = LeerReader.getCampoReader<string>(result, "vcMensaje", "");
                    response.vcStatus = LeerReader.getCampoReader<string>(result, "vcStatus", "");
                    response.inIdGenerado = LeerReader.getCampoReader<int>(result, "inIdGenerado", 0);
                }
            }
            catch (Exception excepcion)
            {
                response.inCodigoRespuesta = 404;
                response.vcStatus = "error";
                response.vcMensaje = "Error al procesar datos " + excepcion;
            }
            return response;
        }

        public ClienteResponse AnularCliente(ClienteRequest request)
        {
            var response = new ClienteResponse();
            SqlDataReader result = null;

            try
            {
                List<SqlParameter> sp = new List<SqlParameter>()
                {
                    new SqlParameter{ ParameterName = "@inIdCliente", Value = request.Cliente.inIdCliente },
                    new SqlParameter{ ParameterName = "@biNoEliminadoLogicoBD", Value = request.Cliente.biNoEliminadoLogicoBD },

                    new SqlParameter { ParameterName = "@inCodUsuario_Aud", Value = request.Cliente.inCodUsuario_Aud },
                    new SqlParameter { ParameterName = "@vcNomTerminalRegistro_Aud", Value = Environment.MachineName },
                    new SqlParameter { ParameterName = "@vcIPTerminalRegistro_Aud", Value = sqlServer.ObtenerIP() }
                };

                result = sqlServer.CRUDValues("[FACT].[usp_anular_cliente]", sp);

                if (result.Read())
                {
                    response.inCodigoRespuesta = LeerReader.getCampoReader<int>(result, "inCodigoRespuesta", 0);
                    response.vcMensaje = LeerReader.getCampoReader<string>(result, "vcMensaje", "");
                    response.vcStatus = LeerReader.getCampoReader<string>(result, "vcStatus", "");
                    response.inIdGenerado = LeerReader.getCampoReader<int>(result, "inIdGenerado", 0);
                }
            }
            catch (Exception excepcion)
            {
                response.inCodigoRespuesta = 404;
                response.vcStatus = "error";
                response.vcMensaje = "Error al procesar datos " + excepcion;
            }

            return response;
        }


        public ClienteResponse EliminarCliente(int inIdCliente, int inCodUsuario_Aud)
        {
            var response = new ClienteResponse();
            SqlDataReader result = null;

            try
            {
                List<SqlParameter> sp = new List<SqlParameter>()
                {
                    new SqlParameter{ ParameterName = "@inIdCliente", Value = inIdCliente },
                    new SqlParameter { ParameterName = "@inCodUsuario_Aud", Value = inCodUsuario_Aud },
                    new SqlParameter { ParameterName = "@vcNomTerminalRegistro_Aud", Value = Environment.MachineName },
                    new SqlParameter { ParameterName = "@vcIPTerminalRegistro_Aud", Value = sqlServer.ObtenerIP() }
                };

                result = sqlServer.CRUDValues("[FACT].[usp_eliminar_cliente]", sp);

                if (result.Read())
                {
                    response.inCodigoRespuesta = LeerReader.getCampoReader<int>(result, "inCodigoRespuesta", 0);
                    response.vcMensaje = LeerReader.getCampoReader<string>(result, "vcMensaje", "");
                    response.vcStatus = LeerReader.getCampoReader<string>(result, "vcStatus", "");
                    response.inIdGenerado = LeerReader.getCampoReader<int>(result, "inIdGenerado", 0);
                }
            }
            catch (Exception excepcion)
            {
                response.inCodigoRespuesta = 404;
                response.vcStatus = "error";
                response.vcMensaje = "Error al procesar datos " + excepcion;
            }

            return response;
        }

        public ClienteResponse ListarCliente(FilterCliente filter)
        {
            var response = new ClienteResponse();

            try
            {
                List<SqlParameter> sp = new List<SqlParameter>()
                {
                    new SqlParameter { ParameterName = "@vcNumeroDocumento", Value = filter.vcNumeroDocumento },
                    new SqlParameter { ParameterName = "@nvNombres", Value = filter.nvNombres },
                    new SqlParameter { ParameterName = "@biNoEliminadoLogicoBD", Value = filter.biNoEliminadoLogicoBD },
                    new SqlParameter { ParameterName = "@pageIndex", Value = filter.pageIndex },
                    new SqlParameter { ParameterName = "@pageSize", Value = filter.pageSize },
                    new SqlParameter { ParameterName = "@inCodUsuario_Aud", Value = filter.inCodUsuario_Aud },
                    new SqlParameter { ParameterName = "@vcNomSistemaOperacion_Aud", Value = "PRUEBA" },
                    new SqlParameter { ParameterName = "@vcModuloSistema_Aud", Value = "LISTA CLIENTE" },
                    new SqlParameter { ParameterName = "@vcNomTerminalRegistro_Aud", Value = Environment.MachineName },
                    new SqlParameter { ParameterName = "@vcIPTerminalRegistro_Aud", Value = sqlServer.ObtenerIP() }
                };
                response.Clientes = sqlServer.ReadValueSP<BE_MAE_CLIENTE>("[FACT].[usp_listar_cliente]", sp);
                response.Total = response.Clientes.Count;
            }
            catch (Exception excepcion)
            {
                response.inCodigoRespuesta = 404;
                response.vcStatus = "error";
                response.vcMensaje = "Error al procesar datos " + excepcion;
            }

            return response;
        }

        public ClienteResponse ObtenerCliente(int inIdCliente, int inCodUsuario_Aud)
        {
            var response = new ClienteResponse();

            try
            {
                List<SqlParameter> sp = new List<SqlParameter>() {
                    new SqlParameter { ParameterName = "@inIdCliente", Value = inIdCliente },
                    new SqlParameter { ParameterName = "@inCodUsuario_Aud", Value = inCodUsuario_Aud },
                    new SqlParameter { ParameterName = "@vcNomSistemaOperacion_Aud", Value = "PRUEBA" },
                    new SqlParameter { ParameterName = "@vcModuloSistema_Aud", Value = "OBTENER CLIENTE" },
                    new SqlParameter { ParameterName = "@vcNomTerminalRegistro_Aud", Value = Environment.MachineName },
                    new SqlParameter { ParameterName = "@vcIPTerminalRegistro_Aud", Value = sqlServer.ObtenerIP() }
                };

                response.Cliente = sqlServer.ReadValueSP<BE_MAE_CLIENTE>("[FACT].[usp_obtener_cliente]", sp)[0];
            }
            catch (Exception excepcion)
            {
                response.inCodigoRespuesta = 404;
                response.vcStatus = "error";
                response.vcMensaje = "Error al procesar datos " + excepcion;
            }

            return response;
        }

        public ClienteResponse ListarTodosClientes( int inCodUsuario_Aud)
        {
            var response = new ClienteResponse();

            try
            {
                List<SqlParameter> sp = new List<SqlParameter>() {
                  
                    new SqlParameter { ParameterName = "@inCodUsuario_Aud", Value = inCodUsuario_Aud },
                    new SqlParameter { ParameterName = "@vcNomSistemaOperacion_Aud", Value = "PRUEBA" },
                    new SqlParameter { ParameterName = "@vcModuloSistema_Aud", Value = "LISTAR TODOS CLIENTES" },
                    new SqlParameter { ParameterName = "@vcNomTerminalRegistro_Aud", Value = Environment.MachineName },
                    new SqlParameter { ParameterName = "@vcIPTerminalRegistro_Aud", Value = sqlServer.ObtenerIP() }
                };

                response.Clientes = sqlServer.ReadValueSP<BE_MAE_CLIENTE>("[FACT].[usp_listar_todos_clientes]", sp);
            }
            catch (Exception excepcion)
            {
                response.inCodigoRespuesta = 404;
                response.vcStatus = "error";
                response.vcMensaje = "Error al procesar datos " + excepcion;
            }

            return response;
        }


    }
}
