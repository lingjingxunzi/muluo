  insert into FD_FlowBaseInfo([From],size,StandardPrice,[Range],PlatformCode,[Status],name)
values('CU',20,300,'BDQG','CUBSD000020','Y','��ͨ.ɽ������.20M')

  insert into FD_FlowBaseInfo([From],size,StandardPrice,[Range],PlatformCode,[Status],name)
values('CU',50,500,'BDQG','CUBSD000050','Y','��ͨ.ɽ������.50M')

insert into FD_FlowBaseInfo([From],size,StandardPrice,[Range],PlatformCode,[Status],name)
values('CU',100,1000,'BDQG','CUBSD000100','Y','��ͨ.ɽ������.100M')

insert into FD_FlowBaseInfo([From],size,StandardPrice,[Range],PlatformCode,[Status],name)
values('CU',200,2000,'BDQG','CUBSD000200','Y','��ͨ.ɽ������.200M')

insert into FD_FlowBaseInfo([From],size,StandardPrice,[Range],PlatformCode,[Status],name)
values('CU',500,3000,'BDQG','CUBSD000500','Y','��ͨ.ɽ������.500M')

insert into FD_FlowBaseInfo([From],size,StandardPrice,[Range],PlatformCode,[Status],name)
values('CU',300,5000,'BDQG','CUBSD000300','Y','��ͨ.ɽ������.300M')

insert into FD_FlowBaseInfo([From],size,StandardPrice,[Range],PlatformCode,[Status],name)
values('CU',1024,7000,'BDQG','CUBSD001024','Y','��ͨ.ɽ������.1G')
  
 
 insert into FD_FlowCode(FlowKey,[From],Carrier,ProductCode,Area,[Priority],Status,DiscountKey,PurchasePrice,FromRanges)
 select  fc.FlowKey,fc.[From],'CU0531','1001',ar.AreaKey,1,'Y',dis.DiscountKey,(fc.StandardPrice * dis.Deduction /100), 'WholeRoam' 
 from FD_FlowBaseInfo fc,FD_Areas ar,FD_Discounts dis 
 where ar.Name  like '%ɽ��%' and dis.Deduction = 50 and fc.Name like '%��ͨ.ɽ������.20M%' and fc.[From] = 'CU' 
 
  insert into FD_FlowCode(FlowKey,[From],Carrier,ProductCode,Area,[Priority],Status,DiscountKey,PurchasePrice,FromRanges)
 select  fc.FlowKey,fc.[From],'CU0531','1002',ar.AreaKey,1,'Y',dis.DiscountKey,(fc.StandardPrice * dis.Deduction /100), 'WholeRoam' 
 from FD_FlowBaseInfo fc,FD_Areas ar,FD_Discounts dis 
 where ar.Name  like '%ɽ��%' and dis.Deduction = 50 and fc.Name like '%��ͨ.ɽ������.50M%' and fc.[From] = 'CU' 

 insert into FD_FlowCode(FlowKey,[From],Carrier,ProductCode,Area,[Priority],Status,DiscountKey,PurchasePrice,FromRanges)
 select  fc.FlowKey,fc.[From],'CU0531','1004',ar.AreaKey,1,'Y',dis.DiscountKey,(fc.StandardPrice * dis.Deduction /100), 'WholeRoam' 
 from FD_FlowBaseInfo fc,FD_Areas ar,FD_Discounts dis 
 where ar.Name  like '%ɽ��%' and dis.Deduction = 50 and fc.Name like '%��ͨ.ɽ������.100M%' and fc.[From] = 'CU' 

 insert into FD_FlowCode(FlowKey,[From],Carrier,ProductCode,Area,[Priority],Status,DiscountKey,PurchasePrice,FromRanges)
 select  fc.FlowKey,fc.[From],'CU0531','1005',ar.AreaKey,1,'Y',dis.DiscountKey,(fc.StandardPrice * dis.Deduction /100), 'WholeRoam' 
 from FD_FlowBaseInfo fc,FD_Areas ar,FD_Discounts dis 
 where ar.Name  like '%ɽ��%' and dis.Deduction = 50 and fc.Name like '%��ͨ.ɽ������.200M%' and fc.[From] = 'CU' 

 insert into FD_FlowCode(FlowKey,[From],Carrier,ProductCode,Area,[Priority],Status,DiscountKey,PurchasePrice,FromRanges)
 select  fc.FlowKey,fc.[From],'CU0531','1006',ar.AreaKey,1,'Y',dis.DiscountKey,(fc.StandardPrice * dis.Deduction /100), 'WholeRoam' 
 from FD_FlowBaseInfo fc,FD_Areas ar,FD_Discounts dis 
 where ar.Name  like '%ɽ��%' and dis.Deduction = 50 and fc.Name like '%��ͨ.ɽ������.500M%' and fc.[From] = 'CU' 
 insert into FD_FlowCode(FlowKey,[From],Carrier,ProductCode,Area,[Priority],Status,DiscountKey,PurchasePrice,FromRanges)
 select  fc.FlowKey,fc.[From],'CU0531','1011',ar.AreaKey,1,'Y',dis.DiscountKey,(fc.StandardPrice * dis.Deduction /100), 'WholeRoam' 
 from FD_FlowBaseInfo fc,FD_Areas ar,FD_Discounts dis 
 where ar.Name  like '%ɽ��%' and dis.Deduction = 50 and fc.Name like '%��ͨ.ɽ������.300M%' and fc.[From] = 'CU' 
 insert into FD_FlowCode(FlowKey,[From],Carrier,ProductCode,Area,[Priority],Status,DiscountKey,PurchasePrice,FromRanges)
 select  fc.FlowKey,fc.[From],'CU0531','1012',ar.AreaKey,1,'Y',dis.DiscountKey,(fc.StandardPrice * dis.Deduction /100), 'WholeRoam' 
 from FD_FlowBaseInfo fc,FD_Areas ar,FD_Discounts dis 
 where ar.Name  like '%ɽ��%' and dis.Deduction = 50 and fc.Name like '%��ͨ.ɽ������.1G%' and fc.[From] = 'CU' 
  

  
 insert into FD_FlowCode(FlowKey,[From],Carrier,ProductCode,Area,[Priority],Status,DiscountKey,PurchasePrice,FromRanges)
 select  fc.FlowKey,fc.[From],'CU0531','1013',ar.AreaKey,2,'Y',dis.DiscountKey,(fc.StandardPrice * dis.Deduction /100), 'Province' 
 from FD_FlowBaseInfo fc,FD_Areas ar,FD_Discounts dis 
 where ar.Name  like '%ɽ��%' and dis.Deduction = 50 and fc.Name like '%��ͨ.ɽ������.20M%' and fc.[From] = 'CU' 
 
  insert into FD_FlowCode(FlowKey,[From],Carrier,ProductCode,Area,[Priority],Status,DiscountKey,PurchasePrice,FromRanges)
 select  fc.FlowKey,fc.[From],'CU0531','1007',ar.AreaKey,2,'Y',dis.DiscountKey,(fc.StandardPrice * dis.Deduction /100), 'Province' 
 from FD_FlowBaseInfo fc,FD_Areas ar,FD_Discounts dis 
 where ar.Name  like '%ɽ��%' and dis.Deduction = 50 and fc.Name like '%��ͨ.ɽ������.50M%' and fc.[From] = 'CU' 

 insert into FD_FlowCode(FlowKey,[From],Carrier,ProductCode,Area,[Priority],Status,DiscountKey,PurchasePrice,FromRanges)
 select  fc.FlowKey,fc.[From],'CU0531','1008',ar.AreaKey,2,'Y',dis.DiscountKey,(fc.StandardPrice * dis.Deduction /100), 'Province' 
 from FD_FlowBaseInfo fc,FD_Areas ar,FD_Discounts dis 
 where ar.Name  like '%ɽ��%' and dis.Deduction = 50 and fc.Name like '%��ͨ.ɽ������.100M%' and fc.[From] = 'CU' 

 insert into FD_FlowCode(FlowKey,[From],Carrier,ProductCode,Area,[Priority],Status,DiscountKey,PurchasePrice,FromRanges)
 select  fc.FlowKey,fc.[From],'CU0531','1014',ar.AreaKey,2,'Y',dis.DiscountKey,(fc.StandardPrice * dis.Deduction /100), 'Province' 
 from FD_FlowBaseInfo fc,FD_Areas ar,FD_Discounts dis 
 where ar.Name  like '%ɽ��%' and dis.Deduction = 50 and fc.Name like '%��ͨ.ɽ������.200M%' and fc.[From] = 'CU' 

 insert into FD_FlowCode(FlowKey,[From],Carrier,ProductCode,Area,[Priority],Status,DiscountKey,PurchasePrice,FromRanges)
 select  fc.FlowKey,fc.[From],'CU0531','1010',ar.AreaKey,2,'Y',dis.DiscountKey,(fc.StandardPrice * dis.Deduction /100), 'Province' 
 from FD_FlowBaseInfo fc,FD_Areas ar,FD_Discounts dis 
 where ar.Name  like '%ɽ��%' and dis.Deduction = 50 and fc.Name like '%��ͨ.ɽ������.500M%' and fc.[From] = 'CU' 
 
 insert into FD_FlowCode(FlowKey,[From],Carrier,ProductCode,Area,[Priority],Status,DiscountKey,PurchasePrice,FromRanges)
 select  fc.FlowKey,fc.[From],'CU0531','1009',ar.AreaKey,2,'Y',dis.DiscountKey,(fc.StandardPrice * dis.Deduction /100), 'Province' 
 from FD_FlowBaseInfo fc,FD_Areas ar,FD_Discounts dis 
 where ar.Name  like '%ɽ��%' and dis.Deduction = 50 and fc.Name like '%��ͨ.ɽ������.300M%' and fc.[From] = 'CU' 
 
 insert into FD_FlowCode(FlowKey,[From],Carrier,ProductCode,Area,[Priority],Status,DiscountKey,PurchasePrice,FromRanges)
 select  fc.FlowKey,fc.[From],'CU0531','1015',ar.AreaKey,2,'Y',dis.DiscountKey,(fc.StandardPrice * dis.Deduction /100), 'Province' 
 from FD_FlowBaseInfo fc,FD_Areas ar,FD_Discounts dis 
 where ar.Name  like '%ɽ��%' and dis.Deduction = 50 and fc.Name like '%��ͨ.ɽ������.1G%' and fc.[From] = 'CU' 
  