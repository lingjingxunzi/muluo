 

if exists(select * from sysobjects where name='FK_FD_SYSTE_REFERENCE_FD_SYSTE') begin
    alter table FD_SystemMsgTemplates drop constraint  FK_FD_SYSTE_REFERENCE_FD_SYSTE
end  

if exists(select * from sysobjects where name='FK_FD_SYSTE_REFERENCE_FD_MESSA') begin
    alter table FD_SystemMsgTemplates
       drop constraint  FK_FD_SYSTE_REFERENCE_FD_MESSA
end  

if exists(select * from sysobjects where name='FK_FD_SYSTE_REFERENCE_FD_SYSTE') begin
    alter table FD_SystemSetting
       drop constraint  FK_FD_SYSTE_REFERENCE_FD_SYSTE
end 

 
if exists(
   select 1 from sysobjects
   where name='FD_MessageTemplate'
      
) begin
    drop table FD_MessageTemplate
end  

if exists(
   select 1 from sysobjects
   where name='FD_SystemMsgTemplates'
      
) begin
    drop table FD_SystemMsgTemplates
end 

if exists(
   select 1 from sysobjects 
   where name='FD_SystemSetting')
     begin
    drop table FD_SystemSetting
end 
 

/*==============================================================*/
/* Table: FD_MessageTemplate                                    */
/*==============================================================*/
create table FD_MessageTemplate 
(
   MessageTemplateKey   int     identity(1, 1)                              not null,
   Content              text,
   Price                int,
   UpdateTime           timestamp,
   MsgType              nvarchar(20),
   constraint PK_FD_MESSAGETEMPLATE primary key clustered (MessageTemplateKey)
);

/*==============================================================*/
/* Table: FD_SystemMsgTemplates                                 */
/*==============================================================*/
create table FD_SystemMsgTemplates 
(
   MsgTemplateKey       int       identity(1, 1)          not null,
   SysUserKey           int,
   MessageTemplateKey   int,
   constraint PK_FD_SYSTEMMSGTEMPLATES primary key clustered (MsgTemplateKey)
);

/*==============================================================*/
/* Table: FD_SystemSetting                                      */
/*==============================================================*/
create table FD_SystemSetting 
(
   SystemSettingKey     int        identity(1, 1)     not null,
   SysUserKey           int,
   IsDefaultProvnice    nvarchar(1),
   IsSendMsg            nvarchar(1),
   IsAfterFaildToSave   nvarchar(1),
   constraint PK_FD_SYSTEMSETTING primary key clustered (SystemSettingKey)
);

 
      

alter table FD_SystemMsgTemplates
   add constraint FK_FD_SYSTE_REFERENCE_FD_SYSTE_02 foreign key (SysUserKey)
      references FD_System_Users (SysUserKey)
      

alter table FD_SystemMsgTemplates
   add constraint FK_FD_SYSTE_REFERENCE_FD_MESSA foreign key (MessageTemplateKey)
      references FD_MessageTemplate (MessageTemplateKey)
     

alter table FD_SystemSetting
   add constraint FK_FD_SYSTE_REFERENCE_FD_SYSTE_03 foreign key (SysUserKey)
      references FD_System_Users (SysUserKey)
     
