if exists(select * from sysobjects where name='FK_FB_FLOWC_REFERENCE_FB_FLOWB') begin
    alter table FD_FlowCode  drop constraint  FK_FB_FLOWC_REFERENCE_FB_FLOWB
end  

if exists(
   select 1 from sysobjects
   where name='FD_FlowBaseInfo'
     )begin
    drop table FD_FlowBaseInfo
end ;

if exists(
   select 1 from sysobjects
   where name='FD_FlowCode'
     )begin
    drop table FD_FlowCode
end ;

/*==============================================================*/
/* Table: FB_FlowBaseInfo                                       */
/*==============================================================*/
create table FD_FlowBaseInfo 
(
   FlowKey              int IDENTITY(1,1)                              not null,
   [From]               nvarchar(20)                   null,
   Size                 int                            null,
   StandardPrice        int                            null,
   [Range]                nvarchar(20)                   null,
   PlatformCode         nvarchar(50)                   null,
   [Status]               nvarchar(20)                   null,
   constraint PK_FB_FLOWBASEINFO primary key clustered (FlowKey)
);

/*==============================================================*/
/* Table: FB_FlowCode                                           */
/*==============================================================*/
create table FD_FlowCode 
(
   FlowCodeKey             int   IDENTITY(1,1)                            not null,
   FlowKey              int                            null,
   "From"               nvarchar(20)                   null,
   Carrier              nvarchar(20)                   null,
   ProductCode          nvarchar(100)                  null,
   Area                 nvarchar(20)                   null,
   [Priority]             int                            null,
   [Status]               nvarchar(20)                   null,
   constraint PK_FB_FLOWCODE primary key clustered (FlowCodeKey)
);

alter table FD_FlowCode
   add constraint FK_FB_FLOWC_REFERENCE_FB_FLOWB foreign key (FlowKey)
      references FD_FlowBaseInfo (FlowKey)
     
