 if exists(
   select 1 from sysobjects
   where name='FD_MsgSendRecord'
    
) begin
    drop table FD_MsgSendRecord
end  

/*==============================================================*/
/* Table: FD_MsgSendRecord                                      */
/*==============================================================*/
create table FD_MsgSendRecord 
(
   MsgSendRecordkey     nvarchar(50)                   not null,
   SysUserKey           int,
   Content              text,
   UserPhone            nvarchar(11),
   CreateTime           datetime,
   Status               nvarchar(20),
   constraint PK_FD_MSGSENDRECORD primary key clustered (MsgSendRecordkey)
);

 
 
