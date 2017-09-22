USE [MONO.FD]
GO
/****** Object:  StoredProcedure [dbo].[PRO_FullBackup]    Script Date: 2016/6/8 14:56:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

ALTER proc [dbo].[PRO_FullBackup]
@FileName nvarchar(50),
@FilePath nvarchar(200)
as
declare @SQL nvarchar(max)
BEGIN TRY 
	SET @FileName = @FilePath+'\'+@FileName;
	exec PRO_CreateDir  @FilePath;
    SET @SQL = 'BACKUP DATABASE [MONO.FD] TO DISK = ''' + @FileName + '.bak' +
    ''' WITH NOINIT, NOUNLOAD, NAME = N'' MONO.FD_backup'', NOSKIP, STATS = 10, NOFORMAT'
    EXEC(@SQL)
	 
END TRY 
BEGIN CATCH 
DECLARE @ErrorMessage NVARCHAR(4000);   

SELECT @ErrorMessage = ERROR_MESSAGE() ;
 
END CATCH; 
	

 