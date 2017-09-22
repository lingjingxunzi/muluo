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
    exec sp_configure 'show advanced options', 1    --�������ø߼�ѡ��  
    reconfigure --��������  
    exec sp_configure 'xp_cmdshell', 1  --����xp_cmdshell  
    reconfigure --��������  
    exec xp_cmdshell @cmd  
  
    exec sp_configure 'xp_cmdshell', 0  --ִ����ɺ���ڰ�ȫ���ǿ��Խ�xp_cmdshell�ر�  
end  