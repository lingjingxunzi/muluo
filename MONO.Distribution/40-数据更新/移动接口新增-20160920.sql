  insert into FD_FlowBaseInfo([From],size,StandardPrice,[Range],PlatformCode,[Status],name)
values('CM',10,300,'QGIN','CMQGIN000010','Y','�ƶ�.ȫ������ֱ����.10M')

  insert into FD_FlowBaseInfo([From],size,StandardPrice,[Range],PlatformCode,[Status],name)
values('CM',30,500,'QGIN','CMQGIN000030','Y','�ƶ�.ȫ������ֱ����.30M')

insert into FD_FlowBaseInfo([From],size,StandardPrice,[Range],PlatformCode,[Status],name)
values('CM',70,1000,'QGIN','CMQGIN000070','Y','�ƶ�.ȫ������ֱ����.70M')

insert into FD_FlowBaseInfo([From],size,StandardPrice,[Range],PlatformCode,[Status],name)
values('CM',150,2000,'QGIN','CMQGIN000150','Y','�ƶ�.ȫ������ֱ����.150M')

insert into FD_FlowBaseInfo([From],size,StandardPrice,[Range],PlatformCode,[Status],name)
values('CM',500,3000,'QGIN','CMQGIN000500','Y','�ƶ�.ȫ������ֱ����.500M')

insert into FD_FlowBaseInfo([From],size,StandardPrice,[Range],PlatformCode,[Status],name)
values('CM',1024,5000,'QGIN','CMQGIN001024','Y','�ƶ�.ȫ������ֱ����.1G')

insert into FD_FlowBaseInfo([From],size,StandardPrice,[Range],PlatformCode,[Status],name)
values('CM',2048,7000,'QGIN','CMQGIN002048','Y','�ƶ�.ȫ������ֱ����.2G')

insert into FD_FlowBaseInfo([From],size,StandardPrice,[Range],PlatformCode,[Status],name)
values('CM',3072,10000,'QGIN','CMQGIN003072','Y','�ƶ�.ȫ������ֱ����.3G')

insert into FD_FlowBaseInfo([From],size,StandardPrice,[Range],PlatformCode,[Status],name)
values('CM',4096,13000,'QGIN','CMQGIN004096','Y','�ƶ�.ȫ������ֱ����.4G')

insert into FD_FlowBaseInfo([From],size,StandardPrice,[Range],PlatformCode,[Status],name)
values('CM',6144,18000,'QGIN','CMQGIN006144','Y','�ƶ�.ȫ������ֱ����.6G')
  
  insert into FD_FlowBaseInfo([From],size,StandardPrice,[Range],PlatformCode,[Status],name)
values('CM',11264,28800,'QGIN','CMQGIN011264','Y','�ƶ�.ȫ������ֱ����.11G')

 
 insert into FD_FlowCode(FlowKey,[From],Carrier,ProductCode,Area,[Priority],Status,DiscountKey,PurchasePrice,FromRanges)
 select  fc.FlowKey,fc.[From],'CMWhole','ZGYDA_10M',ar.AreaKey,1,'Y',dis.DiscountKey,(fc.StandardPrice * dis.Deduction /100), 'WholeRoam' 
 from FD_FlowBaseInfo fc,FD_Areas ar,FD_Discounts dis 
 where ar.Name  like '%ȫ��%' and dis.Deduction = 50 and fc.Name like '%�ƶ�.ȫ������ֱ����.10M%' and fc.[From] = 'CM' 
 
  insert into FD_FlowCode(FlowKey,[From],Carrier,ProductCode,Area,[Priority],Status,DiscountKey,PurchasePrice,FromRanges)
 select  fc.FlowKey,fc.[From],'CMWhole','ZGYDA_30M',ar.AreaKey,1,'Y',dis.DiscountKey,(fc.StandardPrice * dis.Deduction /100), 'WholeRoam' 
 from FD_FlowBaseInfo fc,FD_Areas ar,FD_Discounts dis 
 where ar.Name  like '%ȫ��%' and dis.Deduction = 50 and fc.Name like '%�ƶ�.ȫ������ֱ����.30M%' and fc.[From] = 'CM' 

 insert into FD_FlowCode(FlowKey,[From],Carrier,ProductCode,Area,[Priority],Status,DiscountKey,PurchasePrice,FromRanges)
 select  fc.FlowKey,fc.[From],'CMWhole','ZGYDA_70M',ar.AreaKey,1,'Y',dis.DiscountKey,(fc.StandardPrice * dis.Deduction /100), 'WholeRoam' 
 from FD_FlowBaseInfo fc,FD_Areas ar,FD_Discounts dis 
 where ar.Name  like '%ȫ��%' and dis.Deduction = 50 and fc.Name like '%�ƶ�.ȫ������ֱ����.70M%' and fc.[From] = 'CM' 

 insert into FD_FlowCode(FlowKey,[From],Carrier,ProductCode,Area,[Priority],Status,DiscountKey,PurchasePrice,FromRanges)
 select  fc.FlowKey,fc.[From],'CMWhole','ZGYDA_150M',ar.AreaKey,1,'Y',dis.DiscountKey,(fc.StandardPrice * dis.Deduction /100), 'WholeRoam' 
 from FD_FlowBaseInfo fc,FD_Areas ar,FD_Discounts dis 
 where ar.Name  like '%ȫ��%' and dis.Deduction = 50 and fc.Name like '%�ƶ�.ȫ������ֱ����.150M%' and fc.[From] = 'CM' 

 insert into FD_FlowCode(FlowKey,[From],Carrier,ProductCode,Area,[Priority],Status,DiscountKey,PurchasePrice,FromRanges)
 select  fc.FlowKey,fc.[From],'CMWhole','ZGYDA_500M',ar.AreaKey,1,'Y',dis.DiscountKey,(fc.StandardPrice * dis.Deduction /100), 'WholeRoam' 
 from FD_FlowBaseInfo fc,FD_Areas ar,FD_Discounts dis 
 where ar.Name  like '%ȫ��%' and dis.Deduction = 50 and fc.Name like '%�ƶ�.ȫ������ֱ����.500M%' and fc.[From] = 'CM' 
 insert into FD_FlowCode(FlowKey,[From],Carrier,ProductCode,Area,[Priority],Status,DiscountKey,PurchasePrice,FromRanges)
 select  fc.FlowKey,fc.[From],'CMWhole','ZGYDA_1G',ar.AreaKey,1,'Y',dis.DiscountKey,(fc.StandardPrice * dis.Deduction /100), 'WholeRoam' 
 from FD_FlowBaseInfo fc,FD_Areas ar,FD_Discounts dis 
 where ar.Name  like '%ȫ��%' and dis.Deduction = 50 and fc.Name like '%�ƶ�.ȫ������ֱ����.1G%' and fc.[From] = 'CM' 
 insert into FD_FlowCode(FlowKey,[From],Carrier,ProductCode,Area,[Priority],Status,DiscountKey,PurchasePrice,FromRanges)
 select  fc.FlowKey,fc.[From],'CMWhole','ZGYDA_2G',ar.AreaKey,1,'Y',dis.DiscountKey,(fc.StandardPrice * dis.Deduction /100), 'WholeRoam' 
 from FD_FlowBaseInfo fc,FD_Areas ar,FD_Discounts dis 
 where ar.Name  like '%ȫ��%' and dis.Deduction = 50 and fc.Name like '%�ƶ�.ȫ������ֱ����.2G%' and fc.[From] = 'CM' 
  
   insert into FD_FlowCode(FlowKey,[From],Carrier,ProductCode,Area,[Priority],Status,DiscountKey,PurchasePrice,FromRanges)
 select  fc.FlowKey,fc.[From],'CMWhole','ZGYDA_3G',ar.AreaKey,1,'Y',dis.DiscountKey,(fc.StandardPrice * dis.Deduction /100), 'WholeRoam' 
 from FD_FlowBaseInfo fc,FD_Areas ar,FD_Discounts dis 
 where ar.Name  like '%ȫ��%' and dis.Deduction = 50 and fc.Name like '%�ƶ�.ȫ������ֱ����.3G%' and fc.[From] = 'CM' 
  
 insert into FD_FlowCode(FlowKey,[From],Carrier,ProductCode,Area,[Priority],Status,DiscountKey,PurchasePrice,FromRanges)
 select  fc.FlowKey,fc.[From],'CMWhole','ZGYDA_4G',ar.AreaKey,1,'Y',dis.DiscountKey,(fc.StandardPrice * dis.Deduction /100), 'WholeRoam' 
 from FD_FlowBaseInfo fc,FD_Areas ar,FD_Discounts dis 
 where ar.Name  like '%ȫ��%' and dis.Deduction = 50 and fc.Name like '%�ƶ�.ȫ������ֱ����.4G%' and fc.[From] = 'CM' 
  
 insert into FD_FlowCode(FlowKey,[From],Carrier,ProductCode,Area,[Priority],Status,DiscountKey,PurchasePrice,FromRanges)
 select  fc.FlowKey,fc.[From],'CMWhole','ZGYDA_6G',ar.AreaKey,1,'Y',dis.DiscountKey,(fc.StandardPrice * dis.Deduction /100), 'WholeRoam' 
 from FD_FlowBaseInfo fc,FD_Areas ar,FD_Discounts dis 
 where ar.Name  like '%ȫ��%' and dis.Deduction = 50 and fc.Name like '%�ƶ�.ȫ������ֱ����.6G%' and fc.[From] = 'CM' 
  
 insert into FD_FlowCode(FlowKey,[From],Carrier,ProductCode,Area,[Priority],Status,DiscountKey,PurchasePrice,FromRanges)
 select  fc.FlowKey,fc.[From],'CMWhole','ZGYDA_11G',ar.AreaKey,1,'Y',dis.DiscountKey,(fc.StandardPrice * dis.Deduction /100), 'WholeRoam' 
 from FD_FlowBaseInfo fc,FD_Areas ar,FD_Discounts dis 
 where ar.Name  like '%ȫ��%' and dis.Deduction = 50 and fc.Name like '%�ƶ�.ȫ������ֱ����.11G%' and fc.[From] = 'CM' 
  
