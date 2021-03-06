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
    public partial class Project_House
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Project_House()
        {
            this.User_Cart = new HashSet<User_Cart>();
            this.User_Collect = new HashSet<User_Collect>();
        }

        [DataMember]
        public long ID { get; set; }
        [DataMember]
        public long BuildID { get; set; }
        [DataMember]
        public string UnitName { get; set; }
        [DataMember]
        public string UnitShort { get; set; }
        [DataMember]
        public string FloorName { get; set; }
        [DataMember]
        public string FloorShort { get; set; }
        [DataMember]
        public string HouseName { get; set; }
        [DataMember]
        public string HouseShort { get; set; }
        [DataMember]
        public Nullable<int> HouseStatus { get; set; }
        [DataMember]
        public string HouseIntro { get; set; }
        [DataMember]
        public string HouseModel { get; set; }
        [DataMember]
        public string HouseType { get; set; }
        [DataMember]
        public string HouseClass { get; set; }
        [DataMember]
        public string HouseCategory { get; set; }
        [DataMember]
        public Nullable<decimal> HouseArea { get; set; }
        [DataMember]
        public Nullable<decimal> HousePrice { get; set; }
        [DataMember]
        public Nullable<decimal> HouseTotal { get; set; }
        [DataMember]
        public string Remark { get; set; }
        [DataMember]
        public Nullable<int> OrderID { get; set; }
        [DataMember]
        public Nullable<int> Status { get; set; }

        [DataMember]
        public virtual Project_Build Project_Build { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        [DataMember]
        public virtual ICollection<User_Cart> User_Cart { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        [DataMember]
        public virtual ICollection<User_Collect> User_Collect { get; set; }
    }
}
