 if exists (select * from sysobjects where name = 'SplitStr')
 begin
		drop function SplitStr;
 end
 go 
 
 create  function  SplitStr  (@inputstr varchar(8000),@seprator varchar(10))

returns @temp table (a varchar(200))

as

begin

  declare @i int

  set @inputstr = rtrim(ltrim(@inputstr))

  set @i = charindex(@seprator, @inputstr)

  while @i >= 1

  begin

    insert @temp values(left(@inputstr, @i - 1))

    set @inputstr = substring(@inputstr, @i + 1, len(@inputstr) - @i)

    set @i = charindex(@seprator, @inputstr)

  end

  if @inputstr <> '\'

  insert @temp values(@inputstr)

  return

end
