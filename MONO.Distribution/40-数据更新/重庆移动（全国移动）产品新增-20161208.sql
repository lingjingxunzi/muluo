insert into FD_FlowBaseInfo([From],size,StandardPrice,[Range],PlatformCode,[Status],name)
values('CM',10,300,'BDQG','CMBQCQW000010','Y','移动.重庆本地全国漫游.10M')

insert into FD_FlowBaseInfo([From],size,StandardPrice,[Range],PlatformCode,[Status],name)
values('CM',30,500,'BDQG','CMBQCQW000030','Y','移动.重庆本地全国漫游.30M')

insert into FD_FlowBaseInfo([From],size,StandardPrice,[Range],PlatformCode,[Status],name)
values('CM',70,1000,'BDQG','CMBQCQW000070','Y','移动.重庆本地全国漫游.70M')

insert into FD_FlowBaseInfo([From],size,StandardPrice,[Range],PlatformCode,[Status],name)
values('CM',150,2000,'BDQG','CMBQCQW000150','Y','移动.重庆本地全国漫游.150M')

insert into FD_FlowBaseInfo([From],size,StandardPrice,[Range],PlatformCode,[Status],name)
values('CM',500,3000,'BDQG','CMBQCQW000500','N','移动.重庆本地全国漫游.500M')

insert into FD_FlowBaseInfo([From],size,StandardPrice,[Range],PlatformCode,[Status],name)
values('CM',1024,5000,'BDQG','CMBQCQW001024','Y','移动.重庆本地全国漫游.1G')

insert into FD_FlowBaseInfo([From],size,StandardPrice,[Range],PlatformCode,[Status],name)
values('CM',2048,7000,'BDQG','CMBQCQW002048','Y','移动.重庆本地全国漫游.2G')





 insert into FD_FlowCode(FlowKey,[From],Carrier,ProductCode,Area,[Priority],Status,DiscountKey,PurchasePrice,FromRanges)
 select  fc.FlowKey,fc.[From],'CM023Whole','ZGYDA_10M',ar.AreaKey,1,'Y',dis.DiscountKey,(fc.StandardPrice * dis.Deduction /100), 'WholeRoam' 
 from FD_FlowBaseInfo fc,FD_Areas ar,FD_Discounts dis 
 where ar.Name  like '%重庆%' and dis.Deduction = 76 and fc.Name like '%移动.重庆本地全国漫游.10M%' and fc.[From] = 'CM' 
  
 insert into FD_FlowCode(FlowKey,[From],Carrier,ProductCode,Area,[Priority],Status,DiscountKey,PurchasePrice,FromRanges)
 select  fc.FlowKey,fc.[From],'CM023Whole','ZGYDA_30M',ar.AreaKey,1,'Y',dis.DiscountKey,(fc.StandardPrice * dis.Deduction /100), 'WholeRoam' 
 from FD_FlowBaseInfo fc,FD_Areas ar,FD_Discounts dis 
 where ar.Name  like '%重庆%' and dis.Deduction = 76 and fc.Name like '%移动.重庆本地全国漫游.30M%' and fc.[From] = 'CM' 
 
 insert into FD_FlowCode(FlowKey,[From],Carrier,ProductCode,Area,[Priority],Status,DiscountKey,PurchasePrice,FromRanges)
 select  fc.FlowKey,fc.[From],'CM023Whole','ZGYDA_70M',ar.AreaKey,1,'Y',dis.DiscountKey,(fc.StandardPrice * dis.Deduction /100), 'WholeRoam' 
 from FD_FlowBaseInfo fc,FD_Areas ar,FD_Discounts dis 
 where ar.Name  like '%重庆%' and dis.Deduction = 76 and fc.Name like '%移动.重庆本地全国漫游.70M%' and fc.[From] = 'CM' 
 
 insert into FD_FlowCode(FlowKey,[From],Carrier,ProductCode,Area,[Priority],Status,DiscountKey,PurchasePrice,FromRanges)
 select  fc.FlowKey,fc.[From],'CM023Whole','ZGYDA_150M',ar.AreaKey,1,'Y',dis.DiscountKey,(fc.StandardPrice * dis.Deduction /100), 'WholeRoam' 
 from FD_FlowBaseInfo fc,FD_Areas ar,FD_Discounts dis 
 where ar.Name  like '%重庆%' and dis.Deduction = 76 and fc.Name like '%移动.重庆本地全国漫游.150M%' and fc.[From] = 'CM' 
 
 insert into FD_FlowCode(FlowKey,[From],Carrier,ProductCode,Area,[Priority],Status,DiscountKey,PurchasePrice,FromRanges)
 select  fc.FlowKey,fc.[From],'CM023Whole','ZGYDA_500M',ar.AreaKey,1,'N',dis.DiscountKey,(fc.StandardPrice * dis.Deduction /100), 'WholeRoam' 
 from FD_FlowBaseInfo fc,FD_Areas ar,FD_Discounts dis 
 where ar.Name  like '%重庆%' and dis.Deduction = 76 and fc.Name like '%移动.重庆本地全国漫游.500M%' and fc.[From] = 'CM' 
 
 insert into FD_FlowCode(FlowKey,[From],Carrier,ProductCode,Area,[Priority],Status,DiscountKey,PurchasePrice,FromRanges)
 select  fc.FlowKey,fc.[From],'CM023Whole','ZGYDA_1G',ar.AreaKey,1,'Y',dis.DiscountKey,(fc.StandardPrice * dis.Deduction /100), 'WholeRoam' 
 from FD_FlowBaseInfo fc,FD_Areas ar,FD_Discounts dis 
 where ar.Name  like '%重庆%' and dis.Deduction = 76 and fc.Name like '%移动.重庆本地全国漫游.1G%' and fc.[From] = 'CM' 
 
 insert into FD_FlowCode(FlowKey,[From],Carrier,ProductCode,Area,[Priority],Status,DiscountKey,PurchasePrice,FromRanges)
 select  fc.FlowKey,fc.[From],'CM023Whole','ZGYDA_2G',ar.AreaKey,1,'Y',dis.DiscountKey,(fc.StandardPrice * dis.Deduction /100), 'WholeRoam' 
 from FD_FlowBaseInfo fc,FD_Areas ar,FD_Discounts dis 
 where ar.Name  like '%重庆%' and dis.Deduction = 76 and fc.Name like '%移动.重庆本地全国漫游.2G%' and fc.[From] = 'CM' 