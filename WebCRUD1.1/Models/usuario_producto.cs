//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WebCRUD1._1.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class usuario_producto
    {
        public int id_up { get; set; }
        public Nullable<long> cedula_usuario { get; set; }
        public Nullable<int> id_producto { get; set; }
    
        public virtual producto producto { get; set; }
        public virtual usuario usuario { get; set; }
    }
}