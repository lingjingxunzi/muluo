if exists (select * from sysobjects where name = 'PRO_BackupSome')
begin
	drop proc PRO_BackupSome;
end
go

create proc PRO_BackupSome
@TableNameBack nvarchar(50),
 @TableName nvarchar(50)
as
begin	 
	declare @sql  nvarchar(max);	 
	 set @sql = 'select * into  '+@TableNameBack+'  from  '+@TableName;
	 exec(@sql);
end;

