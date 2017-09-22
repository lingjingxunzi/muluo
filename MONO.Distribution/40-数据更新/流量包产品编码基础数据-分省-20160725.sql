 ---------------------------------------------移动 10M------------------------------------------------------------------------------------

 insert into FD_FlowCode(FlowKey,[From],Carrier,ProductCode,Area,[Priority],Status,DiscountKey,PurchasePrice,FromRanges)
 select  fc.FlowKey,fc.[From],'XYP','yd10',ar.AreaKey,1,'Y',dis.DiscountKey,(fc.StandardPrice * dis.Deduction /100), 'WholeRoam' 
 from FD_FlowBaseInfo fc,FD_Areas ar,FD_Discounts dis 
 where ar.Name  like '%安徽%' and dis.Deduction = 59 and fc.Name like '%移动.安徽漫游.10M%' and fc.[From] = 'CM' 


 insert into FD_FlowCode(FlowKey,[From],Carrier,ProductCode,Area,[Priority],Status,DiscountKey,PurchasePrice,FromRanges)
 select  fc.FlowKey,fc.[From],'XYP','yd10',ar.AreaKey,1,'Y',dis.DiscountKey,(fc.StandardPrice * dis.Deduction /100), 'WholeRoam' 
 from FD_FlowBaseInfo fc,FD_Areas ar,FD_Discounts dis 
 where ar.Name  like '%山西%' and dis.Deduction = 53 and fc.Name like  '%移动.山西漫游.10M%' and fc.[From] = 'CM' 

  insert into FD_FlowCode(FlowKey,[From],Carrier,ProductCode,Area,[Priority],Status,DiscountKey,PurchasePrice,FromRanges)
 select  fc.FlowKey,fc.[From],'XYP','yd10',ar.AreaKey,1,'Y',dis.DiscountKey,(fc.StandardPrice * dis.Deduction /100), 'WholeRoam' 
 from FD_FlowBaseInfo fc,FD_Areas ar,FD_Discounts dis 
 where ar.Name  like '%浙江%' and dis.Deduction = 66 and fc.Name like  '%移动.浙江漫游.10M%' and fc.[From] = 'CM' 


   insert into FD_FlowCode(FlowKey,[From],Carrier,ProductCode,Area,[Priority],Status,DiscountKey,PurchasePrice,FromRanges)
 select  fc.FlowKey,fc.[From],'XYP','yd10',ar.AreaKey,1,'Y',dis.DiscountKey,(fc.StandardPrice * dis.Deduction /100), 'WholeRoam' 
 from FD_FlowBaseInfo fc,FD_Areas ar,FD_Discounts dis 
 where ar.Name  like '%海南%' and dis.Deduction = 69 and fc.Name like  '%移动.海南漫游.10M%' and fc.[From] = 'CM' 


   insert into FD_FlowCode(FlowKey,[From],Carrier,ProductCode,Area,[Priority],Status,DiscountKey,PurchasePrice,FromRanges)
 select  fc.FlowKey,fc.[From],'XYP','yd10',ar.AreaKey,1,'Y',dis.DiscountKey,(fc.StandardPrice * dis.Deduction /100), 'WholeRoam' 
 from FD_FlowBaseInfo fc,FD_Areas ar,FD_Discounts dis 
 where ar.Name  like '%福建%' and dis.Deduction = 56 and fc.Name like  '%移动.福建漫游.10M%' and fc.[From] = 'CM' 


   insert into FD_FlowCode(FlowKey,[From],Carrier,ProductCode,Area,[Priority],Status,DiscountKey,PurchasePrice,FromRanges)
 select  fc.FlowKey,fc.[From],'XYP','yd10',ar.AreaKey,1,'Y',dis.DiscountKey,(fc.StandardPrice * dis.Deduction /100), 'WholeRoam' 
 from FD_FlowBaseInfo fc,FD_Areas ar,FD_Discounts dis 
 where ar.Name  like '%贵州%' and dis.Deduction = 70 and fc.Name like  '%移动.贵州漫游.10M%' and fc.[From] = 'CM' 

   insert into FD_FlowCode(FlowKey,[From],Carrier,ProductCode,Area,[Priority],Status,DiscountKey,PurchasePrice,FromRanges)
 select  fc.FlowKey,fc.[From],'XYP','yd10',ar.AreaKey,1,'Y',dis.DiscountKey,(fc.StandardPrice * dis.Deduction /100), 'WholeRoam' 
 from FD_FlowBaseInfo fc,FD_Areas ar,FD_Discounts dis 
 where ar.Name  like '%山东%' and dis.Deduction = 63 and fc.Name like  '%移动.山东漫游.10M%' and fc.[From] = 'CM' 


  insert into FD_FlowCode(FlowKey,[From],Carrier,ProductCode,Area,[Priority],Status,DiscountKey,PurchasePrice,FromRanges)
 select  fc.FlowKey,fc.[From],'XYP','yd10',ar.AreaKey,1,'Y',dis.DiscountKey,(fc.StandardPrice * dis.Deduction /100), 'WholeRoam' 
 from FD_FlowBaseInfo fc,FD_Areas ar,FD_Discounts dis 
 where ar.Name  like '%内蒙古%' and dis.Deduction = 78 and fc.Name like  '%移动.内蒙古漫游.10M%' and fc.[From] = 'CM' 

 insert into FD_FlowCode(FlowKey,[From],Carrier,ProductCode,Area,[Priority],Status,DiscountKey,PurchasePrice,FromRanges)
 select  fc.FlowKey,fc.[From],'XYP','yd10',ar.AreaKey,1,'Y',dis.DiscountKey,(fc.StandardPrice * dis.Deduction /100), 'WholeRoam' 
 from FD_FlowBaseInfo fc,FD_Areas ar,FD_Discounts dis 
 where ar.Name  like '%天津%' and dis.Deduction = 74 and fc.Name like  '%移动.天津漫游.10M%' and fc.[From] = 'CM' 


 insert into FD_FlowCode(FlowKey,[From],Carrier,ProductCode,Area,[Priority],Status,DiscountKey,PurchasePrice,FromRanges)
 select  fc.FlowKey,fc.[From],'XYP','yd10',ar.AreaKey,1,'Y',dis.DiscountKey,(fc.StandardPrice * dis.Deduction /100), 'WholeRoam' 
 from FD_FlowBaseInfo fc,FD_Areas ar,FD_Discounts dis 
 where ar.Name  like '%湖南%' and dis.Deduction = 81 and fc.Name like  '%移动.湖南漫游.10M%' and fc.[From] = 'CM' 


 insert into FD_FlowCode(FlowKey,[From],Carrier,ProductCode,Area,[Priority],Status,DiscountKey,PurchasePrice,FromRanges)
 select  fc.FlowKey,fc.[From],'XYP','yd10',ar.AreaKey,1,'Y',dis.DiscountKey,(fc.StandardPrice * dis.Deduction /100), 'WholeRoam' 
 from FD_FlowBaseInfo fc,FD_Areas ar,FD_Discounts dis 
 where ar.Name  like '%广东%' and dis.Deduction = 72 and fc.Name like  '%移动.广东漫游.10M%' and fc.[From] = 'CM' 


  ---------------------------------------------移动 30M------------------------------------------------------------------------------------

 insert into FD_FlowCode(FlowKey,[From],Carrier,ProductCode,Area,[Priority],Status,DiscountKey,PurchasePrice,FromRanges)
 select  fc.FlowKey,fc.[From],'XYP','yd30',ar.AreaKey,1,'Y',dis.DiscountKey,(fc.StandardPrice * dis.Deduction /100), 'WholeRoam' 
 from FD_FlowBaseInfo fc,FD_Areas ar,FD_Discounts dis 
 where ar.Name  like '%安徽%' and dis.Deduction = 59 and fc.Name like '%移动.安徽漫游.30M%' and fc.[From] = 'CM' 


 insert into FD_FlowCode(FlowKey,[From],Carrier,ProductCode,Area,[Priority],Status,DiscountKey,PurchasePrice,FromRanges)
 select  fc.FlowKey,fc.[From],'XYP','yd30',ar.AreaKey,1,'Y',dis.DiscountKey,(fc.StandardPrice * dis.Deduction /100), 'WholeRoam' 
 from FD_FlowBaseInfo fc,FD_Areas ar,FD_Discounts dis 
 where ar.Name  like '%山西%' and dis.Deduction = 53 and fc.Name like  '%移动.山西漫游.30M%' and fc.[From] = 'CM' 

  insert into FD_FlowCode(FlowKey,[From],Carrier,ProductCode,Area,[Priority],Status,DiscountKey,PurchasePrice,FromRanges)
 select  fc.FlowKey,fc.[From],'XYP','yd30',ar.AreaKey,1,'Y',dis.DiscountKey,(fc.StandardPrice * dis.Deduction /100), 'WholeRoam' 
 from FD_FlowBaseInfo fc,FD_Areas ar,FD_Discounts dis 
 where ar.Name  like '%浙江%' and dis.Deduction = 66 and fc.Name like  '%移动.浙江漫游.30M%' and fc.[From] = 'CM' 


   insert into FD_FlowCode(FlowKey,[From],Carrier,ProductCode,Area,[Priority],Status,DiscountKey,PurchasePrice,FromRanges)
 select  fc.FlowKey,fc.[From],'XYP','yd30',ar.AreaKey,1,'Y',dis.DiscountKey,(fc.StandardPrice * dis.Deduction /100), 'WholeRoam' 
 from FD_FlowBaseInfo fc,FD_Areas ar,FD_Discounts dis 
 where ar.Name  like '%海南%' and dis.Deduction = 69 and fc.Name like  '%移动.海南漫游.30M%' and fc.[From] = 'CM' 


   insert into FD_FlowCode(FlowKey,[From],Carrier,ProductCode,Area,[Priority],Status,DiscountKey,PurchasePrice,FromRanges)
 select  fc.FlowKey,fc.[From],'XYP','yd30',ar.AreaKey,1,'Y',dis.DiscountKey,(fc.StandardPrice * dis.Deduction /100), 'WholeRoam' 
 from FD_FlowBaseInfo fc,FD_Areas ar,FD_Discounts dis 
 where ar.Name  like '%福建%' and dis.Deduction = 56 and fc.Name like  '%移动.福建漫游.30M%' and fc.[From] = 'CM' 


   insert into FD_FlowCode(FlowKey,[From],Carrier,ProductCode,Area,[Priority],Status,DiscountKey,PurchasePrice,FromRanges)
 select  fc.FlowKey,fc.[From],'XYP','yd30',ar.AreaKey,1,'Y',dis.DiscountKey,(fc.StandardPrice * dis.Deduction /100), 'WholeRoam' 
 from FD_FlowBaseInfo fc,FD_Areas ar,FD_Discounts dis 
 where ar.Name  like '%贵州%' and dis.Deduction = 70 and fc.Name like  '%移动.贵州漫游.30M%' and fc.[From] = 'CM' 

   insert into FD_FlowCode(FlowKey,[From],Carrier,ProductCode,Area,[Priority],Status,DiscountKey,PurchasePrice,FromRanges)
 select  fc.FlowKey,fc.[From],'XYP','yd30',ar.AreaKey,1,'Y',dis.DiscountKey,(fc.StandardPrice * dis.Deduction /100), 'WholeRoam' 
 from FD_FlowBaseInfo fc,FD_Areas ar,FD_Discounts dis 
 where ar.Name  like '%山东%' and dis.Deduction = 63 and fc.Name like  '%移动.山东漫游.30M%' and fc.[From] = 'CM' 


  insert into FD_FlowCode(FlowKey,[From],Carrier,ProductCode,Area,[Priority],Status,DiscountKey,PurchasePrice,FromRanges)
 select  fc.FlowKey,fc.[From],'XYP','yd30',ar.AreaKey,1,'Y',dis.DiscountKey,(fc.StandardPrice * dis.Deduction /100), 'WholeRoam' 
 from FD_FlowBaseInfo fc,FD_Areas ar,FD_Discounts dis 
 where ar.Name  like '%内蒙古%' and dis.Deduction = 78 and fc.Name like  '%移动.内蒙古漫游.30M%' and fc.[From] = 'CM' 

 insert into FD_FlowCode(FlowKey,[From],Carrier,ProductCode,Area,[Priority],Status,DiscountKey,PurchasePrice,FromRanges)
 select  fc.FlowKey,fc.[From],'XYP','yd30',ar.AreaKey,1,'Y',dis.DiscountKey,(fc.StandardPrice * dis.Deduction /100), 'WholeRoam' 
 from FD_FlowBaseInfo fc,FD_Areas ar,FD_Discounts dis 
 where ar.Name  like '%天津%' and dis.Deduction = 74 and fc.Name like  '%移动.天津漫游.30M%' and fc.[From] = 'CM' 


 insert into FD_FlowCode(FlowKey,[From],Carrier,ProductCode,Area,[Priority],Status,DiscountKey,PurchasePrice,FromRanges)
 select  fc.FlowKey,fc.[From],'XYP','yd30',ar.AreaKey,1,'Y',dis.DiscountKey,(fc.StandardPrice * dis.Deduction /100), 'WholeRoam' 
 from FD_FlowBaseInfo fc,FD_Areas ar,FD_Discounts dis 
 where ar.Name  like '%湖南%' and dis.Deduction = 81 and fc.Name like  '%移动.湖南漫游.30M%' and fc.[From] = 'CM' 


 insert into FD_FlowCode(FlowKey,[From],Carrier,ProductCode,Area,[Priority],Status,DiscountKey,PurchasePrice,FromRanges)
 select  fc.FlowKey,fc.[From],'XYP','yd30',ar.AreaKey,1,'Y',dis.DiscountKey,(fc.StandardPrice * dis.Deduction /100), 'WholeRoam' 
 from FD_FlowBaseInfo fc,FD_Areas ar,FD_Discounts dis 
 where ar.Name  like '%广东%' and dis.Deduction = 72 and fc.Name like  '%移动.广东漫游.30M%' and fc.[From] = 'CM'
 
 
 
  ---------------------------------------------移动 70M------------------------------------------------------------------------------------

 insert into FD_FlowCode(FlowKey,[From],Carrier,ProductCode,Area,[Priority],Status,DiscountKey,PurchasePrice,FromRanges)
 select  fc.FlowKey,fc.[From],'XYP','yd70',ar.AreaKey,1,'Y',dis.DiscountKey,(fc.StandardPrice * dis.Deduction /100), 'WholeRoam' 
 from FD_FlowBaseInfo fc,FD_Areas ar,FD_Discounts dis 
 where ar.Name  like '%安徽%' and dis.Deduction = 59 and fc.Name like '%移动.安徽漫游.70M%' and fc.[From] = 'CM' 


 insert into FD_FlowCode(FlowKey,[From],Carrier,ProductCode,Area,[Priority],Status,DiscountKey,PurchasePrice,FromRanges)
 select  fc.FlowKey,fc.[From],'XYP','yd70',ar.AreaKey,1,'Y',dis.DiscountKey,(fc.StandardPrice * dis.Deduction /100), 'WholeRoam' 
 from FD_FlowBaseInfo fc,FD_Areas ar,FD_Discounts dis 
 where ar.Name  like '%山西%' and dis.Deduction = 53 and fc.Name like  '%移动.山西漫游.70M%' and fc.[From] = 'CM' 

  insert into FD_FlowCode(FlowKey,[From],Carrier,ProductCode,Area,[Priority],Status,DiscountKey,PurchasePrice,FromRanges)
 select  fc.FlowKey,fc.[From],'XYP','yd70',ar.AreaKey,1,'Y',dis.DiscountKey,(fc.StandardPrice * dis.Deduction /100), 'WholeRoam' 
 from FD_FlowBaseInfo fc,FD_Areas ar,FD_Discounts dis 
 where ar.Name  like '%浙江%' and dis.Deduction = 66 and fc.Name like  '%移动.浙江漫游.70M%' and fc.[From] = 'CM' 


   insert into FD_FlowCode(FlowKey,[From],Carrier,ProductCode,Area,[Priority],Status,DiscountKey,PurchasePrice,FromRanges)
 select  fc.FlowKey,fc.[From],'XYP','yd70',ar.AreaKey,1,'Y',dis.DiscountKey,(fc.StandardPrice * dis.Deduction /100), 'WholeRoam' 
 from FD_FlowBaseInfo fc,FD_Areas ar,FD_Discounts dis 
 where ar.Name  like '%海南%' and dis.Deduction = 69 and fc.Name like  '%移动.海南漫游.70M%' and fc.[From] = 'CM' 


   insert into FD_FlowCode(FlowKey,[From],Carrier,ProductCode,Area,[Priority],Status,DiscountKey,PurchasePrice,FromRanges)
 select  fc.FlowKey,fc.[From],'XYP','yd70',ar.AreaKey,1,'Y',dis.DiscountKey,(fc.StandardPrice * dis.Deduction /100), 'WholeRoam' 
 from FD_FlowBaseInfo fc,FD_Areas ar,FD_Discounts dis 
 where ar.Name  like '%福建%' and dis.Deduction = 56 and fc.Name like  '%移动.福建漫游.70M%' and fc.[From] = 'CM' 


   insert into FD_FlowCode(FlowKey,[From],Carrier,ProductCode,Area,[Priority],Status,DiscountKey,PurchasePrice,FromRanges)
 select  fc.FlowKey,fc.[From],'XYP','yd70',ar.AreaKey,1,'Y',dis.DiscountKey,(fc.StandardPrice * dis.Deduction /100), 'WholeRoam' 
 from FD_FlowBaseInfo fc,FD_Areas ar,FD_Discounts dis 
 where ar.Name  like '%贵州%' and dis.Deduction = 70 and fc.Name like  '%移动.贵州漫游.70M%' and fc.[From] = 'CM' 

   insert into FD_FlowCode(FlowKey,[From],Carrier,ProductCode,Area,[Priority],Status,DiscountKey,PurchasePrice,FromRanges)
 select  fc.FlowKey,fc.[From],'XYP','yd70',ar.AreaKey,1,'Y',dis.DiscountKey,(fc.StandardPrice * dis.Deduction /100), 'WholeRoam' 
 from FD_FlowBaseInfo fc,FD_Areas ar,FD_Discounts dis 
 where ar.Name  like '%山东%' and dis.Deduction = 63 and fc.Name like  '%移动.山东漫游.70M%' and fc.[From] = 'CM' 


  insert into FD_FlowCode(FlowKey,[From],Carrier,ProductCode,Area,[Priority],Status,DiscountKey,PurchasePrice,FromRanges)
 select  fc.FlowKey,fc.[From],'XYP','yd70',ar.AreaKey,1,'Y',dis.DiscountKey,(fc.StandardPrice * dis.Deduction /100), 'WholeRoam' 
 from FD_FlowBaseInfo fc,FD_Areas ar,FD_Discounts dis 
 where ar.Name  like '%内蒙古%' and dis.Deduction = 78 and fc.Name like  '%移动.内蒙古漫游.70M%' and fc.[From] = 'CM' 

 insert into FD_FlowCode(FlowKey,[From],Carrier,ProductCode,Area,[Priority],Status,DiscountKey,PurchasePrice,FromRanges)
 select  fc.FlowKey,fc.[From],'XYP','yd70',ar.AreaKey,1,'Y',dis.DiscountKey,(fc.StandardPrice * dis.Deduction /100), 'WholeRoam' 
 from FD_FlowBaseInfo fc,FD_Areas ar,FD_Discounts dis 
 where ar.Name  like '%天津%' and dis.Deduction = 74 and fc.Name like  '%移动.天津漫游.70M%' and fc.[From] = 'CM' 


 insert into FD_FlowCode(FlowKey,[From],Carrier,ProductCode,Area,[Priority],Status,DiscountKey,PurchasePrice,FromRanges)
 select  fc.FlowKey,fc.[From],'XYP','yd70',ar.AreaKey,1,'Y',dis.DiscountKey,(fc.StandardPrice * dis.Deduction /100), 'WholeRoam' 
 from FD_FlowBaseInfo fc,FD_Areas ar,FD_Discounts dis 
 where ar.Name  like '%湖南%' and dis.Deduction = 81 and fc.Name like  '%移动.湖南漫游.70M%' and fc.[From] = 'CM' 


 insert into FD_FlowCode(FlowKey,[From],Carrier,ProductCode,Area,[Priority],Status,DiscountKey,PurchasePrice,FromRanges)
 select  fc.FlowKey,fc.[From],'XYP','yd70',ar.AreaKey,1,'Y',dis.DiscountKey,(fc.StandardPrice * dis.Deduction /100), 'WholeRoam' 
 from FD_FlowBaseInfo fc,FD_Areas ar,FD_Discounts dis 
 where ar.Name  like '%广东%' and dis.Deduction = 72 and fc.Name like  '%移动.广东漫游.70M%' and fc.[From] = 'CM'  



  ---------------------------------------------移动 150M------------------------------------------------------------------------------------

 insert into FD_FlowCode(FlowKey,[From],Carrier,ProductCode,Area,[Priority],Status,DiscountKey,PurchasePrice,FromRanges)
 select  fc.FlowKey,fc.[From],'XYP','yd150',ar.AreaKey,1,'Y',dis.DiscountKey,(fc.StandardPrice * dis.Deduction /100), 'WholeRoam' 
 from FD_FlowBaseInfo fc,FD_Areas ar,FD_Discounts dis 
 where ar.Name  like '%安徽%' and dis.Deduction = 59 and fc.Name like '%移动.安徽漫游.150M%' and fc.[From] = 'CM' 


 insert into FD_FlowCode(FlowKey,[From],Carrier,ProductCode,Area,[Priority],Status,DiscountKey,PurchasePrice,FromRanges)
 select  fc.FlowKey,fc.[From],'XYP','yd150',ar.AreaKey,1,'Y',dis.DiscountKey,(fc.StandardPrice * dis.Deduction /100), 'WholeRoam' 
 from FD_FlowBaseInfo fc,FD_Areas ar,FD_Discounts dis 
 where ar.Name  like '%山西%' and dis.Deduction = 53 and fc.Name like  '%移动.山西漫游.150M%' and fc.[From] = 'CM' 

  insert into FD_FlowCode(FlowKey,[From],Carrier,ProductCode,Area,[Priority],Status,DiscountKey,PurchasePrice,FromRanges)
 select  fc.FlowKey,fc.[From],'XYP','yd150',ar.AreaKey,1,'Y',dis.DiscountKey,(fc.StandardPrice * dis.Deduction /100), 'WholeRoam' 
 from FD_FlowBaseInfo fc,FD_Areas ar,FD_Discounts dis 
 where ar.Name  like '%浙江%' and dis.Deduction = 66 and fc.Name like  '%移动.浙江漫游.150M%' and fc.[From] = 'CM' 


   insert into FD_FlowCode(FlowKey,[From],Carrier,ProductCode,Area,[Priority],Status,DiscountKey,PurchasePrice,FromRanges)
 select  fc.FlowKey,fc.[From],'XYP','yd150',ar.AreaKey,1,'Y',dis.DiscountKey,(fc.StandardPrice * dis.Deduction /100), 'WholeRoam' 
 from FD_FlowBaseInfo fc,FD_Areas ar,FD_Discounts dis 
 where ar.Name  like '%海南%' and dis.Deduction = 69 and fc.Name like  '%移动.海南漫游.150M%' and fc.[From] = 'CM' 


   insert into FD_FlowCode(FlowKey,[From],Carrier,ProductCode,Area,[Priority],Status,DiscountKey,PurchasePrice,FromRanges)
 select  fc.FlowKey,fc.[From],'XYP','yd150',ar.AreaKey,1,'Y',dis.DiscountKey,(fc.StandardPrice * dis.Deduction /100), 'WholeRoam' 
 from FD_FlowBaseInfo fc,FD_Areas ar,FD_Discounts dis 
 where ar.Name  like '%福建%' and dis.Deduction = 56 and fc.Name like  '%移动.福建漫游.150M%' and fc.[From] = 'CM' 


   insert into FD_FlowCode(FlowKey,[From],Carrier,ProductCode,Area,[Priority],Status,DiscountKey,PurchasePrice,FromRanges)
 select  fc.FlowKey,fc.[From],'XYP','yd150',ar.AreaKey,1,'Y',dis.DiscountKey,(fc.StandardPrice * dis.Deduction /100), 'WholeRoam' 
 from FD_FlowBaseInfo fc,FD_Areas ar,FD_Discounts dis 
 where ar.Name  like '%贵州%' and dis.Deduction = 70 and fc.Name like  '%移动.贵州漫游.150M%' and fc.[From] = 'CM' 

   insert into FD_FlowCode(FlowKey,[From],Carrier,ProductCode,Area,[Priority],Status,DiscountKey,PurchasePrice,FromRanges)
 select  fc.FlowKey,fc.[From],'XYP','yd150',ar.AreaKey,1,'Y',dis.DiscountKey,(fc.StandardPrice * dis.Deduction /100), 'WholeRoam' 
 from FD_FlowBaseInfo fc,FD_Areas ar,FD_Discounts dis 
 where ar.Name  like '%山东%' and dis.Deduction = 63 and fc.Name like  '%移动.山东漫游.150M%' and fc.[From] = 'CM' 


  insert into FD_FlowCode(FlowKey,[From],Carrier,ProductCode,Area,[Priority],Status,DiscountKey,PurchasePrice,FromRanges)
 select  fc.FlowKey,fc.[From],'XYP','yd150',ar.AreaKey,1,'Y',dis.DiscountKey,(fc.StandardPrice * dis.Deduction /100), 'WholeRoam' 
 from FD_FlowBaseInfo fc,FD_Areas ar,FD_Discounts dis 
 where ar.Name  like '%内蒙古%' and dis.Deduction = 78 and fc.Name like  '%移动.内蒙古漫游.150M%' and fc.[From] = 'CM' 

 insert into FD_FlowCode(FlowKey,[From],Carrier,ProductCode,Area,[Priority],Status,DiscountKey,PurchasePrice,FromRanges)
 select  fc.FlowKey,fc.[From],'XYP','yd150',ar.AreaKey,1,'Y',dis.DiscountKey,(fc.StandardPrice * dis.Deduction /100), 'WholeRoam' 
 from FD_FlowBaseInfo fc,FD_Areas ar,FD_Discounts dis 
 where ar.Name  like '%天津%' and dis.Deduction = 74 and fc.Name like  '%移动.天津漫游.150M%' and fc.[From] = 'CM' 


 insert into FD_FlowCode(FlowKey,[From],Carrier,ProductCode,Area,[Priority],Status,DiscountKey,PurchasePrice,FromRanges)
 select  fc.FlowKey,fc.[From],'XYP','yd150',ar.AreaKey,1,'Y',dis.DiscountKey,(fc.StandardPrice * dis.Deduction /100), 'WholeRoam' 
 from FD_FlowBaseInfo fc,FD_Areas ar,FD_Discounts dis 
 where ar.Name  like '%湖南%' and dis.Deduction = 81 and fc.Name like  '%移动.湖南漫游.150M%' and fc.[From] = 'CM' 


 insert into FD_FlowCode(FlowKey,[From],Carrier,ProductCode,Area,[Priority],Status,DiscountKey,PurchasePrice,FromRanges)
 select  fc.FlowKey,fc.[From],'XYP','yd150',ar.AreaKey,1,'Y',dis.DiscountKey,(fc.StandardPrice * dis.Deduction /100), 'WholeRoam' 
 from FD_FlowBaseInfo fc,FD_Areas ar,FD_Discounts dis 
 where ar.Name  like '%广东%' and dis.Deduction = 72 and fc.Name like  '%移动.广东漫游.150M%' and fc.[From] = 'CM'  
  


   ---------------------------------------------移动 500M------------------------------------------------------------------------------------

 insert into FD_FlowCode(FlowKey,[From],Carrier,ProductCode,Area,[Priority],Status,DiscountKey,PurchasePrice,FromRanges)
 select  fc.FlowKey,fc.[From],'XYP','yd500',ar.AreaKey,1,'Y',dis.DiscountKey,(fc.StandardPrice * dis.Deduction /100), 'WholeRoam' 
 from FD_FlowBaseInfo fc,FD_Areas ar,FD_Discounts dis 
 where ar.Name  like '%安徽%' and dis.Deduction = 59 and fc.Name like '%移动.安徽漫游.500M%' and fc.[From] = 'CM' 


 insert into FD_FlowCode(FlowKey,[From],Carrier,ProductCode,Area,[Priority],Status,DiscountKey,PurchasePrice,FromRanges)
 select  fc.FlowKey,fc.[From],'XYP','yd500',ar.AreaKey,1,'Y',dis.DiscountKey,(fc.StandardPrice * dis.Deduction /100), 'WholeRoam' 
 from FD_FlowBaseInfo fc,FD_Areas ar,FD_Discounts dis 
 where ar.Name  like '%山西%' and dis.Deduction = 53 and fc.Name like  '%移动.山西漫游.500M%' and fc.[From] = 'CM' 

  insert into FD_FlowCode(FlowKey,[From],Carrier,ProductCode,Area,[Priority],Status,DiscountKey,PurchasePrice,FromRanges)
 select  fc.FlowKey,fc.[From],'XYP','yd500',ar.AreaKey,1,'Y',dis.DiscountKey,(fc.StandardPrice * dis.Deduction /100), 'WholeRoam' 
 from FD_FlowBaseInfo fc,FD_Areas ar,FD_Discounts dis 
 where ar.Name  like '%浙江%' and dis.Deduction = 66 and fc.Name like  '%移动.浙江漫游.500M%' and fc.[From] = 'CM' 


   insert into FD_FlowCode(FlowKey,[From],Carrier,ProductCode,Area,[Priority],Status,DiscountKey,PurchasePrice,FromRanges)
 select  fc.FlowKey,fc.[From],'XYP','yd500',ar.AreaKey,1,'Y',dis.DiscountKey,(fc.StandardPrice * dis.Deduction /100), 'WholeRoam' 
 from FD_FlowBaseInfo fc,FD_Areas ar,FD_Discounts dis 
 where ar.Name  like '%海南%' and dis.Deduction = 69 and fc.Name like  '%移动.海南漫游.500M%' and fc.[From] = 'CM' 


   insert into FD_FlowCode(FlowKey,[From],Carrier,ProductCode,Area,[Priority],Status,DiscountKey,PurchasePrice,FromRanges)
 select  fc.FlowKey,fc.[From],'XYP','yd500',ar.AreaKey,1,'Y',dis.DiscountKey,(fc.StandardPrice * dis.Deduction /100), 'WholeRoam' 
 from FD_FlowBaseInfo fc,FD_Areas ar,FD_Discounts dis 
 where ar.Name  like '%福建%' and dis.Deduction = 56 and fc.Name like  '%移动.福建漫游.500M%' and fc.[From] = 'CM' 


   insert into FD_FlowCode(FlowKey,[From],Carrier,ProductCode,Area,[Priority],Status,DiscountKey,PurchasePrice,FromRanges)
 select  fc.FlowKey,fc.[From],'XYP','yd500',ar.AreaKey,1,'Y',dis.DiscountKey,(fc.StandardPrice * dis.Deduction /100), 'WholeRoam' 
 from FD_FlowBaseInfo fc,FD_Areas ar,FD_Discounts dis 
 where ar.Name  like '%贵州%' and dis.Deduction = 70 and fc.Name like  '%移动.贵州漫游.500M%' and fc.[From] = 'CM' 

   insert into FD_FlowCode(FlowKey,[From],Carrier,ProductCode,Area,[Priority],Status,DiscountKey,PurchasePrice,FromRanges)
 select  fc.FlowKey,fc.[From],'XYP','yd500',ar.AreaKey,1,'Y',dis.DiscountKey,(fc.StandardPrice * dis.Deduction /100), 'WholeRoam' 
 from FD_FlowBaseInfo fc,FD_Areas ar,FD_Discounts dis 
 where ar.Name  like '%山东%' and dis.Deduction = 63 and fc.Name like  '%移动.山东漫游.500M%' and fc.[From] = 'CM' 


  insert into FD_FlowCode(FlowKey,[From],Carrier,ProductCode,Area,[Priority],Status,DiscountKey,PurchasePrice,FromRanges)
 select  fc.FlowKey,fc.[From],'XYP','yd500',ar.AreaKey,1,'Y',dis.DiscountKey,(fc.StandardPrice * dis.Deduction /100), 'WholeRoam' 
 from FD_FlowBaseInfo fc,FD_Areas ar,FD_Discounts dis 
 where ar.Name  like '%内蒙古%' and dis.Deduction = 78 and fc.Name like  '%移动.内蒙古漫游.500M%' and fc.[From] = 'CM' 

 insert into FD_FlowCode(FlowKey,[From],Carrier,ProductCode,Area,[Priority],Status,DiscountKey,PurchasePrice,FromRanges)
 select  fc.FlowKey,fc.[From],'XYP','yd500',ar.AreaKey,1,'Y',dis.DiscountKey,(fc.StandardPrice * dis.Deduction /100), 'WholeRoam' 
 from FD_FlowBaseInfo fc,FD_Areas ar,FD_Discounts dis 
 where ar.Name  like '%天津%' and dis.Deduction = 74 and fc.Name like  '%移动.天津漫游.500M%' and fc.[From] = 'CM' 


 insert into FD_FlowCode(FlowKey,[From],Carrier,ProductCode,Area,[Priority],Status,DiscountKey,PurchasePrice,FromRanges)
 select  fc.FlowKey,fc.[From],'XYP','yd500',ar.AreaKey,1,'Y',dis.DiscountKey,(fc.StandardPrice * dis.Deduction /100), 'WholeRoam' 
 from FD_FlowBaseInfo fc,FD_Areas ar,FD_Discounts dis 
 where ar.Name  like '%湖南%' and dis.Deduction = 81 and fc.Name like  '%移动.湖南漫游.500M%' and fc.[From] = 'CM' 


 insert into FD_FlowCode(FlowKey,[From],Carrier,ProductCode,Area,[Priority],Status,DiscountKey,PurchasePrice,FromRanges)
 select  fc.FlowKey,fc.[From],'XYP','yd500',ar.AreaKey,1,'Y',dis.DiscountKey,(fc.StandardPrice * dis.Deduction /100), 'WholeRoam' 
 from FD_FlowBaseInfo fc,FD_Areas ar,FD_Discounts dis 
 where ar.Name  like '%广东%' and dis.Deduction = 72 and fc.Name like  '%移动.广东漫游.500M%' and fc.[From] = 'CM'  
  
  


   ---------------------------------------------移动 1G------------------------------------------------------------------------------------

 insert into FD_FlowCode(FlowKey,[From],Carrier,ProductCode,Area,[Priority],Status,DiscountKey,PurchasePrice,FromRanges)
 select  fc.FlowKey,fc.[From],'XYP','yd1024',ar.AreaKey,1,'Y',dis.DiscountKey,(fc.StandardPrice * dis.Deduction /100), 'WholeRoam' 
 from FD_FlowBaseInfo fc,FD_Areas ar,FD_Discounts dis 
 where ar.Name  like '%安徽%' and dis.Deduction = 59 and fc.Name like '%移动.安徽漫游.1G%' and fc.[From] = 'CM' 


 insert into FD_FlowCode(FlowKey,[From],Carrier,ProductCode,Area,[Priority],Status,DiscountKey,PurchasePrice,FromRanges)
 select  fc.FlowKey,fc.[From],'XYP','yd1024',ar.AreaKey,1,'Y',dis.DiscountKey,(fc.StandardPrice * dis.Deduction /100), 'WholeRoam' 
 from FD_FlowBaseInfo fc,FD_Areas ar,FD_Discounts dis 
 where ar.Name  like '%山西%' and dis.Deduction = 53 and fc.Name like  '%移动.山西漫游.1G%' and fc.[From] = 'CM' 

  insert into FD_FlowCode(FlowKey,[From],Carrier,ProductCode,Area,[Priority],Status,DiscountKey,PurchasePrice,FromRanges)
 select  fc.FlowKey,fc.[From],'XYP','yd1024',ar.AreaKey,1,'Y',dis.DiscountKey,(fc.StandardPrice * dis.Deduction /100), 'WholeRoam' 
 from FD_FlowBaseInfo fc,FD_Areas ar,FD_Discounts dis 
 where ar.Name  like '%浙江%' and dis.Deduction = 66 and fc.Name like  '%移动.浙江漫游.1G%' and fc.[From] = 'CM' 


   insert into FD_FlowCode(FlowKey,[From],Carrier,ProductCode,Area,[Priority],Status,DiscountKey,PurchasePrice,FromRanges)
 select  fc.FlowKey,fc.[From],'XYP','yd1024',ar.AreaKey,1,'Y',dis.DiscountKey,(fc.StandardPrice * dis.Deduction /100), 'WholeRoam' 
 from FD_FlowBaseInfo fc,FD_Areas ar,FD_Discounts dis 
 where ar.Name  like '%海南%' and dis.Deduction = 69 and fc.Name like  '%移动.海南漫游.1G%' and fc.[From] = 'CM' 


   insert into FD_FlowCode(FlowKey,[From],Carrier,ProductCode,Area,[Priority],Status,DiscountKey,PurchasePrice,FromRanges)
 select  fc.FlowKey,fc.[From],'XYP','yd1024',ar.AreaKey,1,'Y',dis.DiscountKey,(fc.StandardPrice * dis.Deduction /100), 'WholeRoam' 
 from FD_FlowBaseInfo fc,FD_Areas ar,FD_Discounts dis 
 where ar.Name  like '%福建%' and dis.Deduction = 56 and fc.Name like  '%移动.福建漫游.1G%' and fc.[From] = 'CM' 


   insert into FD_FlowCode(FlowKey,[From],Carrier,ProductCode,Area,[Priority],Status,DiscountKey,PurchasePrice,FromRanges)
 select  fc.FlowKey,fc.[From],'XYP','yd1024',ar.AreaKey,1,'Y',dis.DiscountKey,(fc.StandardPrice * dis.Deduction /100), 'WholeRoam' 
 from FD_FlowBaseInfo fc,FD_Areas ar,FD_Discounts dis 
 where ar.Name  like '%贵州%' and dis.Deduction = 70 and fc.Name like  '%移动.贵州漫游.1G%' and fc.[From] = 'CM' 

   insert into FD_FlowCode(FlowKey,[From],Carrier,ProductCode,Area,[Priority],Status,DiscountKey,PurchasePrice,FromRanges)
 select  fc.FlowKey,fc.[From],'XYP','yd1024',ar.AreaKey,1,'Y',dis.DiscountKey,(fc.StandardPrice * dis.Deduction /100), 'WholeRoam' 
 from FD_FlowBaseInfo fc,FD_Areas ar,FD_Discounts dis 
 where ar.Name  like '%山东%' and dis.Deduction = 63 and fc.Name like  '%移动.山东漫游.1G%' and fc.[From] = 'CM' 


  insert into FD_FlowCode(FlowKey,[From],Carrier,ProductCode,Area,[Priority],Status,DiscountKey,PurchasePrice,FromRanges)
 select  fc.FlowKey,fc.[From],'XYP','yd1024',ar.AreaKey,1,'Y',dis.DiscountKey,(fc.StandardPrice * dis.Deduction /100), 'WholeRoam' 
 from FD_FlowBaseInfo fc,FD_Areas ar,FD_Discounts dis 
 where ar.Name  like '%内蒙古%' and dis.Deduction = 78 and fc.Name like  '%移动.内蒙古漫游.1G%' and fc.[From] = 'CM' 

 insert into FD_FlowCode(FlowKey,[From],Carrier,ProductCode,Area,[Priority],Status,DiscountKey,PurchasePrice,FromRanges)
 select  fc.FlowKey,fc.[From],'XYP','yd1024',ar.AreaKey,1,'Y',dis.DiscountKey,(fc.StandardPrice * dis.Deduction /100), 'WholeRoam' 
 from FD_FlowBaseInfo fc,FD_Areas ar,FD_Discounts dis 
 where ar.Name  like '%天津%' and dis.Deduction = 74 and fc.Name like  '%移动.天津漫游.1G%' and fc.[From] = 'CM' 


 insert into FD_FlowCode(FlowKey,[From],Carrier,ProductCode,Area,[Priority],Status,DiscountKey,PurchasePrice,FromRanges)
 select  fc.FlowKey,fc.[From],'XYP','yd1024',ar.AreaKey,1,'Y',dis.DiscountKey,(fc.StandardPrice * dis.Deduction /100), 'WholeRoam' 
 from FD_FlowBaseInfo fc,FD_Areas ar,FD_Discounts dis 
 where ar.Name  like '%湖南%' and dis.Deduction = 81 and fc.Name like  '%移动.湖南漫游.1G%' and fc.[From] = 'CM' 


 insert into FD_FlowCode(FlowKey,[From],Carrier,ProductCode,Area,[Priority],Status,DiscountKey,PurchasePrice,FromRanges)
 select  fc.FlowKey,fc.[From],'XYP','yd1024',ar.AreaKey,1,'Y',dis.DiscountKey,(fc.StandardPrice * dis.Deduction /100), 'WholeRoam' 
 from FD_FlowBaseInfo fc,FD_Areas ar,FD_Discounts dis 
 where ar.Name  like '%广东%' and dis.Deduction = 72 and fc.Name like  '%移动.广东漫游.1G%' and fc.[From] = 'CM'  
  
   insert into FD_FlowCode(FlowKey,[From],Carrier,ProductCode,Area,[Priority],Status,DiscountKey,PurchasePrice,FromRanges)
 select  fc.FlowKey,fc.[From],'XYP','yd2048',ar.AreaKey,1,'Y',dis.DiscountKey,(fc.StandardPrice * dis.Deduction /100), 'WholeRoam' 
 from FD_FlowBaseInfo fc,FD_Areas ar,FD_Discounts dis 
 where ar.Name  like '%安徽%' and dis.Deduction = 59 and fc.Name like '%移动.安徽漫游.2G%' and fc.[From] = 'CM' 


 insert into FD_FlowCode(FlowKey,[From],Carrier,ProductCode,Area,[Priority],Status,DiscountKey,PurchasePrice,FromRanges)
 select  fc.FlowKey,fc.[From],'XYP','yd2048',ar.AreaKey,1,'Y',dis.DiscountKey,(fc.StandardPrice * dis.Deduction /100), 'WholeRoam' 
 from FD_FlowBaseInfo fc,FD_Areas ar,FD_Discounts dis 
 where ar.Name  like '%山西%' and dis.Deduction = 53 and fc.Name like  '%移动.山西漫游.2G%' and fc.[From] = 'CM' 

  insert into FD_FlowCode(FlowKey,[From],Carrier,ProductCode,Area,[Priority],Status,DiscountKey,PurchasePrice,FromRanges)
 select  fc.FlowKey,fc.[From],'XYP','yd2048',ar.AreaKey,1,'Y',dis.DiscountKey,(fc.StandardPrice * dis.Deduction /100), 'WholeRoam' 
 from FD_FlowBaseInfo fc,FD_Areas ar,FD_Discounts dis 
 where ar.Name  like '%浙江%' and dis.Deduction = 66 and fc.Name like  '%移动.浙江漫游.2G%' and fc.[From] = 'CM' 


   insert into FD_FlowCode(FlowKey,[From],Carrier,ProductCode,Area,[Priority],Status,DiscountKey,PurchasePrice,FromRanges)
 select  fc.FlowKey,fc.[From],'XYP','yd2048',ar.AreaKey,1,'Y',dis.DiscountKey,(fc.StandardPrice * dis.Deduction /100), 'WholeRoam' 
 from FD_FlowBaseInfo fc,FD_Areas ar,FD_Discounts dis 
 where ar.Name  like '%海南%' and dis.Deduction = 69 and fc.Name like  '%移动.海南漫游.2G%' and fc.[From] = 'CM' 


   insert into FD_FlowCode(FlowKey,[From],Carrier,ProductCode,Area,[Priority],Status,DiscountKey,PurchasePrice,FromRanges)
 select  fc.FlowKey,fc.[From],'XYP','yd2048',ar.AreaKey,1,'Y',dis.DiscountKey,(fc.StandardPrice * dis.Deduction /100), 'WholeRoam' 
 from FD_FlowBaseInfo fc,FD_Areas ar,FD_Discounts dis 
 where ar.Name  like '%福建%' and dis.Deduction = 56 and fc.Name like  '%移动.福建漫游.2G%' and fc.[From] = 'CM' 


   insert into FD_FlowCode(FlowKey,[From],Carrier,ProductCode,Area,[Priority],Status,DiscountKey,PurchasePrice,FromRanges)
 select  fc.FlowKey,fc.[From],'XYP','yd2048',ar.AreaKey,1,'Y',dis.DiscountKey,(fc.StandardPrice * dis.Deduction /100), 'WholeRoam' 
 from FD_FlowBaseInfo fc,FD_Areas ar,FD_Discounts dis 
 where ar.Name  like '%贵州%' and dis.Deduction = 70 and fc.Name like  '%移动.贵州漫游.2G%' and fc.[From] = 'CM' 

   insert into FD_FlowCode(FlowKey,[From],Carrier,ProductCode,Area,[Priority],Status,DiscountKey,PurchasePrice,FromRanges)
 select  fc.FlowKey,fc.[From],'XYP','yd2048',ar.AreaKey,1,'Y',dis.DiscountKey,(fc.StandardPrice * dis.Deduction /100), 'WholeRoam' 
 from FD_FlowBaseInfo fc,FD_Areas ar,FD_Discounts dis 
 where ar.Name  like '%山东%' and dis.Deduction = 63 and fc.Name like  '%移动.山东漫游.2G%' and fc.[From] = 'CM' 


  insert into FD_FlowCode(FlowKey,[From],Carrier,ProductCode,Area,[Priority],Status,DiscountKey,PurchasePrice,FromRanges)
 select  fc.FlowKey,fc.[From],'XYP','yd2048',ar.AreaKey,1,'Y',dis.DiscountKey,(fc.StandardPrice * dis.Deduction /100), 'WholeRoam' 
 from FD_FlowBaseInfo fc,FD_Areas ar,FD_Discounts dis 
 where ar.Name  like '%内蒙古%' and dis.Deduction = 78 and fc.Name like  '%移动.内蒙古漫游.2G%' and fc.[From] = 'CM' 

 insert into FD_FlowCode(FlowKey,[From],Carrier,ProductCode,Area,[Priority],Status,DiscountKey,PurchasePrice,FromRanges)
 select  fc.FlowKey,fc.[From],'XYP','yd2048',ar.AreaKey,1,'Y',dis.DiscountKey,(fc.StandardPrice * dis.Deduction /100), 'WholeRoam' 
 from FD_FlowBaseInfo fc,FD_Areas ar,FD_Discounts dis 
 where ar.Name  like '%天津%' and dis.Deduction = 74 and fc.Name like  '%移动.天津漫游.2G%' and fc.[From] = 'CM' 


 insert into FD_FlowCode(FlowKey,[From],Carrier,ProductCode,Area,[Priority],Status,DiscountKey,PurchasePrice,FromRanges)
 select  fc.FlowKey,fc.[From],'XYP','yd2048',ar.AreaKey,1,'Y',dis.DiscountKey,(fc.StandardPrice * dis.Deduction /100), 'WholeRoam' 
 from FD_FlowBaseInfo fc,FD_Areas ar,FD_Discounts dis 
 where ar.Name  like '%湖南%' and dis.Deduction = 81 and fc.Name like  '%移动.湖南漫游.2G%' and fc.[From] = 'CM' 


 insert into FD_FlowCode(FlowKey,[From],Carrier,ProductCode,Area,[Priority],Status,DiscountKey,PurchasePrice,FromRanges)
 select  fc.FlowKey,fc.[From],'XYP','yd2048',ar.AreaKey,1,'Y',dis.DiscountKey,(fc.StandardPrice * dis.Deduction /100), 'WholeRoam' 
 from FD_FlowBaseInfo fc,FD_Areas ar,FD_Discounts dis 
 where ar.Name  like '%广东%' and dis.Deduction = 72 and fc.Name like  '%移动.广东漫游.2G%' and fc.[From] = 'CM'  
  
     ---------------------------------------------移动 3G------------------------------------------------------------------------------------

 insert into FD_FlowCode(FlowKey,[From],Carrier,ProductCode,Area,[Priority],Status,DiscountKey,PurchasePrice,FromRanges)
 select  fc.FlowKey,fc.[From],'XYP','yd3072',ar.AreaKey,1,'Y',dis.DiscountKey,(fc.StandardPrice * dis.Deduction /100), 'WholeRoam' 
 from FD_FlowBaseInfo fc,FD_Areas ar,FD_Discounts dis 
 where ar.Name  like '%安徽%' and dis.Deduction = 59 and fc.Name like '%移动.安徽漫游.3G%' and fc.[From] = 'CM' 


 insert into FD_FlowCode(FlowKey,[From],Carrier,ProductCode,Area,[Priority],Status,DiscountKey,PurchasePrice,FromRanges)
 select  fc.FlowKey,fc.[From],'XYP','yd3072',ar.AreaKey,1,'Y',dis.DiscountKey,(fc.StandardPrice * dis.Deduction /100), 'WholeRoam' 
 from FD_FlowBaseInfo fc,FD_Areas ar,FD_Discounts dis 
 where ar.Name  like '%山西%' and dis.Deduction = 53 and fc.Name like  '%移动.山西漫游.3G%' and fc.[From] = 'CM' 

  insert into FD_FlowCode(FlowKey,[From],Carrier,ProductCode,Area,[Priority],Status,DiscountKey,PurchasePrice,FromRanges)
 select  fc.FlowKey,fc.[From],'XYP','yd3072',ar.AreaKey,1,'Y',dis.DiscountKey,(fc.StandardPrice * dis.Deduction /100), 'WholeRoam' 
 from FD_FlowBaseInfo fc,FD_Areas ar,FD_Discounts dis 
 where ar.Name  like '%浙江%' and dis.Deduction = 66 and fc.Name like  '%移动.浙江漫游.3G%' and fc.[From] = 'CM' 


   insert into FD_FlowCode(FlowKey,[From],Carrier,ProductCode,Area,[Priority],Status,DiscountKey,PurchasePrice,FromRanges)
 select  fc.FlowKey,fc.[From],'XYP','yd3072',ar.AreaKey,1,'Y',dis.DiscountKey,(fc.StandardPrice * dis.Deduction /100), 'WholeRoam' 
 from FD_FlowBaseInfo fc,FD_Areas ar,FD_Discounts dis 
 where ar.Name  like '%海南%' and dis.Deduction = 69 and fc.Name like  '%移动.海南漫游.3G%' and fc.[From] = 'CM' 


   insert into FD_FlowCode(FlowKey,[From],Carrier,ProductCode,Area,[Priority],Status,DiscountKey,PurchasePrice,FromRanges)
 select  fc.FlowKey,fc.[From],'XYP','yd3072',ar.AreaKey,1,'Y',dis.DiscountKey,(fc.StandardPrice * dis.Deduction /100), 'WholeRoam' 
 from FD_FlowBaseInfo fc,FD_Areas ar,FD_Discounts dis 
 where ar.Name  like '%福建%' and dis.Deduction = 56 and fc.Name like  '%移动.福建漫游.3G%' and fc.[From] = 'CM' 


   insert into FD_FlowCode(FlowKey,[From],Carrier,ProductCode,Area,[Priority],Status,DiscountKey,PurchasePrice,FromRanges)
 select  fc.FlowKey,fc.[From],'XYP','yd3072',ar.AreaKey,1,'Y',dis.DiscountKey,(fc.StandardPrice * dis.Deduction /100), 'WholeRoam' 
 from FD_FlowBaseInfo fc,FD_Areas ar,FD_Discounts dis 
 where ar.Name  like '%贵州%' and dis.Deduction = 70 and fc.Name like  '%移动.贵州漫游.3G%' and fc.[From] = 'CM' 

   insert into FD_FlowCode(FlowKey,[From],Carrier,ProductCode,Area,[Priority],Status,DiscountKey,PurchasePrice,FromRanges)
 select  fc.FlowKey,fc.[From],'XYP','yd3072',ar.AreaKey,1,'Y',dis.DiscountKey,(fc.StandardPrice * dis.Deduction /100), 'WholeRoam' 
 from FD_FlowBaseInfo fc,FD_Areas ar,FD_Discounts dis 
 where ar.Name  like '%山东%' and dis.Deduction = 63 and fc.Name like  '%移动.山东漫游.3G%' and fc.[From] = 'CM' 


  insert into FD_FlowCode(FlowKey,[From],Carrier,ProductCode,Area,[Priority],Status,DiscountKey,PurchasePrice,FromRanges)
 select  fc.FlowKey,fc.[From],'XYP','yd3072',ar.AreaKey,1,'Y',dis.DiscountKey,(fc.StandardPrice * dis.Deduction /100), 'WholeRoam' 
 from FD_FlowBaseInfo fc,FD_Areas ar,FD_Discounts dis 
 where ar.Name  like '%内蒙古%' and dis.Deduction = 78 and fc.Name like  '%移动.内蒙古漫游.3G%' and fc.[From] = 'CM' 

 insert into FD_FlowCode(FlowKey,[From],Carrier,ProductCode,Area,[Priority],Status,DiscountKey,PurchasePrice,FromRanges)
 select  fc.FlowKey,fc.[From],'XYP','yd3072',ar.AreaKey,1,'Y',dis.DiscountKey,(fc.StandardPrice * dis.Deduction /100), 'WholeRoam' 
 from FD_FlowBaseInfo fc,FD_Areas ar,FD_Discounts dis 
 where ar.Name  like '%天津%' and dis.Deduction = 74 and fc.Name like  '%移动.天津漫游.3G%' and fc.[From] = 'CM' 


 insert into FD_FlowCode(FlowKey,[From],Carrier,ProductCode,Area,[Priority],Status,DiscountKey,PurchasePrice,FromRanges)
 select  fc.FlowKey,fc.[From],'XYP','yd3072',ar.AreaKey,1,'Y',dis.DiscountKey,(fc.StandardPrice * dis.Deduction /100), 'WholeRoam' 
 from FD_FlowBaseInfo fc,FD_Areas ar,FD_Discounts dis 
 where ar.Name  like '%湖南%' and dis.Deduction = 81 and fc.Name like  '%移动.湖南漫游.3G%' and fc.[From] = 'CM' 


 insert into FD_FlowCode(FlowKey,[From],Carrier,ProductCode,Area,[Priority],Status,DiscountKey,PurchasePrice,FromRanges)
 select  fc.FlowKey,fc.[From],'XYP','yd3072',ar.AreaKey,1,'Y',dis.DiscountKey,(fc.StandardPrice * dis.Deduction /100), 'WholeRoam' 
 from FD_FlowBaseInfo fc,FD_Areas ar,FD_Discounts dis 
 where ar.Name  like '%广东%' and dis.Deduction = 72 and fc.Name like  '%移动.广东漫游.3G%' and fc.[From] = 'CM'  
  

    ---------------------------------------------移动 4G------------------------------------------------------------------------------------

 insert into FD_FlowCode(FlowKey,[From],Carrier,ProductCode,Area,[Priority],Status,DiscountKey,PurchasePrice,FromRanges)
 select  fc.FlowKey,fc.[From],'XYP','yd4096',ar.AreaKey,1,'Y',dis.DiscountKey,(fc.StandardPrice * dis.Deduction /100), 'WholeRoam' 
 from FD_FlowBaseInfo fc,FD_Areas ar,FD_Discounts dis 
 where ar.Name  like '%安徽%' and dis.Deduction = 59 and fc.Name like '%移动.安徽漫游.4G%' and fc.[From] = 'CM' 


 insert into FD_FlowCode(FlowKey,[From],Carrier,ProductCode,Area,[Priority],Status,DiscountKey,PurchasePrice,FromRanges)
 select  fc.FlowKey,fc.[From],'XYP','yd4096',ar.AreaKey,1,'Y',dis.DiscountKey,(fc.StandardPrice * dis.Deduction /100), 'WholeRoam' 
 from FD_FlowBaseInfo fc,FD_Areas ar,FD_Discounts dis 
 where ar.Name  like '%山西%' and dis.Deduction = 53 and fc.Name like  '%移动.山西漫游.4G%' and fc.[From] = 'CM' 

  insert into FD_FlowCode(FlowKey,[From],Carrier,ProductCode,Area,[Priority],Status,DiscountKey,PurchasePrice,FromRanges)
 select  fc.FlowKey,fc.[From],'XYP','yd4096',ar.AreaKey,1,'Y',dis.DiscountKey,(fc.StandardPrice * dis.Deduction /100), 'WholeRoam' 
 from FD_FlowBaseInfo fc,FD_Areas ar,FD_Discounts dis 
 where ar.Name  like '%浙江%' and dis.Deduction = 66 and fc.Name like  '%移动.浙江漫游.4G%' and fc.[From] = 'CM' 


   insert into FD_FlowCode(FlowKey,[From],Carrier,ProductCode,Area,[Priority],Status,DiscountKey,PurchasePrice,FromRanges)
 select  fc.FlowKey,fc.[From],'XYP','yd4096',ar.AreaKey,1,'Y',dis.DiscountKey,(fc.StandardPrice * dis.Deduction /100), 'WholeRoam' 
 from FD_FlowBaseInfo fc,FD_Areas ar,FD_Discounts dis 
 where ar.Name  like '%海南%' and dis.Deduction = 69 and fc.Name like  '%移动.海南漫游.4G%' and fc.[From] = 'CM' 


   insert into FD_FlowCode(FlowKey,[From],Carrier,ProductCode,Area,[Priority],Status,DiscountKey,PurchasePrice,FromRanges)
 select  fc.FlowKey,fc.[From],'XYP','yd4096',ar.AreaKey,1,'Y',dis.DiscountKey,(fc.StandardPrice * dis.Deduction /100), 'WholeRoam' 
 from FD_FlowBaseInfo fc,FD_Areas ar,FD_Discounts dis 
 where ar.Name  like '%福建%' and dis.Deduction = 56 and fc.Name like  '%移动.福建漫游.4G%' and fc.[From] = 'CM' 


   insert into FD_FlowCode(FlowKey,[From],Carrier,ProductCode,Area,[Priority],Status,DiscountKey,PurchasePrice,FromRanges)
 select  fc.FlowKey,fc.[From],'XYP','yd4096',ar.AreaKey,1,'Y',dis.DiscountKey,(fc.StandardPrice * dis.Deduction /100), 'WholeRoam' 
 from FD_FlowBaseInfo fc,FD_Areas ar,FD_Discounts dis 
 where ar.Name  like '%贵州%' and dis.Deduction = 70 and fc.Name like  '%移动.贵州漫游.4G%' and fc.[From] = 'CM' 

   insert into FD_FlowCode(FlowKey,[From],Carrier,ProductCode,Area,[Priority],Status,DiscountKey,PurchasePrice,FromRanges)
 select  fc.FlowKey,fc.[From],'XYP','yd4096',ar.AreaKey,1,'Y',dis.DiscountKey,(fc.StandardPrice * dis.Deduction /100), 'WholeRoam' 
 from FD_FlowBaseInfo fc,FD_Areas ar,FD_Discounts dis 
 where ar.Name  like '%山东%' and dis.Deduction = 63 and fc.Name like  '%移动.山东漫游.4G%' and fc.[From] = 'CM' 


  insert into FD_FlowCode(FlowKey,[From],Carrier,ProductCode,Area,[Priority],Status,DiscountKey,PurchasePrice,FromRanges)
 select  fc.FlowKey,fc.[From],'XYP','yd4096',ar.AreaKey,1,'Y',dis.DiscountKey,(fc.StandardPrice * dis.Deduction /100), 'WholeRoam' 
 from FD_FlowBaseInfo fc,FD_Areas ar,FD_Discounts dis 
 where ar.Name  like '%内蒙古%' and dis.Deduction = 78 and fc.Name like  '%移动.内蒙古漫游.4G%' and fc.[From] = 'CM' 

 insert into FD_FlowCode(FlowKey,[From],Carrier,ProductCode,Area,[Priority],Status,DiscountKey,PurchasePrice,FromRanges)
 select  fc.FlowKey,fc.[From],'XYP','yd4096',ar.AreaKey,1,'Y',dis.DiscountKey,(fc.StandardPrice * dis.Deduction /100), 'WholeRoam' 
 from FD_FlowBaseInfo fc,FD_Areas ar,FD_Discounts dis 
 where ar.Name  like '%天津%' and dis.Deduction = 74 and fc.Name like  '%移动.天津漫游.4G%' and fc.[From] = 'CM' 


 insert into FD_FlowCode(FlowKey,[From],Carrier,ProductCode,Area,[Priority],Status,DiscountKey,PurchasePrice,FromRanges)
 select  fc.FlowKey,fc.[From],'XYP','yd4096',ar.AreaKey,1,'Y',dis.DiscountKey,(fc.StandardPrice * dis.Deduction /100), 'WholeRoam' 
 from FD_FlowBaseInfo fc,FD_Areas ar,FD_Discounts dis 
 where ar.Name  like '%湖南%' and dis.Deduction = 81 and fc.Name like  '%移动.湖南漫游.4G%' and fc.[From] = 'CM' 


 insert into FD_FlowCode(FlowKey,[From],Carrier,ProductCode,Area,[Priority],Status,DiscountKey,PurchasePrice,FromRanges)
 select  fc.FlowKey,fc.[From],'XYP','yd4096',ar.AreaKey,1,'Y',dis.DiscountKey,(fc.StandardPrice * dis.Deduction /100), 'WholeRoam' 
 from FD_FlowBaseInfo fc,FD_Areas ar,FD_Discounts dis 
 where ar.Name  like '%广东%' and dis.Deduction = 72 and fc.Name like  '%移动.广东漫游.4G%' and fc.[From] = 'CM'  


   ---------------------------------------------移动 6G------------------------------------------------------------------------------------

 insert into FD_FlowCode(FlowKey,[From],Carrier,ProductCode,Area,[Priority],Status,DiscountKey,PurchasePrice,FromRanges)
 select  fc.FlowKey,fc.[From],'XYP','yd6144',ar.AreaKey,1,'Y',dis.DiscountKey,(fc.StandardPrice * dis.Deduction /100), 'WholeRoam' 
 from FD_FlowBaseInfo fc,FD_Areas ar,FD_Discounts dis 
 where ar.Name  like '%安徽%' and dis.Deduction = 59 and fc.Name like '%移动.安徽漫游.6G%' and fc.[From] = 'CM' 


 insert into FD_FlowCode(FlowKey,[From],Carrier,ProductCode,Area,[Priority],Status,DiscountKey,PurchasePrice,FromRanges)
 select  fc.FlowKey,fc.[From],'XYP','yd6144',ar.AreaKey,1,'Y',dis.DiscountKey,(fc.StandardPrice * dis.Deduction /100), 'WholeRoam' 
 from FD_FlowBaseInfo fc,FD_Areas ar,FD_Discounts dis 
 where ar.Name  like '%山西%' and dis.Deduction = 53 and fc.Name like  '%移动.山西漫游.6G%' and fc.[From] = 'CM' 

  insert into FD_FlowCode(FlowKey,[From],Carrier,ProductCode,Area,[Priority],Status,DiscountKey,PurchasePrice,FromRanges)
 select  fc.FlowKey,fc.[From],'XYP','yd6144',ar.AreaKey,1,'Y',dis.DiscountKey,(fc.StandardPrice * dis.Deduction /100), 'WholeRoam' 
 from FD_FlowBaseInfo fc,FD_Areas ar,FD_Discounts dis 
 where ar.Name  like '%浙江%' and dis.Deduction = 66 and fc.Name like  '%移动.浙江漫游.6G%' and fc.[From] = 'CM' 


   insert into FD_FlowCode(FlowKey,[From],Carrier,ProductCode,Area,[Priority],Status,DiscountKey,PurchasePrice,FromRanges)
 select  fc.FlowKey,fc.[From],'XYP','yd6144',ar.AreaKey,1,'Y',dis.DiscountKey,(fc.StandardPrice * dis.Deduction /100), 'WholeRoam' 
 from FD_FlowBaseInfo fc,FD_Areas ar,FD_Discounts dis 
 where ar.Name  like '%海南%' and dis.Deduction = 69 and fc.Name like  '%移动.海南漫游.6G%' and fc.[From] = 'CM' 


   insert into FD_FlowCode(FlowKey,[From],Carrier,ProductCode,Area,[Priority],Status,DiscountKey,PurchasePrice,FromRanges)
 select  fc.FlowKey,fc.[From],'XYP','yd6144',ar.AreaKey,1,'Y',dis.DiscountKey,(fc.StandardPrice * dis.Deduction /100), 'WholeRoam' 
 from FD_FlowBaseInfo fc,FD_Areas ar,FD_Discounts dis 
 where ar.Name  like '%福建%' and dis.Deduction = 56 and fc.Name like  '%移动.福建漫游.6G%' and fc.[From] = 'CM' 


   insert into FD_FlowCode(FlowKey,[From],Carrier,ProductCode,Area,[Priority],Status,DiscountKey,PurchasePrice,FromRanges)
 select  fc.FlowKey,fc.[From],'XYP','yd6144',ar.AreaKey,1,'Y',dis.DiscountKey,(fc.StandardPrice * dis.Deduction /100), 'WholeRoam' 
 from FD_FlowBaseInfo fc,FD_Areas ar,FD_Discounts dis 
 where ar.Name  like '%贵州%' and dis.Deduction = 70 and fc.Name like  '%移动.贵州漫游.6G%' and fc.[From] = 'CM' 

   insert into FD_FlowCode(FlowKey,[From],Carrier,ProductCode,Area,[Priority],Status,DiscountKey,PurchasePrice,FromRanges)
 select  fc.FlowKey,fc.[From],'XYP','yd6144',ar.AreaKey,1,'Y',dis.DiscountKey,(fc.StandardPrice * dis.Deduction /100), 'WholeRoam' 
 from FD_FlowBaseInfo fc,FD_Areas ar,FD_Discounts dis 
 where ar.Name  like '%山东%' and dis.Deduction = 63 and fc.Name like  '%移动.山东漫游.6G%' and fc.[From] = 'CM' 


  insert into FD_FlowCode(FlowKey,[From],Carrier,ProductCode,Area,[Priority],Status,DiscountKey,PurchasePrice,FromRanges)
 select  fc.FlowKey,fc.[From],'XYP','yd6144',ar.AreaKey,1,'Y',dis.DiscountKey,(fc.StandardPrice * dis.Deduction /100), 'WholeRoam' 
 from FD_FlowBaseInfo fc,FD_Areas ar,FD_Discounts dis 
 where ar.Name  like '%内蒙古%' and dis.Deduction = 78 and fc.Name like  '%移动.内蒙古漫游.6G%' and fc.[From] = 'CM' 

 insert into FD_FlowCode(FlowKey,[From],Carrier,ProductCode,Area,[Priority],Status,DiscountKey,PurchasePrice,FromRanges)
 select  fc.FlowKey,fc.[From],'XYP','yd6144',ar.AreaKey,1,'Y',dis.DiscountKey,(fc.StandardPrice * dis.Deduction /100), 'WholeRoam' 
 from FD_FlowBaseInfo fc,FD_Areas ar,FD_Discounts dis 
 where ar.Name  like '%天津%' and dis.Deduction = 74 and fc.Name like  '%移动.天津漫游.6G%' and fc.[From] = 'CM' 


 insert into FD_FlowCode(FlowKey,[From],Carrier,ProductCode,Area,[Priority],Status,DiscountKey,PurchasePrice,FromRanges)
 select  fc.FlowKey,fc.[From],'XYP','yd6144',ar.AreaKey,1,'Y',dis.DiscountKey,(fc.StandardPrice * dis.Deduction /100), 'WholeRoam' 
 from FD_FlowBaseInfo fc,FD_Areas ar,FD_Discounts dis 
 where ar.Name  like '%湖南%' and dis.Deduction = 81 and fc.Name like  '%移动.湖南漫游.6G%' and fc.[From] = 'CM' 


 insert into FD_FlowCode(FlowKey,[From],Carrier,ProductCode,Area,[Priority],Status,DiscountKey,PurchasePrice,FromRanges)
 select  fc.FlowKey,fc.[From],'XYP','yd6144',ar.AreaKey,1,'Y',dis.DiscountKey,(fc.StandardPrice * dis.Deduction /100), 'WholeRoam' 
 from FD_FlowBaseInfo fc,FD_Areas ar,FD_Discounts dis 
 where ar.Name  like '%广东%' and dis.Deduction = 72 and fc.Name like  '%移动.广东漫游.6G%' and fc.[From] = 'CM'  
 ---------------------------------------联通 本地 --------------------------------------------------------------------------------
 
 insert into FD_FlowCode(FlowKey,[From],Carrier,ProductCode,Area,[Priority],Status,DiscountKey,PurchasePrice,FromRanges)
 select  fc.FlowKey,fc.[From],'CU023','xGS031','023',1,'Y',dis.DiscountKey,(fc.StandardPrice * dis.Deduction /100), 'Province' 
 from FD_FlowBaseInfo fc,FD_Areas ar,FD_Discounts dis 
 where  ar.AreaKey = '023' and  dis.Deduction = 95 and fc.Name like  '%联通.重庆.20M%' and fc.[From] = 'CU' 

   insert into FD_FlowCode(FlowKey,[From],Carrier,ProductCode,Area,[Priority],Status,DiscountKey,PurchasePrice,FromRanges)
 select  fc.FlowKey,fc.[From],'CU023','xGS032','023',1,'Y',dis.DiscountKey,(fc.StandardPrice * dis.Deduction /100), 'Province' 
 from FD_FlowBaseInfo fc,FD_Areas ar,FD_Discounts dis 
 where  ar.AreaKey = '023' and  dis.Deduction = 95 and fc.Name like  '%联通.重庆.50M%' and fc.[From] = 'CU' 

  insert into FD_FlowCode(FlowKey,[From],Carrier,ProductCode,Area,[Priority],Status,DiscountKey,PurchasePrice,FromRanges)
 select  fc.FlowKey,fc.[From],'CU023','xGS034','023',1,'Y',dis.DiscountKey,(fc.StandardPrice * dis.Deduction /100), 'Province' 
 from FD_FlowBaseInfo fc,FD_Areas ar,FD_Discounts dis 
 where  ar.AreaKey = '023' and  dis.Deduction = 95 and fc.Name like  '%联通.重庆.100M%' and fc.[From] = 'CU' 

 insert into FD_FlowCode(FlowKey,[From],Carrier,ProductCode,Area,[Priority],Status,DiscountKey,PurchasePrice,FromRanges)
 select  fc.FlowKey,fc.[From],'CU023','xGS035','023',1,'Y',dis.DiscountKey,(fc.StandardPrice * dis.Deduction /100), 'Province' 
 from FD_FlowBaseInfo fc,FD_Areas ar,FD_Discounts dis 
 where ar.AreaKey = '023' and  dis.Deduction = 95 and fc.Name like  '%联通.重庆.200M%' and fc.[From] = 'CU' 


 insert into FD_FlowCode(FlowKey,[From],Carrier,ProductCode,Area,[Priority],Status,DiscountKey,PurchasePrice,FromRanges)
 select  fc.FlowKey,fc.[From],'CU023','xGS037','023',1,'Y',dis.DiscountKey,(fc.StandardPrice * dis.Deduction /100), 'Province' 
 from FD_FlowBaseInfo fc,FD_Areas ar,FD_Discounts dis 
 where ar.AreaKey = '023' and   dis.Deduction = 95 and fc.Name like  '%联通.重庆.500M%' and fc.[From] = 'CU' 


 insert into FD_FlowCode(FlowKey,[From],Carrier,ProductCode,Area,[Priority],Status,DiscountKey,PurchasePrice,FromRanges)
 select  fc.FlowKey,fc.[From],'CU023','xGS038','023',1,'Y',dis.DiscountKey,(fc.StandardPrice * dis.Deduction /100), 'Province' 
 from FD_FlowBaseInfo fc,FD_Areas ar,FD_Discounts dis 
 where ar.AreaKey = '023' and   dis.Deduction = 95 and fc.Name like  '%联通.重庆.1G%' and fc.[From] = 'CU'  

  ---------------------------------------------湖北 -----------------------------------------------------------------------------------

 insert into FD_FlowCode(FlowKey,[From],Carrier,ProductCode,Area,[Priority],Status,DiscountKey,PurchasePrice,FromRanges)
 select  fc.FlowKey,fc.[From],'XYP','yd10',ar.AreaKey,1,'Y',dis.DiscountKey,(fc.StandardPrice * dis.Deduction /100), 'WholeRoam' 
 from FD_FlowBaseInfo fc,FD_Areas ar,FD_Discounts dis 
 where ar.Name  like '%湖北%' and dis.Deduction =  69 and fc.Name like '%移动.湖北漫游.10M%' and fc.[From] = 'CM' 


 insert into FD_FlowCode(FlowKey,[From],Carrier,ProductCode,Area,[Priority],Status,DiscountKey,PurchasePrice,FromRanges)
 select  fc.FlowKey,fc.[From],'XYP','yd30',ar.AreaKey,1,'Y',dis.DiscountKey,(fc.StandardPrice * dis.Deduction /100), 'WholeRoam' 
 from FD_FlowBaseInfo fc,FD_Areas ar,FD_Discounts dis 
 where ar.Name  like '%湖北%' and dis.Deduction =  69 and fc.Name like  '%移动.湖北漫游.30M%' and fc.[From] = 'CM' 

  insert into FD_FlowCode(FlowKey,[From],Carrier,ProductCode,Area,[Priority],Status,DiscountKey,PurchasePrice,FromRanges)
 select  fc.FlowKey,fc.[From],'XYP','yd70',ar.AreaKey,1,'Y',dis.DiscountKey,(fc.StandardPrice * dis.Deduction /100), 'WholeRoam' 
 from FD_FlowBaseInfo fc,FD_Areas ar,FD_Discounts dis 
 where ar.Name  like '%湖北%' and dis.Deduction =  69 and fc.Name like  '%移动.湖北漫游.70M%' and fc.[From] = 'CM' 


   insert into FD_FlowCode(FlowKey,[From],Carrier,ProductCode,Area,[Priority],Status,DiscountKey,PurchasePrice,FromRanges)
 select  fc.FlowKey,fc.[From],'XYP','yd150',ar.AreaKey,1,'Y',dis.DiscountKey,(fc.StandardPrice * dis.Deduction /100), 'WholeRoam' 
 from FD_FlowBaseInfo fc,FD_Areas ar,FD_Discounts dis 
 where ar.Name  like '%湖北%' and dis.Deduction =  69 and fc.Name like  '%移动.湖北漫游.150M%' and fc.[From] = 'CM' 


   insert into FD_FlowCode(FlowKey,[From],Carrier,ProductCode,Area,[Priority],Status,DiscountKey,PurchasePrice,FromRanges)
 select  fc.FlowKey,fc.[From],'XYP','yd500',ar.AreaKey,1,'Y',dis.DiscountKey,(fc.StandardPrice * dis.Deduction /100), 'WholeRoam' 
 from FD_FlowBaseInfo fc,FD_Areas ar,FD_Discounts dis 
 where ar.Name  like '%湖北%' and dis.Deduction =  69 and fc.Name like  '%移动.湖北漫游.500M%' and fc.[From] = 'CM' 


   insert into FD_FlowCode(FlowKey,[From],Carrier,ProductCode,Area,[Priority],Status,DiscountKey,PurchasePrice,FromRanges)
 select  fc.FlowKey,fc.[From],'XYP','yd1024',ar.AreaKey,1,'Y',dis.DiscountKey,(fc.StandardPrice * dis.Deduction /100), 'WholeRoam' 
 from FD_FlowBaseInfo fc,FD_Areas ar,FD_Discounts dis 
 where ar.Name  like '%湖北%' and dis.Deduction =  69 and fc.Name like  '%移动.湖北漫游.1G%' and fc.[From] = 'CM' 

   insert into FD_FlowCode(FlowKey,[From],Carrier,ProductCode,Area,[Priority],Status,DiscountKey,PurchasePrice,FromRanges)
 select  fc.FlowKey,fc.[From],'XYP','yd2048',ar.AreaKey,1,'Y',dis.DiscountKey,(fc.StandardPrice * dis.Deduction /100), 'WholeRoam' 
 from FD_FlowBaseInfo fc,FD_Areas ar,FD_Discounts dis 
 where ar.Name  like '%湖北%' and dis.Deduction =  69 and fc.Name like  '%移动.湖北漫游.2G%' and fc.[From] = 'CM' 


  insert into FD_FlowCode(FlowKey,[From],Carrier,ProductCode,Area,[Priority],Status,DiscountKey,PurchasePrice,FromRanges)
 select  fc.FlowKey,fc.[From],'XYP','yd3072',ar.AreaKey,1,'Y',dis.DiscountKey,(fc.StandardPrice * dis.Deduction /100), 'WholeRoam' 
 from FD_FlowBaseInfo fc,FD_Areas ar,FD_Discounts dis 
 where ar.Name  like '%湖北%' and dis.Deduction =  69 and fc.Name like  '%移动.湖北漫游.3G%' and fc.[From] = 'CM' 

 insert into FD_FlowCode(FlowKey,[From],Carrier,ProductCode,Area,[Priority],Status,DiscountKey,PurchasePrice,FromRanges)
 select  fc.FlowKey,fc.[From],'XYP','yd4096',ar.AreaKey,1,'Y',dis.DiscountKey,(fc.StandardPrice * dis.Deduction /100), 'WholeRoam' 
 from FD_FlowBaseInfo fc,FD_Areas ar,FD_Discounts dis 
 where ar.Name  like '%湖北%' and dis.Deduction =  69 and fc.Name like  '%移动.湖北漫游.4G%' and fc.[From] = 'CM' 


 insert into FD_FlowCode(FlowKey,[From],Carrier,ProductCode,Area,[Priority],Status,DiscountKey,PurchasePrice,FromRanges)
 select  fc.FlowKey,fc.[From],'XYP','yd6144',ar.AreaKey,1,'Y',dis.DiscountKey,(fc.StandardPrice * dis.Deduction /100), 'WholeRoam' 
 from FD_FlowBaseInfo fc,FD_Areas ar,FD_Discounts dis 
 where ar.Name  like '%湖北%' and dis.Deduction = 69 and fc.Name like  '%移动.湖北漫游.6G%' and fc.[From] = 'CM' 



  ---------------------------------------------四川-----------------------------------------------------------------------------------

 insert into FD_FlowCode(FlowKey,[From],Carrier,ProductCode,Area,[Priority],Status,DiscountKey,PurchasePrice,FromRanges)
 select  fc.FlowKey,fc.[From],'XYP','yd10',ar.AreaKey,1,'Y',dis.DiscountKey,(fc.StandardPrice * dis.Deduction /100), 'WholeRoam' 
 from FD_FlowBaseInfo fc,FD_Areas ar,FD_Discounts dis 
 where ar.Name  like '%四川%' and dis.Deduction =  66 and fc.Name like '%移动.四川漫游.10M%' and fc.[From] = 'CM' 


 insert into FD_FlowCode(FlowKey,[From],Carrier,ProductCode,Area,[Priority],Status,DiscountKey,PurchasePrice,FromRanges)
 select  fc.FlowKey,fc.[From],'XYP','yd30',ar.AreaKey,1,'Y',dis.DiscountKey,(fc.StandardPrice * dis.Deduction /100), 'WholeRoam' 
 from FD_FlowBaseInfo fc,FD_Areas ar,FD_Discounts dis 
 where ar.Name  like '%四川%' and dis.Deduction =  66 and fc.Name like  '%移动.四川漫游.30M%' and fc.[From] = 'CM' 

  insert into FD_FlowCode(FlowKey,[From],Carrier,ProductCode,Area,[Priority],Status,DiscountKey,PurchasePrice,FromRanges)
 select  fc.FlowKey,fc.[From],'XYP','yd70',ar.AreaKey,1,'Y',dis.DiscountKey,(fc.StandardPrice * dis.Deduction /100), 'WholeRoam' 
 from FD_FlowBaseInfo fc,FD_Areas ar,FD_Discounts dis 
 where ar.Name  like '%四川%' and dis.Deduction =  66 and fc.Name like  '%移动.四川漫游.70M%' and fc.[From] = 'CM' 


   insert into FD_FlowCode(FlowKey,[From],Carrier,ProductCode,Area,[Priority],Status,DiscountKey,PurchasePrice,FromRanges)
 select  fc.FlowKey,fc.[From],'XYP','yd150',ar.AreaKey,1,'Y',dis.DiscountKey,(fc.StandardPrice * dis.Deduction /100), 'WholeRoam' 
 from FD_FlowBaseInfo fc,FD_Areas ar,FD_Discounts dis 
 where ar.Name  like '%四川%' and dis.Deduction =  66 and fc.Name like  '%移动.四川漫游.150M%' and fc.[From] = 'CM' 


   insert into FD_FlowCode(FlowKey,[From],Carrier,ProductCode,Area,[Priority],Status,DiscountKey,PurchasePrice,FromRanges)
 select  fc.FlowKey,fc.[From],'XYP','yd500',ar.AreaKey,1,'Y',dis.DiscountKey,(fc.StandardPrice * dis.Deduction /100), 'WholeRoam' 
 from FD_FlowBaseInfo fc,FD_Areas ar,FD_Discounts dis 
 where ar.Name  like '%四川%' and dis.Deduction =  66 and fc.Name like  '%移动.四川漫游.500M%' and fc.[From] = 'CM' 


   insert into FD_FlowCode(FlowKey,[From],Carrier,ProductCode,Area,[Priority],Status,DiscountKey,PurchasePrice,FromRanges)
 select  fc.FlowKey,fc.[From],'XYP','yd1024',ar.AreaKey,1,'Y',dis.DiscountKey,(fc.StandardPrice * dis.Deduction /100), 'WholeRoam' 
 from FD_FlowBaseInfo fc,FD_Areas ar,FD_Discounts dis 
 where ar.Name  like '%四川%' and dis.Deduction =  66 and fc.Name like  '%移动.四川漫游.1G%' and fc.[From] = 'CM' 

   insert into FD_FlowCode(FlowKey,[From],Carrier,ProductCode,Area,[Priority],Status,DiscountKey,PurchasePrice,FromRanges)
 select  fc.FlowKey,fc.[From],'XYP','yd2048',ar.AreaKey,1,'Y',dis.DiscountKey,(fc.StandardPrice * dis.Deduction /100), 'WholeRoam' 
 from FD_FlowBaseInfo fc,FD_Areas ar,FD_Discounts dis 
 where ar.Name  like '%四川%' and dis.Deduction =  66 and fc.Name like  '%移动.四川漫游.2G%' and fc.[From] = 'CM' 


  insert into FD_FlowCode(FlowKey,[From],Carrier,ProductCode,Area,[Priority],Status,DiscountKey,PurchasePrice,FromRanges)
 select  fc.FlowKey,fc.[From],'XYP','yd3072',ar.AreaKey,1,'Y',dis.DiscountKey,(fc.StandardPrice * dis.Deduction /100), 'WholeRoam' 
 from FD_FlowBaseInfo fc,FD_Areas ar,FD_Discounts dis 
 where ar.Name  like '%四川%' and dis.Deduction =  66 and fc.Name like  '%移动.四川漫游.3G%' and fc.[From] = 'CM' 

 insert into FD_FlowCode(FlowKey,[From],Carrier,ProductCode,Area,[Priority],Status,DiscountKey,PurchasePrice,FromRanges)
 select  fc.FlowKey,fc.[From],'XYP','yd4096',ar.AreaKey,1,'Y',dis.DiscountKey,(fc.StandardPrice * dis.Deduction /100), 'WholeRoam' 
 from FD_FlowBaseInfo fc,FD_Areas ar,FD_Discounts dis 
 where ar.Name  like '%四川%' and dis.Deduction =  66 and fc.Name like  '%移动.四川漫游.4G%' and fc.[From] = 'CM' 


 insert into FD_FlowCode(FlowKey,[From],Carrier,ProductCode,Area,[Priority],Status,DiscountKey,PurchasePrice,FromRanges)
 select  fc.FlowKey,fc.[From],'XYP','yd6144',ar.AreaKey,1,'Y',dis.DiscountKey,(fc.StandardPrice * dis.Deduction /100), 'WholeRoam' 
 from FD_FlowBaseInfo fc,FD_Areas ar,FD_Discounts dis 
 where ar.Name  like '%四川%' and dis.Deduction = 66 and fc.Name like  '%移动.四川漫游.6G%' and fc.[From] = 'CM' 


  
  