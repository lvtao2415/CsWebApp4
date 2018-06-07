
 
IF NOT EXISTS (SELECT 1 FROM sys.objects WHERE object_id = OBJECT_ID(N'[SystemSet]'))
Begin
  CREATE TABLE [SystemSet](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[PrinterDrive] [nvarchar](250) NULL,
	[PrinterRemark] [nvarchar](250) NULL,
	[PrinterSign] [nvarchar](250) NULL,
	[PrinterWidth]  Decimal(18,2) default(0),
	[PrinterHeight]  Decimal(18,2) default(0),
	[PrinterSpeed]  Decimal(18,2) default(0),
	[PrinterConcent]  Decimal(18,2) default(0),
	[DatabaseServer] [nvarchar](250) NULL,
	[DatabaseName] [nvarchar](250) NULL,
	[DatabaseUser] [nvarchar](250) NULL,
	[DatabasePwd] [nvarchar](250) NULL
	)
End

IF NOT EXISTS (SELECT 1 FROM sys.objects WHERE object_id = OBJECT_ID(N'[CustomerInfos]'))
Begin
  CREATE TABLE [CustomerInfos](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[ProjectName] [nvarchar](250) NULL,
	[CustomerFirstName] [nvarchar](250) NULL,
	[CustomerFirstSex] [nvarchar](250) NULL,
	[CustomerFirstCard]  [nvarchar](250) NULL,
	[CustomerFirstPhone]  [nvarchar](250) NULL,
	[CustomerSecondName] [nvarchar](250) NULL,
	[CustomerSecondSex] [nvarchar](250) NULL,
	[CustomerSecondCard]  [nvarchar](250) NULL,
	[CustomerSecondPhone]  [nvarchar](250) NULL,
	[CustomerAddress]  [nvarchar](500) NULL,
	[NotaryNo] [nvarchar](250) NULL,
	[SignNo]  [nvarchar](250) NULL,
	[SignStaus]  Int default(0),
	[SignDate] [Datetime] NULL,
	[CustomerStaus]  Int default(1),
	[CreateDate] [Datetime] NULL,
	[DelStaus] Int default(0)
	)
End

IF NOT EXISTS (SELECT 1 FROM sys.objects WHERE object_id = OBJECT_ID(N'[CustomerInfo]'))
Begin
  CREATE TABLE [CustomerInfo](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[CustomerID] BigInt Not NULL,
	[CustomerName] [nvarchar](250) NULL,
	[CustomerSex]  Int default(1),
	[CustomerCard]  [nvarchar](250) NULL,
	[CustomerPhone]  [nvarchar](250) NULL,
	[CustomerStaus]  Int default(1),
	[CustomersID] BigInt Not NULL,
	[CreateDate] [Datetime] NULL,
	[DelStaus] Int default(0)
	)
End


IF NOT EXISTS (SELECT 1 FROM sys.objects WHERE object_id = OBJECT_ID(N'[ProjectInfo]'))
Begin
  CREATE TABLE [ProjectInfo](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[ProjectID] BigInt Not NULL,
	[ProjectName] [nvarchar](250) NULL,
	[ProjectShort]  [nvarchar](250) NULL,
	[SellerID]  BigInt Not NULL,
	[SellerName]  [nvarchar](250) NULL,
	[SellerShort] [nvarchar](250) NULL,
	[MinNo] [nvarchar](250) NULL,
	[MaxNo] [nvarchar](250) NULL,
	[StartDate] [Datetime] NULL,
	[EndDate]  [Datetime] NULL,
	[ProjectStaus]  Int default(0),
	[CreateDate]  [Datetime] NULL,
	[DelStaus] Int default(0)
	)
End


IF NOT EXISTS (SELECT 1 FROM sys.objects WHERE object_id = OBJECT_ID(N'[NotaryNoInfo]'))
Begin
  CREATE TABLE [NotaryNoInfo](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[ProjectID] BigInt Not NULL,
	[CustomersID] BigInt Not NULL,
	[NotaryNo] [nvarchar](250) NULL,
	[SignNo]  [nvarchar](250) NULL,
	[NotaryStaus]  Int default(1),
	[CreateDate]  [Datetime] NULL,
	[DelStaus] Int default(0)
	)
End

IF NOT EXISTS (SELECT 1 FROM sys.objects WHERE object_id = OBJECT_ID(N'[客户导入信息表]'))
Begin
  CREATE TABLE [客户导入信息表](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[客户名称] [nvarchar](250) NULL,
	[客户性别] [nvarchar](250) NULL,
	[身份证号码] [nvarchar](250) NULL,
	[手机号码]  [nvarchar](250) NULL,
	[客户关系序号]  [nvarchar](250) NULL,
	[导入批次]  [nvarchar](250) NULL,
	[导入状态] Int default(0),
	[导入时间] [Datetime] NULL
	)
End

IF NOT EXISTS (SELECT 1 FROM [SystemSet])
Begin
  insert into [SystemSet]([PrinterDrive],[PrinterRemark],[PrinterWidth],[PrinterHeight],[PrinterSpeed],[PrinterConcent],[DatabaseServer],[DatabaseName],[DatabaseUser],[DatabasePwd])
  values ('Gprinter GP-1124T','新视窗-电子开盘提供技术支持',100.0,62.5,2.0,10.0,'D756DAGP8NZ5QUD','NotaryNoData','sa','123456')
End

IF NOT EXISTS (SELECT 1 FROM [ProjectInfo])
Begin
  insert into [ProjectInfo]([ProjectID],[ProjectName],[ProjectShort],[SellerID],[SellerName],[SellerShort],[MinNo],[MaxNo],[StartDate],[EndDate],[ProjectStaus],[CreateDate],[DelStaus])
  values (1,'融信澜天','融信',1,'融信房产','融信房产','000001','999999','2018-05-01 06:00:00','2018-12-01 20:00:00',1,GETDATE(),0)
End



-- select [ID],[PrinterDrive],[PrinterRemark],[PrinterWidth],[PrinterHeight],[PrinterSpeed],[PrinterConcent],[DatabaseServer],[DatabaseName],[DatabaseUser],[DatabasePwd] from [SystemSet]
-- select [ID],[CustomerID],[CustomerName],[CustomerSex],[CustomerCard],[CustomerPhone],[CustomerStaus],[CustomersID],[CreateDate],[DelStaus] from [CustomerInfo]
-- select [ID],[ProjectID],[ProjectName],[ProjectShort],[SellerID],[SellerName],[SellerShort],[MinNo],[MaxNo],[StartDate],[EndDate],[ProjectStaus],[CreateDate],[DelStaus] from [ProjectInfo]
-- select [ID],[ProjectID],[CustomersID],[NotaryNo],[SignNo],[NotaryStaus],[CreateDate],[DelStaus] from [NotaryNoInfo]


