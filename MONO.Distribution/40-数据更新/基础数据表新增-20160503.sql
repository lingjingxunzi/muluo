if exists(
   select 1 from sysobjects
   where name='FD_Areas'
      
) begin
    drop table FD_Areas
end  

if exists(
   select 1 from sysobjects
   where name='FD_Enumeration'    
) begin
    drop table FD_Enumeration
end 

/*==============================================================*/
/* Table: FD_Areas                                              */
/*==============================================================*/
create table FD_Areas 
(
   AreaKey              nvarchar(20)                   not null,
   Name                 nvarchar(20),
   ParentKey            nvarchar(20),
   constraint PK_FD_AREAS primary key clustered (AreaKey)
);

/*==============================================================*/
/* Table: FD_Enumeration                                        */
/*==============================================================*/
create table FD_Enumeration 
(
   EnumKey              nvarchar(20)                   not null,
   EnumValue            nvarchar(50),
   EnumParent           nvarchar(20),
   Status               nvarchar(1),
   Remark               nvarchar(200),
   constraint PK_FD_ENUMERATION primary key clustered (EnumKey)
);
