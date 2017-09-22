 if exists(select * from sysobjects where name = 'PRO_GetMobileFrom')
 begin
	drop proc PRO_GetMobileFrom ;
 end 
 go
create PROCEDURE [dbo].[PRO_GetMobileFrom]
@MobileHead nvarchar(5)
as
declare @type nvarchar(20);
declare @three nvarchar(3);
declare @four nvarchar(4);
 begin  
 set @type = '';
 set @three = SUBSTRING(@MobileHead,1,3);
 if exists (select * from SplitStr('134,135,136,137,138,139,150,151,152,157,158,159,182,183,184,187,178,188,147',',')
 where a = @three)
 begin
 set 	@type='YD';
 end
 if exists (select * from SplitStr('130,131,132,145,155,156,176,185,186',',')
 where a = @three)
 begin
 set 	@type='LT';
 end
  if exists (select * from SplitStr('133,153,177,180,181,189',',')
 where a = @three)
 begin
 set 	@type='DX';
 end

 if @type=''
 begin
  set @four = SUBSTRING(@MobileHead,1,4);
  if(@four = '1705')
  begin
  set @type = 'YD';
  end

  if(@four = '1709')
  begin
  set @type = 'LT';
  end

    if(@four = '1349' or @four='1700')
  begin
  set @type = 'DX';
  end

 end

select @type;
 end
