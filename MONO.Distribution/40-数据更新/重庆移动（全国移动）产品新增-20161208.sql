insert into FD_FlowBaseInfo([From],size,StandardPrice,[Range],PlatformCode,[Status],name)
values('CM',10,300,'BDQG','CMBQCQW000010','Y','�ƶ�.���챾��ȫ������.10M')

insert into FD_FlowBaseInfo([From],size,StandardPrice,[Range],PlatformCode,[Status],name)
values('CM',30,500,'BDQG','CMBQCQW000030','Y','�ƶ�.���챾��ȫ������.30M')

insert into FD_FlowBaseInfo([From],size,StandardPrice,[Range],PlatformCode,[Status],name)
values('CM',70,1000,'BDQG','CMBQCQW000070','Y','�ƶ�.���챾��ȫ������.70M')

insert into FD_FlowBaseInfo([From],size,StandardPrice,[Range],PlatformCode,[Status],name)
values('CM',150,2000,'BDQG','CMBQCQW000150','Y','�ƶ�.���챾��ȫ������.150M')

insert into FD_FlowBaseInfo([From],size,StandardPrice,[Range],PlatformCode,[Status],name)
values('CM',500,3000,'BDQG','CMBQCQW000500','N','�ƶ�.���챾��ȫ������.500M')

insert into FD_FlowBaseInfo([From],size,StandardPrice,[Range],PlatformCode,[Status],name)
values('CM',1024,5000,'BDQG','CMBQCQW001024','Y','�ƶ�.���챾��ȫ������.1G')

insert into FD_FlowBaseInfo([From],size,StandardPrice,[Range],PlatformCode,[Status],name)
values('CM',2048,7000,'BDQG','CMBQCQW002048','Y','�ƶ�.���챾��ȫ������.2G')





 insert into FD_FlowCode(FlowKey,[From],Carrier,ProductCode,Area,[Priority],Status,DiscountKey,PurchasePrice,FromRanges)
 select  fc.FlowKey,fc.[From],'CM023Whole','ZGYDA_10M',ar.AreaKey,1,'Y',dis.DiscountKey,(fc.StandardPrice * dis.Deduction /100), 'WholeRoam' 
 from FD_FlowBaseInfo fc,FD_Areas ar,FD_Discounts dis 
 where ar.Name  like '%����%' and dis.Deduction = 76 and fc.Name like '%�ƶ�.���챾��ȫ������.10M%' and fc.[From] = 'CM' 
  
 insert into FD_FlowCode(FlowKey,[From],Carrier,ProductCode,Area,[Priority],Status,DiscountKey,PurchasePrice,FromRanges)
 select  fc.FlowKey,fc.[From],'CM023Whole','ZGYDA_30M',ar.AreaKey,1,'Y',dis.DiscountKey,(fc.StandardPrice * dis.Deduction /100), 'WholeRoam' 
 from FD_FlowBaseInfo fc,FD_Areas ar,FD_Discounts dis 
 where ar.Name  like '%����%' and dis.Deduction = 76 and fc.Name like '%�ƶ�.���챾��ȫ������.30M%' and fc.[From] = 'CM' 
 
 insert into FD_FlowCode(FlowKey,[From],Carrier,ProductCode,Area,[Priority],Status,DiscountKey,PurchasePrice,FromRanges)
 select  fc.FlowKey,fc.[From],'CM023Whole','ZGYDA_70M',ar.AreaKey,1,'Y',dis.DiscountKey,(fc.StandardPrice * dis.Deduction /100), 'WholeRoam' 
 from FD_FlowBaseInfo fc,FD_Areas ar,FD_Discounts dis 
 where ar.Name  like '%����%' and dis.Deduction = 76 and fc.Name like '%�ƶ�.���챾��ȫ������.70M%' and fc.[From] = 'CM' 
 
 insert into FD_FlowCode(FlowKey,[From],Carrier,ProductCode,Area,[Priority],Status,DiscountKey,PurchasePrice,FromRanges)
 select  fc.FlowKey,fc.[From],'CM023Whole','ZGYDA_150M',ar.AreaKey,1,'Y',dis.DiscountKey,(fc.StandardPrice * dis.Deduction /100), 'WholeRoam' 
 from FD_FlowBaseInfo fc,FD_Areas ar,FD_Discounts dis 
 where ar.Name  like '%����%' and dis.Deduction = 76 and fc.Name like '%�ƶ�.���챾��ȫ������.150M%' and fc.[From] = 'CM' 
 
 insert into FD_FlowCode(FlowKey,[From],Carrier,ProductCode,Area,[Priority],Status,DiscountKey,PurchasePrice,FromRanges)
 select  fc.FlowKey,fc.[From],'CM023Whole','ZGYDA_500M',ar.AreaKey,1,'N',dis.DiscountKey,(fc.StandardPrice * dis.Deduction /100), 'WholeRoam' 
 from FD_FlowBaseInfo fc,FD_Areas ar,FD_Discounts dis 
 where ar.Name  like '%����%' and dis.Deduction = 76 and fc.Name like '%�ƶ�.���챾��ȫ������.500M%' and fc.[From] = 'CM' 
 
 insert into FD_FlowCode(FlowKey,[From],Carrier,ProductCode,Area,[Priority],Status,DiscountKey,PurchasePrice,FromRanges)
 select  fc.FlowKey,fc.[From],'CM023Whole','ZGYDA_1G',ar.AreaKey,1,'Y',dis.DiscountKey,(fc.StandardPrice * dis.Deduction /100), 'WholeRoam' 
 from FD_FlowBaseInfo fc,FD_Areas ar,FD_Discounts dis 
 where ar.Name  like '%����%' and dis.Deduction = 76 and fc.Name like '%�ƶ�.���챾��ȫ������.1G%' and fc.[From] = 'CM' 
 
 insert into FD_FlowCode(FlowKey,[From],Carrier,ProductCode,Area,[Priority],Status,DiscountKey,PurchasePrice,FromRanges)
 select  fc.FlowKey,fc.[From],'CM023Whole','ZGYDA_2G',ar.AreaKey,1,'Y',dis.DiscountKey,(fc.StandardPrice * dis.Deduction /100), 'WholeRoam' 
 from FD_FlowBaseInfo fc,FD_Areas ar,FD_Discounts dis 
 where ar.Name  like '%����%' and dis.Deduction = 76 and fc.Name like '%�ƶ�.���챾��ȫ������.2G%' and fc.[From] = 'CM' 