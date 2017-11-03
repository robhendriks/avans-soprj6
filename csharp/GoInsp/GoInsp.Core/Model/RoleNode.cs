namespace GoInsp.Core.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("RoleNode")]
    public partial class RoleNode
    {
        public int RoleNodeID { get; set; }

        public int RoleID { get; set; }

        public int NodeID { get; set; }

        public virtual Node Node { get; set; }

        public virtual Role Role { get; set; }
    }
}
