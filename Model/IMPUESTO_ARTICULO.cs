//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Model
{
    using System;
    using System.Collections.Generic;
    
    public partial class IMPUESTO_ARTICULO
    {
        public int ID_IMPUESTO_ARTICULO { get; set; }
        public int ID_IMPUESTO { get; set; }
        public int ID_ARTICULO { get; set; }
    
        public virtual ARTICULO ARTICULO { get; set; }
    }
}
