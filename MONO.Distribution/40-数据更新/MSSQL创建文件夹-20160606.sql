if exists (select * from sysobjects where name = 'PRO_CreateDir')
begin
	drop proc  PRO_CreateDir;
end
go


create procedure PRO_CreateDir  
    @dir nvarchar(4000)
	  
as  
begin  
    declare @cmd nvarchar(4000)  
    declare @now datetime  
    set @now = getdate()      
    set @cmd = 'mkdir ' + @dir  
    exec sp_configure 'show advanced options', 1    --允许配置高级选项  
    reconfigure --重新配置  
    exec sp_configure 'xp_cmdshell', 1  --启用xp_cmdshell  
    reconfigure --重新配置  
    exec xp_cmdshell @cmd  
  
    exec sp_configure 'xp_cmdshell', 0  --执行完成后出于安全考虑可以将xp_cmdshell关闭  
end  