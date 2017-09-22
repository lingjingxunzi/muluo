alter table FD_FlowDistributionRecords add PushTo nvarchar(11)

alter table FD_FlowDistributionRecords add DistributionType nvarchar(20)
alter table FD_FlowDistributionRecords add PushToKey nvarchar(50)


alter table FD_RechargeRecords add RechargeTo int;