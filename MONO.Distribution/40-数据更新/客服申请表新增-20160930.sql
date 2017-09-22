 
if exists(
   select * from sysobjects
   where name='FD_AccountApplyAtts'
      
) begin
    drop table FD_AccountApplyAtts
end 

if exists(
   select * from sysobjects
   where name='FD_CompanyAccountAddApplys'
     
) begin
    drop table FD_CompanyAccountAddApplys
end 

/*==============================================================*/
/* Table: FD_AccountApplyAtts                                   */
/*==============================================================*/
create table FD_AccountApplyAtts 
(
   AccountApplyAttKey   int                            not null,
   AccountAddApplyKey   int                            null,
   ImagePath            nvarchar(500)                  null,
   Name                 nvarchar(50)                   null,
   constraint PK_FD_ACCOUNTAPPLYATTS primary key clustered (AccountApplyAttKey)
);

/*==============================================================*/
/* Table: FD_CompanyAccountAddApplys                            */
/*==============================================================*/
create table FD_CompanyAccountAddApplys 
(
   AccountAddApplyKey   int                            not null,
   CompanyKey           int                            null,
   SysUserKey           int                            null,
   AccountIntegrel      int                            null,
   CreateTime           datetime                       null,
   Remark               nvarchar(500)                  null,
   ApplyStatus          nvarchar(20)                   null,
   constraint PK_FD_COMPANYACCOUNTADDAPPLYS primary key clustered (AccountAddApplyKey)
);

alter table FD_AccountApplyAtts
   add constraint FK_FD_ACCOU_REFERENCE_FD_COMPA foreign key (AccountAddApplyKey)
      references FD_CompanyAccountAddApplys (AccountAddApplyKey)
 
