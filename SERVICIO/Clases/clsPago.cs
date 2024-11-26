using SERVICIO.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace SERVICIO.Clases
{
    public class clsPago
    {
        private AcademiaSistemasEntities1 academiaSistemasEntities1 = new AcademiaSistemasEntities1();

        public Pago pago { get; set; }
        public DetallePago detallePago { get; set; }
        public string GrabarPago()
        {
            if(pago.Id == 0)
            {
                return GrabarEncabezado();
            }
            return GrabarDetalle();

        }
        public string GrabarEncabezado()
        {
            try
            {
                pago.Id = GenerarNumeroPago();
                pago.FechaPago = DateTime.Now;
                academiaSistemasEntities1.Pagoes.Add(pago);
                academiaSistemasEntities1.SaveChanges();
                return pago.Id.ToString();
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
            
        }
        private int GenerarNumeroPago()
        {

            return academiaSistemasEntities1.Pagoes.Select(p => p.Id).DefaultIfEmpty(0).Max() + 1;
        }
        public string GrabarDetalle()
        {
            try
            {
                detallePago = pago.DetallePagoes.FirstOrDefault();
                academiaSistemasEntities1.DetallePagoes.Add(detallePago);
                academiaSistemasEntities1.SaveChanges();
                return pago.Id.ToString();
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
            
        }
        public IQueryable ListarCursos(int NumeroFactura)
        {
            return from D in academiaSistemasEntities1.Set<DetallePago>()
                   join C in academiaSistemasEntities1.Set<Curso>()
                   on D.IdCurso equals C.Id
                   join CC in academiaSistemasEntities1.Set<CategoriaCurso>()
                   on C.IdCategoria equals CC.IdCategoria
                   where D.IdPago == NumeroFactura
                   select new
                   {
                       Eliminar = "",
                       Categoria_Curso = CC.Nombre,
                       Curso = C.Nombre,
                       Cantidad = D.Cantidad,
                       ValorUnitario = D.ValorUnitario,
                       SubTotal = D.Cantidad * D.ValorUnitario
                   };
        }

    }
}