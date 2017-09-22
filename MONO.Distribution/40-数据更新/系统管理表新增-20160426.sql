  alter table FD_SysUserGroups drop constraint FK_FD_SYSUS_REFERENCE_FD_SYSTE
	alter table FD_SystemFlowPackets drop constraint FK_FD_COMPA_REFERENCE_FD_SYSTE
	alter table FD_SysUserInfos drop constraint FK_FD_SYSUS_REFERENCE_FD_SYSTE
 
	alter table FD_SystemFlowPackets drop constraint FK_FD_COMPA_REFERENCE_FD_FLOWP
	alter table FD_FlowDistributionRecords drop constraint FK_FD_FLOWD_REFERENCE_FD_SYSTE
	alter table FD_FlowDistributionRecords drop constraint FK_FD_FLOWD_REFERENCE_FD_COMPA
	alter table FD_FlowPacketInfos drop constraint FK_FD_FLOWP_REFERENCE_FD_DISCO
	alter table FD_InterfaceProvier drop constraint FK_FD_INTER_REFERENCE_FD_FLOWP
	alter table FD_MenuGroups drop constraint FK_FD_MENUG_REFERENCE_FD_SYSUS
	alter table FD_MenuGroups drop constraint FK_FD_MENUG_REFERENCE_FD_MENUS
	alter table FD_RechargeRecords drop constraint FK_FD_RECHA_REFERENCE_FD_SYSTE
	alter table FD_SysUserInfos drop constraint FK_FD_SYSUS_REFERENCE_FD_SYSTE

	alter table FD_SystemLogs drop constraint FK_FD_SYSTE_REFERENCE_FD_SYSTE
	alter table FD_System_Account drop constraint FK_FD_SYSTE_REFERENCE_FD_SYSTE
	alter table FD_System_Account_Log drop constraint FK_FD_SYSTE_REFERENCE_FD_SYSTE
 

if exists(
   select 1 from sysobjects
   where name='FD_SystemFlowPackets'
    )begin
    drop table FD_SystemFlowPackets
end  ;

if exists(
   select 1 from sysobjects
   where name='FD_Discounts'
    )begin
    drop table FD_Discounts
end ;

if exists(
   select 1 from sysobjects
   where name='FD_FlowDistributionRecords'
    )begin
    drop table FD_FlowDistributionRecords
end  ;

if exists(
   select 1 from sysobjects
   where name='FD_FlowPacketInfos'
    )begin
    drop table FD_FlowPacketInfos
end ;

if exists(
   select 1 from sysobjects
   where name='FD_InterfaceProvier'
    )begin
    drop table FD_InterfaceProvier
end ;

if exists(
   select 1 from sysobjects
   where name='FD_MenuGroups'
     )begin
    drop table FD_MenuGroups
end ;

if exists(
   select 1 from sysobjects
   where name='FD_Menus'
   )begin
    drop table FD_Menus
end ;

if exists(
   select 1 from sysobjects
   where name='FD_RechargeRecords'
    )begin
    drop table FD_RechargeRecords
end ;

if exists(
   select 1 from sysobjects
   where name='FD_SysUserGroups'
     )begin
    drop table FD_SysUserGroups
end ;

if exists(
   select 1 from sysobjects
   where name='FD_SysUserInfos'
    )begin
    drop table FD_SysUserInfos
end ;

if exists(
   select 1 from sysobjects
   where name='FD_SystemLogs'
    )begin
    drop table FD_SystemLogs
end ;

if exists(
   select 1 from sysobjects
   where name='FD_System_Account'
     )begin
    drop table FD_System_Account
end ;

if exists(
   select 1 from sysobjects
   where name='FD_System_Account_Log'
)begin
    drop table FD_System_Account_Log
end ;

if exists(
   select 1 from sysobjects
   where name='FD_System_Users'
    )begin
    drop table FD_System_Users
end ;

/*==============================================================*/
/* Table: FD_SystemFlowPackets                                 */
/*==============================================================*/
create table FD_SystemFlowPackets 
(
   SystemFlowPacketKey int           identity(1, 1)                     not null,
   SysUserKey           int,
   FlowPacketKey        int,
   Status               nchar(1),
   DiscountKey           int ,
   Price                  int,
   constraint PK_FD_COMPANYFLOWPACKETS_01 primary key clustered (SystemFlowPacketKey)
);

 

/*==============================================================*/
/* Table: FD_Discounts                                          */
/*==============================================================*/
create table FD_Discounts 
(
   DiscountKey          int       identity(1, 1)                         not null,
   Deduction            int,
   Status               nchar(1),
   constraint PK_FD_DISCOUNTS primary key clustered (DiscountKey)
);
 

/*==============================================================*/
/* Table: FD_FlowDistributionRecords                            */
/*==============================================================*/
create table FD_FlowDistributionRecords 
(
   DistributionRecordKey nvarchar(50)                   not null,
   SysUserKey           int,
   CompanyFlowPacketKey int,
   MobilePhone          nvarchar(11),
   OrderStatus          nvarchar(20),
   OrderNo              nvarchar(50),
   CreateTime           datetime,
   UpdateTime           datetime,
   FlowCode             nvarchar(50),
   Carrier              nvarchar(20),
   ResultMsg            nvarchar(200),
   constraint PK_FD_FLOWDISTRIBUTIONRECORDS primary key clustered (DistributionRecordKey)
);

/*==============================================================*/
/* Table: FD_FlowPacketInfos                                    */
/*==============================================================*/
create table FD_FlowPacketInfos 
(
   FlowPacketKey        int      identity(1, 1)                          not null,
   DiscountKey          int,
   "From"               nvarchar(10),
   Size                 int,
   Price                money,
   Range                nvarchar(10),
   IsRecycle            nchar(1),
   IsExchange           nchar(1),
   Status               char(1),
   Remark               nvarchar(200),
   constraint PK_FD_FLOWPACKETINFOS primary key clustered (FlowPacketKey)
);

 

/*==============================================================*/
/* Table: FD_InterfaceProvier                                   */
/*==============================================================*/
create table FD_InterfaceProvier 
(
   InterfaceProvierKey  int        identity(1, 1)                        not null,
   FlowPacketKey        int,
   Code                 nvarchar(50),
   Area                 nvarchar(20),
   Carrier              nvarchar(20),
   Status               nvarchar(20),
   Flag                 int,
   priority             int,
   constraint PK_FD_INTERFACEPROVIER primary key clustered (InterfaceProvierKey)
);

/*==============================================================*/
/* Table: FD_MenuGroups                                         */
/*==============================================================*/
create table FD_MenuGroups 
(
   MenuGroupKey         int       identity(1, 1)                         not null,
   GroupKey             int,
   MenuKey              int,
   constraint PK_FD_MENUGROUPS primary key clustered (MenuGroupKey)
);

/*==============================================================*/
/* Table: FD_Menus                                              */
/*==============================================================*/
create table FD_Menus 
(
   MenuKey              int    identity(1, 1)                            not null ,
   ParentMenuKey        int,
   Name                 nvarchar(20)                   not null,
   Code                 nvarchar(20),
   Path                 nvarchar(150),
   Target               nchar(1),
   Status               nchar(1)                       not null,
   "Order"              int,
   Flag                 nchar(1),
   constraint PK_FD_MENUS primary key clustered (MenuKey)
);

/*==============================================================*/
/* Table: FD_RechargeRecords                                    */
/*==============================================================*/
create table FD_RechargeRecords 
(
   RechargeKey          uniqueidentifier                           not null,
   SysUserKey           int,
   Amount               money,
   PayDate              datetime,
   Status               nvarchar(20),
   OperatorId           char(10),
   CostType             nvarchar(10),
   UpdateTime           timestamp,
   Remark               nvarchar(200),
   Seq                  nvarchar(50),
   constraint PK_FD_RECHARGERECORDS primary key clustered (RechargeKey)
);
 

/*==============================================================*/
/* Table: FD_SysUserGroups                                      */
/*==============================================================*/
create table FD_SysUserGroups 
(
   GroupKey             int       identity(1, 1)                         not null,
   Name                 nvarchar(12)                   not null,
   Code                 nvarchar(12),
   Status               nchar(1)                       not null,
   UpdateTime           timestamp,
   SysUserKey           int,
   Flag                 int,
   constraint PK_FD_SYSUSERGROUPS primary key clustered (GroupKey)
);

/*==============================================================*/
/* Table: FD_SysUserInfos                                       */
/*==============================================================*/
create table FD_SysUserInfos 
(
   UserInfoKey          int      identity(1, 1)                          not null,
   SysUserKey           int,
   Name                 nvarchar(20),
   WorkNumber           nvarchar(20),
   Sex                  nvarchar(10)                   not null,
   IDNumber             nvarchar(18),
   Mobile               nvarchar(20),
   CompanyTelephone     nvarchar(20),
   Post                 nvarchar(10),
   Mail                 nvarchar(50),
   Remark               nvarchar(Max),
   constraint PK_FD_SYSUSERINFOS primary key clustered (UserInfoKey)
);

/*==============================================================*/
/* Table: FD_SystemLogs                                         */
/*==============================================================*/
create table FD_SystemLogs 
(
   SystemLogKey         uniqueidentifier                           not null ,
   SysUserKey           int,
   IP                   nvarchar(20)                   not null,
   InsertTime           datetime                       not null,
   Module               nvarchar(20),
   Content              nvarchar(500)                  not null,
   Level                nchar(1)                       not null,
   UpdateTime           timestamp,
   constraint PK_FD_SYSTEMLOGS primary key clustered (SystemLogKey)
);

/*==============================================================*/
/* Table: FD_System_Account                                     */
/*==============================================================*/
create table FD_System_Account 
(
   CompanyAccountKey    int      identity(1, 1)                          not null,
   SysUserKey           int,
   TotalAccount         int,
   LeftAccount          int,
   Updatetime           timestamp,
   constraint PK_FD_SYSTEM_ACCOUNT primary key clustered (CompanyAccountKey)
);

/*==============================================================*/
/* Table: FD_System_Account_Log                                 */
/*==============================================================*/
create table FD_System_Account_Log 
(
   AccountLogKey        uniqueidentifier               not null,
   CompanyAccountKey    int,
   OperaType            nvarchar(20),
   Integral             int,
   OperaDate            datetime,
   BeforeIntegral       int,
   AfterIntegral        int,
   constraint PK_FD_SYSTEM_ACCOUNT_LOG primary key clustered (AccountLogKey)
);

/*==============================================================*/
/* Table: FD_System_Users                                       */
/*==============================================================*/
create table FD_System_Users 
(
   SysUserKey           int       identity(1, 1)                         not null,
   GroupKey             int,
   Account              nvarchar(20)                   not null,
   PWD                  nvarchar(50)                   not null,
   Status               nchar(1)                       not null,
   UpdateTime           timestamp,
   Flag                 int,
   constraint PK_FD_SYSTEM_USERS primary key clustered (SysUserKey)
);

alter table FD_SystemFlowPackets
   add constraint FK_FD_COMPA_REFERENCE_FD_SYSTE foreign key (SysUserKey)
      references FD_System_Users (SysUserKey)
 

 
 

alter table FD_FlowDistributionRecords
   add constraint FK_FD_FLOWD_REFERENCE_FD_SYSTE foreign key (SysUserKey)
      references FD_System_Users (SysUserKey)
 

alter table FD_FlowDistributionRecords
   add constraint FK_FD_FLOWD_REFERENCE_FD_COMPA foreign key (CompanyFlowPacketKey)
      references FD_SystemFlowPackets (SystemFlowPacketKey)
 

alter table FD_FlowPacketInfos
   add constraint FK_FD_FLOWP_REFERENCE_FD_DISCO foreign key (DiscountKey)
      references FD_Discounts (DiscountKey)
 

alter table FD_InterfaceProvier
   add constraint FK_FD_INTER_REFERENCE_FD_FLOWP foreign key (FlowPacketKey)
      references FD_FlowPacketInfos (FlowPacketKey)
 

alter table FD_MenuGroups
   add constraint FK_FD_MENUG_REFERENCE_FD_SYSUS foreign key (GroupKey)
      references FD_SysUserGroups (GroupKey)
 

alter table FD_MenuGroups
   add constraint FK_FD_MENUG_REFERENCE_FD_MENUS foreign key (MenuKey)
      references FD_Menus (MenuKey)
 

alter table FD_RechargeRecords
   add constraint FK_FD_RECHA_REFERENCE_FD_SYSTE foreign key (SysUserKey)
      references FD_System_Users (SysUserKey)
 

alter table FD_SysUserGroups
   add constraint FK_FD_SYSUS_REFERENCE_FD_SYSTE foreign key (SysUserKey)
      references FD_System_Users (SysUserKey)
 


alter table FD_SysUserInfos
   add constraint FK_FD_SYSUS_REFERENCE_FD_SYSTE_1 foreign key (SysUserKey)
      references FD_System_Users (SysUserKey)
 

alter table FD_SystemLogs
   add constraint FK_FD_SYSTE_REFERENCE_FD_SYSTE foreign key (SysUserKey)
      references FD_System_Users (SysUserKey)
 

alter table FD_System_Account
   add constraint FK_FD_SYSTE_REFERENCE_FD_SYSTE_01 foreign key (SysUserKey)
      references FD_System_Users (SysUserKey)
 

alter table FD_System_Account_Log
   add constraint FK_FD_SYSTE_REFERENCE_FD_SYSTE_2 foreign key (CompanyAccountKey)
      references FD_System_Account (CompanyAccountKey)
 
