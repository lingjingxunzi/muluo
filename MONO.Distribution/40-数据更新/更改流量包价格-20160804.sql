
select * from FD_SystemFlowPackets sfp
left join FD_Discounts dis on dis.DiscountKey = sfp.DiscountKey
 where FlowPacketKey in 
(select FlowKey from FD_FlowBaseInfo where Name like '%����%')


select * from FD_FlowCode fc
left join FD_Discounts dis on dis.DiscountKey = fc.DiscountKey 
where FlowKey in (select FlowKey from FD_FlowBaseInfo where Name like '%����%')
select DiscountKey from FD_Discounts where Deduction = 54
select * from FD_Discounts where DiscountKey = 8
 

update FD_FlowCode set DiscountKey = (select DiscountKey from FD_Discounts where Deduction = 52)
where FlowKey in (select FlowKey from FD_FlowBaseInfo where Name like '%ɽ��%')

select price/0.73,  Price / 0.81 * 0.82
from FD_SystemFlowPackets where FlowPacketKey in (select FlowKey from FD_FlowBaseInfo where Name like '%����%')

update FD_SystemFlowPackets set discountkey= (select DiscountKey from FD_Discounts where Deduction = 65)
,Price = Convert(int,Price / 0.58* 0.65)
where FlowPacketKey in (select FlowKey from FD_FlowBaseInfo where Name like '%����%') and SysUserKey = 7

 select Convert(int,StandardPrice * 0.54)  from FD_FlowBaseInfo where Name like '%����%'
 
 
 