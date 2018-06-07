


IF NOT EXISTS (SELECT 1 FROM sys.objects WHERE object_id = OBJECT_ID(N'[System_Company]'))
Begin
  CREATE TABLE [System_Company](
	[ID] [BigInt] IDENTITY(1,1) NOT NULL PRIMARY KEY,
	[CompanyName] [nvarchar](250) NULL,
	[CompanyShort] [nvarchar](250) NULL,
	[CompanyAddress] [nvarchar](250) NULL,
	[CompanyPhone]  [nvarchar](250) NULL,
	[CompanyImg]  [nvarchar](250) NULL,
	[CompanyKey]  [nvarchar](250) NULL,
	[UrlAPI]  [nvarchar](250) NULL,
	[NeedBindMobile] Int default(0),
	[NeedBindCard] Int default(0),
	[OrderID] Int default(0),
	[Status] Int default(1)
	)
End
--ID,CompanyID,CompanyName,CompanyShort,CompanyAddress,CompanyPhone,CompanyImg,CompanyKey,UrlAPI,NeedBindMobile,OrderID,Status

IF NOT EXISTS (SELECT 1 FROM sys.objects WHERE object_id = OBJECT_ID(N'[System_User]'))
Begin
  CREATE TABLE [System_User](
	[ID] [BigInt] IDENTITY(1,1) NOT NULL PRIMARY KEY,
	[CompanyID] BigInt NOT NULL Foreign Key ([CompanyID]) References [System_Company]([ID]),
	[UserName] [nvarchar](250) NULL,
	[UserShort] [nvarchar](250) NULL,
	[UserSex]  Int default(0),
	[UserAddress] [nvarchar](500) NULL,
	[UserAccont] [nvarchar](250) NULL,
	[UserPasswd]  [nvarchar](250) NULL,
	[IsBindMobile]  Int default(0),
	[UserMobile]  [nvarchar](250) NULL,
	[IsBindCard]  Int default(0),
	[UserCard]  [nvarchar](250) NULL,
	[WxOpenId]  [nvarchar](250) NULL,
	[WxUnionid] [nvarchar](250) NULL,
	[UserGrade] Int default(0),
	[LoginDate] [Datetime] NULL,
	[OrderID] Int default(0),
	[Status] Int default(1)
	)
End
--ID,UserName,UserShort,UserSex,UserAddress,UserAccont,UserPasswd,IsBindMobile,UserMobile,IsBindCard,UserCard,WxOpenId,WxUnionid,UserGrade,LoginDate,OrderID,Status

IF NOT EXISTS (SELECT 1 FROM sys.objects WHERE object_id = OBJECT_ID(N'[System_Project]'))
Begin
  CREATE TABLE [System_Project](
	[ID] [BigInt] IDENTITY(1,1) NOT NULL PRIMARY KEY,
	[CompanyID] BigInt NOT NULL Foreign Key ([CompanyID]) References [System_Company]([ID]),
	[ProjectName] [nvarchar](250) NULL,
	[ProjectShort] [nvarchar](250) NULL,
	[ProjectAddress] [nvarchar](500) NULL,
	[ProjectAgreement] [text] NULL,
	[ProjectNotes]  [text] NULL,
	[ProjectStatus] Int default(1),
	[StartDate] [Datetime] NULL,
	[EndDate] [Datetime] NULL,
	[OrderID] Int default(0),
	[Status] Int default(1)
	)
End
--ID,CompanyID,ProjectName,ProjectShort,ProjectAddress,ProjectAgreement,ProjectNotes,ProjectStatus,StartDate,EndDate,OrderID,Status

IF NOT EXISTS (SELECT 1 FROM sys.objects WHERE object_id = OBJECT_ID(N'[Project_MainImg]'))
Begin
  CREATE TABLE [Project_MainImg](
	[ID] [BigInt] IDENTITY(1,1) NOT NULL PRIMARY KEY,
	[ProjectID] BigInt Not NULL Foreign Key ([ProjectID]) References [System_Project]([ID]),
	[ImgName] [nvarchar](250) NULL,
	[ImgUrl] [nvarchar](250) NULL,
	[SmallUrl] [nvarchar](250) NULL,
	[Remark] [nvarchar](500) NULL,
	[OrderID] Int default(0),
	[Status] Int default(1)
	)
End
--ID,ProjectID,ImgName,ImgUrl,SmallUrl,Remark,OrderID,Status

IF NOT EXISTS (SELECT 1 FROM sys.objects WHERE object_id = OBJECT_ID(N'[Project_Build]'))
Begin
  CREATE TABLE [Project_Build](
	[ID] [BigInt] IDENTITY(1,1) NOT NULL PRIMARY KEY,
	[ProjectID] BigInt Not NULL Foreign Key ([ProjectID]) References [System_Project]([ID]),
	[BuildName] [nvarchar](250) NULL,
	[BuildShort] [nvarchar](250) NULL,
	[Remark] [nvarchar](500) NULL,
	[OrderID] Int default(0),
	[Status] Int default(1)
	)
End
--ID,ProjectID,BuildName,BuildShort,Remark,OrderID,Status

IF NOT EXISTS (SELECT 1 FROM sys.objects WHERE object_id = OBJECT_ID(N'[Project_House]'))
Begin
  CREATE TABLE [Project_House](
	[ID] [BigInt] IDENTITY(1,1) NOT NULL PRIMARY KEY,
	[BuildID] BigInt Not NULL Foreign Key ([BuildID]) References [Project_Build]([ID]),
	[UnitName] [nvarchar](250) NULL,
	[UnitShort] [nvarchar](250) NULL,
	[FloorName] [nvarchar](250) NULL,
	[FloorShort] [nvarchar](250) NULL,
	[HouseName] [nvarchar](250) NULL,
	[HouseShort] [nvarchar](250) NULL,
	[HouseStatus] Int default(1),
	[HouseIntro] [nvarchar](250) NULL,
	[HouseModel] [nvarchar](250) NULL,--户型
	[HouseType] [nvarchar](250) NULL,
	[HouseClass] [nvarchar](250) NULL,
	[HouseCategory] [nvarchar](250) NULL,
	[HouseArea] Decimal(18,2) default(0.00),
	[HousePrice] Decimal(18,2) default(0.00),
	[HouseTotal] Decimal(18,2) default(0.00),
	[Remark] [nvarchar](500) NULL,
	[OrderID] Int default(0),
	[Status] Int default(1)
	)
End
--ID,ProjectID,BuildID,UnitName,UnitShort,FloorName,FloorShort,HouseName,HouseShort,HouseStatus,HouseIntro,HouseModel,HouseType,HouseClass,HouseCategory,HouseArea,HousePrice,HouseTotal,Remark,OrderID,Status

IF NOT EXISTS (SELECT 1 FROM sys.objects WHERE object_id = OBJECT_ID(N'[Project_HouseImg]'))
Begin
  CREATE TABLE [Project_HouseImg](
	[ID] [BigInt] IDENTITY(1,1) NOT NULL PRIMARY KEY,
	[ProjectID] BigInt Not NULL Foreign Key ([ProjectID]) References [System_Project]([ID]),
	[HouseModel] [nvarchar](250) NULL,--户型
	[HouseType] [nvarchar](250) NULL,
	[HouseClass] [nvarchar](250) NULL,
	[HouseCategory] [nvarchar](250) NULL,
	[ImgName] [nvarchar](250) NULL,
	[ImgUrl] [nvarchar](250) NULL,
	[SmallUrl] [nvarchar](250) NULL,
	[Remark] [nvarchar](500) NULL,
	[OrderID] Int default(0),
	[Status] Int default(1)
	)
End
--ID,ProjectID,HouseModel,HouseType,HouseClass,HouseCategory,ImgName,ImgUrl,SmallUrl,Remark,OrderID,Status

IF NOT EXISTS (SELECT 1 FROM sys.objects WHERE object_id = OBJECT_ID(N'[User_NotaryNo]'))
Begin
  CREATE TABLE [User_NotaryNo](
	[ID] [BigInt] IDENTITY(1,1) NOT NULL PRIMARY KEY,
	[ProjectID] BigInt Not NULL Foreign Key ([ProjectID]) References [System_Project]([ID]),
	[UserID] BigInt Not NULL Foreign Key ([UserID]) References [System_User]([ID]),
	[NotaryNo] [nvarchar](250) NULL,
	[SignNo]  [nvarchar](250) NULL,
	[NotaryDate]  [Datetime] NULL,
	[OrderID] Int default(0),
	[Status] Int default(1)
	)
End
--ID,CompanyID,ProjectID,BuildID,HouseID,UserID,CollectDate,OrderID,Status

IF NOT EXISTS (SELECT 1 FROM sys.objects WHERE object_id = OBJECT_ID(N'[User_Collect]'))
Begin
  CREATE TABLE [User_Collect](
	[ID] [BigInt] IDENTITY(1,1) NOT NULL PRIMARY KEY,
	[HouseID] BigInt Not NULL Foreign Key ([HouseID]) References [Project_House]([ID]),
	[UserID] BigInt Not NULL Foreign Key ([UserID]) References [System_User]([ID]),
	[CollectDate] [Datetime] NULL,
	[OrderID] Int default(0),
	[Status] Int default(1)
	)
End
--ID,CompanyID,ProjectID,BuildID,HouseID,UserID,CollectDate,OrderID,Status

IF NOT EXISTS (SELECT 1 FROM sys.objects WHERE object_id = OBJECT_ID(N'[User_Cart]'))
Begin
  CREATE TABLE [User_Cart](
	[ID] [BigInt] IDENTITY(1,1) NOT NULL PRIMARY KEY,
	[HouseID] BigInt Not NULL Foreign Key ([HouseID]) References [Project_House]([ID]),
	[UserID] BigInt Not NULL Foreign Key ([UserID]) References [System_User]([ID]),
	[CartDate] [Datetime] NULL,
	[CartStatus] Int default(1),
	[OrderID] Int default(0),
	[Status] Int default(1)
	)
End
--ID,CompanyID,ProjectID,BuildID,HouseID,UserID,CollectDate,OrderID,Status



































