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
    public partial class Project_Build
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Project_Build()
        {
            this.Project_House = new HashSet<Project_House>();
        }

        [DataMember]
        public long ID { get; set; }
        [DataMember]
        public long ProjectID { get; set; }
        [DataMember]
        public string BuildName { get; set; }
        [DataMember]
        public string BuildShort { get; set; }
        [DataMember]
        public string Remark { get; set; }
        [DataMember]
        public Nullable<int> OrderID { get; set; }
        [DataMember]
        public Nullable<int> Status { get; set; }

        [DataMember]
        public virtual System_Project System_Project { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        [DataMember]
        public virtual ICollection<Project_House> Project_House { get; set; }
    }
}
