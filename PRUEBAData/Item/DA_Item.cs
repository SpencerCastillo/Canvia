using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PRUEBAEntity;
using Microsoft.Extensions.Configuration;
using PRUEBAImplementacion.Item;
using RRHHMethods;
using System.Data.SqlClient;
namespace PRUEBAData.Item
{
    public class DA_Item
    {


        private SQLServer sqlServer;

        public DA_Item()
        {
            sqlServer = new SQLServer();
        }
       


        public ItemResponse CreateUpdateItem(ItemRequest request)
        {
            var response = new ItemResponse();
            SqlDataReader result = null;
            var tipo = request.Item.inIdItem == 0 ? 1 : 2;

            try
            {
                List<SqlParameter> sp = new List<SqlParameter>() {
                    new SqlParameter { ParameterName = "@inIdItem", Value = request.Item.inIdItem},
                    new SqlParameter { ParameterName = "@vcDescripcionItem", Value = request.Item.vcDescripcionItem},
                    new SqlParameter { ParameterName = "@dePrecio", Value = request.Item.dePrecio},
                    new SqlParameter { ParameterName = "@inStockMinimo", Value = request.Item.inStockMinimo},
                    new SqlParameter { ParameterName = "@inType", Value = tipo },

                    new SqlParameter { ParameterName = "@inCodUsuario_Aud", Value = request.Item.inCodUsuario_Aud },
                    new SqlParameter { ParameterName = "@vcNomSistemaOperacion_Aud", Value = "PRUEBA" },
                    new SqlParameter { ParameterName = "@vcModuloSistema_Aud", Value = "ITEMS" },
                    new SqlParameter { ParameterName = "@vcNomTerminalRegistro_Aud", Value = Environment.MachineName },
                    new SqlParameter { ParameterName = "@vcIPTerminalRegistro_Aud", Value = sqlServer.ObtenerIP() }
                };

                result = sqlServer.CRUDValues("[FACT].[usp_insertar_update_item]", sp);

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

        public ItemResponse AnularItem(ItemRequest request)
        {
            var response = new ItemResponse();
            SqlDataReader result = null;

            try
            {
                List<SqlParameter> sp = new List<SqlParameter>()
                {
                    new SqlParameter{ ParameterName = "@inIdItem", Value = request.Item.inIdItem },
                    new SqlParameter{ ParameterName = "@biNoEliminadoLogicoBD", Value = request.Item.biNoEliminadoLogicoBD },

                    new SqlParameter { ParameterName = "@inCodUsuario_Aud", Value = request.Item.inCodUsuario_Aud },
                    new SqlParameter { ParameterName = "@vcNomTerminalRegistro_Aud", Value = Environment.MachineName },
                    new SqlParameter { ParameterName = "@vcIPTerminalRegistro_Aud", Value = sqlServer.ObtenerIP() }
                };

                result = sqlServer.CRUDValues("[FACT].[usp_anular_item]", sp);

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


        public ItemResponse EliminarItem(int inIdItem, int inCodUsuario_Aud)
        {
            var response = new ItemResponse();
            SqlDataReader result = null;

            try
            {
                List<SqlParameter> sp = new List<SqlParameter>()
                {
                    new SqlParameter{ ParameterName = "@inIdItem", Value = inIdItem },
                    new SqlParameter { ParameterName = "@inCodUsuario_Aud", Value = inCodUsuario_Aud },
                    new SqlParameter { ParameterName = "@vcNomTerminalRegistro_Aud", Value = Environment.MachineName },
                    new SqlParameter { ParameterName = "@vcIPTerminalRegistro_Aud", Value = sqlServer.ObtenerIP() }
                };

                result = sqlServer.CRUDValues("[FACT].[usp_eliminar_item]", sp);

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

        public ItemResponse ListarItem(FilterItem filter)
        {
            var response = new ItemResponse();

            try
            {
                List<SqlParameter> sp = new List<SqlParameter>()
                {
                    new SqlParameter { ParameterName = "@vcDescripcionItem", Value = filter.vcDescripcionItem },
                    new SqlParameter { ParameterName = "@biNoEliminadoLogicoBD", Value = filter.biNoEliminadoLogicoBD },
                    new SqlParameter { ParameterName = "@pageIndex", Value = filter.pageIndex },
                    new SqlParameter { ParameterName = "@pageSize", Value = filter.pageSize },
                    new SqlParameter { ParameterName = "@inCodUsuario_Aud", Value = filter.inCodUsuario_Aud },
                    new SqlParameter { ParameterName = "@vcNomSistemaOperacion_Aud", Value = "PRUEBA" },
                    new SqlParameter { ParameterName = "@vcModuloSistema_Aud", Value = "LISTA ITEM" },
                    new SqlParameter { ParameterName = "@vcNomTerminalRegistro_Aud", Value = Environment.MachineName },
                    new SqlParameter { ParameterName = "@vcIPTerminalRegistro_Aud", Value = sqlServer.ObtenerIP() }
                };
                response.Items = sqlServer.ReadValueSP<BE_MAE_ITEM>("[FACT].[usp_listar_item]", sp);
                response.Total = response.Items.Count;
            }
            catch (Exception excepcion)
            {
                response.inCodigoRespuesta = 404;
                response.vcStatus = "error";
                response.vcMensaje = "Error al procesar datos " + excepcion;
            }

            return response;
        }

        public ItemResponse ObtenerItem(int inIdItem, int inCodUsuario_Aud)
        {
            var response = new ItemResponse();

            try
            {
                List<SqlParameter> sp = new List<SqlParameter>() {
                    new SqlParameter { ParameterName = "@inIdItem", Value = inIdItem },
                    new SqlParameter { ParameterName = "@inCodUsuario_Aud", Value = inCodUsuario_Aud },
                    new SqlParameter { ParameterName = "@vcNomSistemaOperacion_Aud", Value = "PRUEBA" },
                    new SqlParameter { ParameterName = "@vcModuloSistema_Aud", Value = "OBTENER ITEM" },
                    new SqlParameter { ParameterName = "@vcNomTerminalRegistro_Aud", Value = Environment.MachineName },
                    new SqlParameter { ParameterName = "@vcIPTerminalRegistro_Aud", Value = sqlServer.ObtenerIP() }
                };

                response.Item = sqlServer.ReadValueSP<BE_MAE_ITEM>("[FACT].[usp_obtener_item]", sp)[0];
            }
            catch (Exception excepcion)
            {
                response.inCodigoRespuesta = 404;
                response.vcStatus = "error";
                response.vcMensaje = "Error al procesar datos " + excepcion;
            }

            return response;
        }

        public ItemResponse ListarTodosItems(int inCodUsuario_Aud)
        {
            var response = new ItemResponse();

            try
            {
                List<SqlParameter> sp = new List<SqlParameter>() {

                    new SqlParameter { ParameterName = "@inCodUsuario_Aud", Value = inCodUsuario_Aud },
                    new SqlParameter { ParameterName = "@vcNomSistemaOperacion_Aud", Value = "PRUEBA" },
                    new SqlParameter { ParameterName = "@vcModuloSistema_Aud", Value = "LISTAR TODOS ITEMS" },
                    new SqlParameter { ParameterName = "@vcNomTerminalRegistro_Aud", Value = Environment.MachineName },
                    new SqlParameter { ParameterName = "@vcIPTerminalRegistro_Aud", Value = sqlServer.ObtenerIP() }
                };

                response.Items = sqlServer.ReadValueSP<BE_MAE_ITEM>("[FACT].[usp_listar_todos_items]", sp);
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
