//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SegurosPrueba.DataBase
{
    using System;
    using System.Collections.Generic;
    
    public partial class tbl_Producto
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tbl_Producto()
        {
            this.tbl_Venta = new HashSet<tbl_Venta>();
        }
    
        public int id_producto { get; set; }
        public string nombre_producto { get; set; }
        public decimal prima { get; set; }
        public string cobertura { get; set; }
        public string asistencia { get; set; }
        public int id_compania { get; set; }
    
        public virtual tbl_Compania tbl_Compania { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_Venta> tbl_Venta { get; set; }
    }
}
