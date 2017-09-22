if exists(select * from sysobjects where name='FK_FD_MOBIL_REFERENCE_FD_AREAS') begin
    alter table FD_Mobile_Area
       drop constraint FK_FD_MOBIL_REFERENCE_FD_AREAS
end  

if exists(
   select 1 from sysobjects
   where name='FD_Mobile_Area'
    )begin
    drop table FD_Mobile_Area
end 

/*==============================================================*/
/* Table: FD_Mobile_Area                                        */
/*==============================================================*/
create table FD_Mobile_Area 
(
   MobileAreaKey        bigint     identity(1, 1)     not null,
   AreaKey              nvarchar(20),
   MobileHead           nvarchar(7),
   AreaCode             nvarchar(10),
   constraint PK_FD_MOBILE_AREA primary key clustered (MobileAreaKey)
);

alter table FD_Mobile_Area
   add constraint FK_FD_MOBIL_REFERENCE_FD_AREAS foreign key (AreaKey)
      references FD_Areas (AreaKey)
 
