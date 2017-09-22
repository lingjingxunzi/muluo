if exists(
   select 1 from sysobjects
   where name='FD_DataBackups'
     )begin
    drop table FD_DataBackups
end  

/*==============================================================*/
/* Table: FD_DataBackups                                        */
/*==============================================================*/
create table FD_DataBackups 
(
   DataBackupKey        int          IDENTITY(1,1)                  not null,
   BackNumber           nvarchar(20),
   BackStyle            nvarchar(20),
   Cycle                nvarchar(20),
   TableName            nvarchar(20),
   BackupUrl            nvarchar(20),
   BackupTime           nvarchar(20),
   "TimeStamp"          timestamp,
   constraint PK_FD_DATABACKUPS primary key clustered (DataBackupKey)
);
