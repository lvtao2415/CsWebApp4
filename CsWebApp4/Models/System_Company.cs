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
    public partial class System_Company
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public System_Company()
        {
            this.System_Project = new HashSet<System_Project>();
            this.System_User = new HashSet<System_User>();
        }

        [DataMember]
        public long ID { get; set; }
        [DataMember]
        public string CompanyName { get; set; }
        [DataMember]
        public string CompanyShort { get; set; }
        [DataMember]
        public string CompanyAddress { get; set; }
        [DataMember]
        public string CompanyPhone { get; set; }
        [DataMember]
        public string CompanyImg { get; set; }
        [DataMember]
        public string CompanyKey { get; set; }
        [DataMember]
        public string UrlAPI { get; set; }
        [DataMember]
        public Nullable<int> NeedBindMobile { get; set; }
        [DataMember]
        public Nullable<int> NeedBindCard { get; set; }
        [DataMember]
        public Nullable<int> OrderID { get; set; }
        [DataMember]
        public Nullable<int> Status { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<System_Project> System_Project { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<System_User> System_User { get; set; }
    }

    public partial class System_CompanyView
    {
        public long ID { get; set; }
        public string CompanyName { get; set; }
        public string CompanyShort { get; set; }
        public string CompanyAddress { get; set; }
        public string CompanyPhone { get; set; }
        public string CompanyImg { get; set; }
        public string CompanyKey { get; set; }
        public string UrlAPI { get; set; }
        public Nullable<int> NeedBindMobile { get; set; }
        public Nullable<int> NeedBindCard { get; set; }
    }
}