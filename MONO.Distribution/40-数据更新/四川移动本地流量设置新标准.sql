insert into FD_FlowBaseInfo([From],size,StandardPrice,[Range],PlatformCode,[Status],name)
values('CM',10,300,'BD','CMBDSC000010','Y','移动.四川本地.10M')

insert into FD_FlowBaseInfo([From],size,StandardPrice,[Range],PlatformCode,[Status],name)
values('CM',30,500,'BD','CMBDSC000030','Y','移动.四川本地.30M')

insert into FD_FlowBaseInfo([From],size,StandardPrice,[Range],PlatformCode,[Status],name)
values('CM',70,1000,'BD','CMBDSC000070','Y','移动.四川本地.70M')

insert into FD_FlowBaseInfo([From],size,StandardPrice,[Range],PlatformCode,[Status],name)
values('CM',150,2000,'BD','CMBDSC000300','Y','移动.四川本地.300M')

insert into FD_FlowBaseInfo([From],size,StandardPrice,[Range],PlatformCode,[Status],name)
values('CM',500,3000,'BD','CMBDSC000500','N','移动.四川本地.500M')

insert into FD_FlowBaseInfo([From],size,StandardPrice,[Range],PlatformCode,[Status],name)
values('CM',700,4000,'BD','CMBDSC000700','N','移动.四川本地.700M')

insert into FD_FlowBaseInfo([From],size,StandardPrice,[Range],PlatformCode,[Status],name)
values('CM',1024,5000,'BD','CMBDSC001024','Y','移动.四川本地.1G')

insert into FD_FlowBaseInfo([From],size,StandardPrice,[Range],PlatformCode,[Status],name)
values('CM',2048,7000,'BD','CMBDSC002048','Y','移动.四川本地.2G') 

insert into FD_FlowBaseInfo([From],size,StandardPrice,[Range],PlatformCode,[Status],name)
values('CM',3072,10000,'BD','CMBDSC003072','Y','移动.四川本地.3G')

insert into FD_FlowBaseInfo([From],size,StandardPrice,[Range],PlatformCode,[Status],name)
values('CM',4096,13000,'BD','CMBDSC004096','Y','移动.四川本地.4G')



 


 insert into FD_FlowCode(FlowKey,[From],Carrier,ProductCode,Area,[Priority],Status,DiscountKey,PurchasePrice,FromRanges)
 select  fc.FlowKey,fc.[From],'CM028','ACAZ28545',ar.AreaKey,1,'Y',dis.DiscountKey,(fc.StandardPrice * dis.Deduction /100), 'Province' 
 from FD_FlowBaseInfo fc,FD_Areas ar,FD_Discounts dis 
 where ar.Name  like '%成都%' and dis.Deduction = 70 and fc.Name like '%移动.四川本地.10M%' and fc.[From] = 'CM' 
  
 insert into FD_FlowCode(FlowKey,[From],Carrier,ProductCode,Area,[Priority],Status,DiscountKey,PurchasePrice,FromRanges)
 select  fc.FlowKey,fc.[From],'CM028','ACAZ28546',ar.AreaKey,1,'Y',dis.DiscountKey,(fc.StandardPrice * dis.Deduction /100), 'Province' 
 from FD_FlowBaseInfo fc,FD_Areas ar,FD_Discounts dis 
 where ar.Name  like '%成都%' and dis.Deduction = 70 and fc.Name like '%移动.四川本地.30M%' and fc.[From] = 'CM' 
 
 insert into FD_FlowCode(FlowKey,[From],Carrier,ProductCode,Area,[Priority],Status,DiscountKey,PurchasePrice,FromRanges)
 select  fc.FlowKey,fc.[From],'CM028','ACAZ28547',ar.AreaKey,1,'Y',dis.DiscountKey,(fc.StandardPrice * dis.Deduction /100), 'Province' 
 from FD_FlowBaseInfo fc,FD_Areas ar,FD_Discounts dis 
 where ar.Name  like '%成都%' and dis.Deduction = 70 and fc.Name like '%移动.四川本地.70M%' and fc.[From] = 'CM' 
 
 insert into FD_FlowCode(FlowKey,[From],Carrier,ProductCode,Area,[Priority],Status,DiscountKey,PurchasePrice,FromRanges)
 select  fc.FlowKey,fc.[From],'CM028','ACAZ28548',ar.AreaKey,1,'Y',dis.DiscountKey,(fc.StandardPrice * dis.Deduction /100), 'Province' 
 from FD_FlowBaseInfo fc,FD_Areas ar,FD_Discounts dis 
 where ar.Name  like '%成都%' and dis.Deduction = 70 and fc.Name like '%移动.四川本地.300M%' and fc.[From] = 'CM' 
 
 insert into FD_FlowCode(FlowKey,[From],Carrier,ProductCode,Area,[Priority],Status,DiscountKey,PurchasePrice,FromRanges)
 select  fc.FlowKey,fc.[From],'CM028','ACAZ28549',ar.AreaKey,1,'N',dis.DiscountKey,(fc.StandardPrice * dis.Deduction /100), 'Province' 
 from FD_FlowBaseInfo fc,FD_Areas ar,FD_Discounts dis 
 where ar.Name  like '%成都%' and dis.Deduction = 70 and fc.Name like '%移动.四川本地.500M%' and fc.[From] = 'CM' 
 
  insert into FD_FlowCode(FlowKey,[From],Carrier,ProductCode,Area,[Priority],Status,DiscountKey,PurchasePrice,FromRanges)
 select  fc.FlowKey,fc.[From],'CM028','ACAZ28550',ar.AreaKey,1,'N',dis.DiscountKey,(fc.StandardPrice * dis.Deduction /100), 'Province' 
 from FD_FlowBaseInfo fc,FD_Areas ar,FD_Discounts dis 
 where ar.Name  like '%成都%' and dis.Deduction = 70 and fc.Name like '%移动.四川本地.700M%' and fc.[From] = 'CM' 
 

 insert into FD_FlowCode(FlowKey,[From],Carrier,ProductCode,Area,[Priority],Status,DiscountKey,PurchasePrice,FromRanges)
 select  fc.FlowKey,fc.[From],'CM028','ACAZ28551',ar.AreaKey,1,'Y',dis.DiscountKey,(fc.StandardPrice * dis.Deduction /100), 'Province' 
 from FD_FlowBaseInfo fc,FD_Areas ar,FD_Discounts dis 
 where ar.Name  like '%成都%' and dis.Deduction = 70 and fc.Name like '%移动.四川本地.1G%' and fc.[From] = 'CM' 
 
 insert into FD_FlowCode(FlowKey,[From],Carrier,ProductCode,Area,[Priority],Status,DiscountKey,PurchasePrice,FromRanges)
 select  fc.FlowKey,fc.[From],'CM028','ACAZ28552',ar.AreaKey,1,'Y',dis.DiscountKey,(fc.StandardPrice * dis.Deduction /100), 'Province' 
 from FD_FlowBaseInfo fc,FD_Areas ar,FD_Discounts dis 
 where ar.Name  like '%成都%' and dis.Deduction = 70 and fc.Name like '%移动.四川本地.2G%' and fc.[From] = 'CM' 

  insert into FD_FlowCode(FlowKey,[From],Carrier,ProductCode,Area,[Priority],Status,DiscountKey,PurchasePrice,FromRanges)
 select  fc.FlowKey,fc.[From],'CM028','ACAZ28553',ar.AreaKey,1,'Y',dis.DiscountKey,(fc.StandardPrice * dis.Deduction /100), 'Province' 
 from FD_FlowBaseInfo fc,FD_Areas ar,FD_Discounts dis 
 where ar.Name  like '%成都%' and dis.Deduction = 70 and fc.Name like '%移动.四川本地.3G%' and fc.[From] = 'CM' 


  insert into FD_FlowCode(FlowKey,[From],Carrier,ProductCode,Area,[Priority],Status,DiscountKey,PurchasePrice,FromRanges)
 select  fc.FlowKey,fc.[From],'CM028','ACAZ28554',ar.AreaKey,1,'Y',dis.DiscountKey,(fc.StandardPrice * dis.Deduction /100), 'Province' 
 from FD_FlowBaseInfo fc,FD_Areas ar,FD_Discounts dis 
 where ar.Name  like '%成都%' and dis.Deduction = 70 and fc.Name like '%移动.四川本地.4G%' and fc.[From] = 'CM' 