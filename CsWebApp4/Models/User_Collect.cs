//------------------------------------------------------------------------------
// <auto-generated>
//     此代码已从模板生成。
//
//     手动更改此文件可能导致应用程序出现意外的行为。
//     如果重新生成代码，将覆盖对此文件的手动更改。
// </auto-generated>
//------------------------------------------------------------------------------

namespace CsWebApp4.Models
{
    using System;
    using System.Collections.Generic;
    using System.Runtime.Serialization;

    [DataContract]
    public partial class User_Collect
    {
        [DataMember]
        public long ID { get; set; }
        [DataMember]
        public long HouseID { get; set; }
        [DataMember]
        public long UserID { get; set; }
        [DataMember]
        public Nullable<System.DateTime> CollectDate { get; set; }
        [DataMember]
        public Nullable<int> OrderID { get; set; }
        [DataMember]
        public Nullable<int> Status { get; set; }

        [DataMember]
        public virtual Project_House Project_House { get; set; }
        [DataMember]
        public virtual System_User System_User { get; set; }
    }
}
