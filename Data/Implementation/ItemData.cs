using Core.Entities.Company;
using Core.Entities.Producto;
using Data.Interfaces;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Implementation
{
    public class ItemData: IItemData
    {
        IConfiguration _configuration;

        public ItemData(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public List<ItemLote> GetLotesPorItem(Item item)
        {
            List<ItemLote> result = new List<ItemLote>();
            try
            {
                string string_connection = _configuration.GetConnectionString("DatabaseConnectionSAP");
                StoreProcedure consulta = new StoreProcedure(
                    @$"SELECT T0.[WhsCode] as 'Almacen', T0.[ItemCode] as 'CodigoArticulo', T1.[ItemName] as 'NombreArticulo', 
                    T0.[BatchNum] as 'NumeroLote', T0.[Quantity] as 'Stock', T0.[ExpDate] as 'FechaVencimiento'
                    FROM OIBT T0  INNER JOIN OITM T1 ON T0.[ItemCode] = T1.[ItemCode] 
                    WHERE T0.[ItemCode] = '{item.ItemCode}' and T0.[Quantity] <>0"
                );
                DataTable dt = consulta.EjecutarConsulta(string_connection);
                if (string.IsNullOrEmpty(consulta.Error))
                {
                    foreach (DataRow articulo in dt.Rows)
                    {
                        ItemLote c = new ItemLote();
                        c.Almacen = articulo["Almacen"].ToString();
                        c.CodigoArticulo = articulo["CodigoArticulo"].ToString();
                        c.NombreArticulo = articulo["NombreArticulo"].ToString();
                        c.NumeroLote = articulo["NumeroLote"].ToString();
                        c.Stock = Convert.ToDouble(articulo["Stock"]);
                        // c.FechaVencimiento = Convert.ToDateTime(articulo["FechaVencimiento"]);
                        c.FechaVencimiento = articulo["FechaVencimiento"] != DBNull.Value ? c.FechaVencimiento = Convert.ToDateTime(articulo["FechaVencimiento"]) : c.FechaVencimiento = null;
                        result.Add(c);
                    }
                }
                else
                {
                    throw new Exception(consulta.Error);
                }

            }
            catch (Exception ex)
            {

            }
            return result;
        }

        public List<ItemLote> GetLotesPorItemAll()
        {
            List<ItemLote> result = new List<ItemLote>();
            try
            {
                string string_connection = _configuration.GetConnectionString("DatabaseConnectionSAP");
                StoreProcedure consulta = new StoreProcedure(
                    @$"SELECT T0.[WhsCode] as 'Almacen', T0.[ItemCode] as 'CodigoArticulo', T1.[ItemName] as 'NombreArticulo', 
                    T0.[BatchNum] as 'NumeroLote', T0.[Quantity] as 'Stock', T0.[ExpDate] as 'FechaVencimiento'
                    FROM OIBT T0  INNER JOIN OITM T1 ON T0.[ItemCode] = T1.[ItemCode]"
                );
                DataTable dt = consulta.EjecutarConsulta(string_connection);
                if (string.IsNullOrEmpty(consulta.Error))
                {
                    foreach (DataRow articulo in dt.Rows)
                    {
                        ItemLote c = new ItemLote();
                        c.Almacen = articulo["Almacen"].ToString();
                        c.CodigoArticulo = articulo["CodigoArticulo"].ToString();
                        c.NombreArticulo = articulo["NombreArticulo"].ToString();
                        c.NumeroLote = articulo["NumeroLote"].ToString();
                        c.Stock = Convert.ToDouble(articulo["Stock"]);
                        // c.FechaVencimiento = Convert.ToDateTime(articulo["FechaVencimiento"]);
                        c.FechaVencimiento = articulo["FechaVencimiento"] != DBNull.Value ? c.FechaVencimiento = Convert.ToDateTime(articulo["FechaVencimiento"]) : c.FechaVencimiento = null;
                        result.Add(c);
                    }
                }
                else
                {
                    throw new Exception(consulta.Error);
                }

            }
            catch (Exception ex)
            {
                // throw new Exception($"Error al obtener los datos: {ex.Message}");
            }
            return result;
        }
    }
}
