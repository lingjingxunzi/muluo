if exists(select * from sysobjects where name='FK_FD_CARDS_REFERENCE_FD_FLOWA') begin
    alter table FD_CardSampler
      drop constraint   FK_FD_CARDS_REFERENCE_FD_FLOWA
end;

if exists(select * from sysobjects where name='FK_FD_FLOWA_REFERENCE_FD_FLOWA') begin
    alter table FD_FlowActiveCardDetails
      drop constraint   FK_FD_FLOWA_REFERENCE_FD_FLOWA
end;

if exists(select * from sysobjects where name='FK_FD_FLOWA_REFERENCE_FD_FLOWD') begin
    alter table FD_FlowActiveHistories
      drop constraint   FK_FD_FLOWA_REFERENCE_FD_FLOWD
end;

if exists(select * from sysobjects where name='FK_FD_FLOWD_REFERENCE_FD_SYSTE') begin
    alter table FD_FlowDistributionRecords
      drop constraint   FK_FD_FLOWD_REFERENCE_FD_SYSTE
end;

if exists(select * from sysobjects where name='FK_FD_FLOWD_REFERENCE_FD_COMPA') begin
    alter table FD_FlowDistributionRecords
     drop constraint   FK_FD_FLOWD_REFERENCE_FD_COMPA
end;

if exists(
   select * from sysobjects 
   where name='FD_CardSampler'
     
) begin
    drop table FD_CardSampler
end;

if exists(
   select * from sysobjects 
   where name='FD_FlowActiveCard'
     
) begin
    drop table FD_FlowActiveCard
end;

if exists(
   select * from sysobjects 
      where name='FD_FlowActiveCardDetails'     
) begin
    drop table FD_FlowActiveCardDetails
end;

if exists(
   select * from sysobjects 
   where name='FD_FlowActiveHistories'   
) begin
    drop table FD_FlowActiveHistories
end;

if exists(
   select 1 from sysobjects 
   where name='FD_FlowDistributionRecords'
     
) begin
    drop table FD_FlowDistributionRecords
end;

/*==============================================================*/
/* Table: FD_CardSampler                                        */
/*==============================================================*/
create table FD_CardSampler 
(
   CardSamplerKey       int     IDENTITY(1,1)                          not null,
   TransNo              nvarchar(50),
   FlowKey              int,
   constraint PK_FD_CARDSAMPLER primary key clustered (CardSamplerKey)
);

/*==============================================================*/
/* Table: FD_FlowActiveCard                                     */
/*==============================================================*/
create table FD_FlowActiveCard 
(
   TransNo              nvarchar(50)                   not null,
   Numbers              int,
   Amount               money,
   CreateTime           datetime,
   OverdueTime          datetime,
   Status               nvarchar(20),
   SysUserKey           int,
   constraint PK_FD_FLOWACTIVECARD primary key clustered (TransNo)
);

/*==============================================================*/
/* Table: FD_FlowActiveCardDetails                              */
/*==============================================================*/
create table FD_FlowActiveCardDetails 
(
   CardID               nvarchar(8)                    not null,
   TransNo              nvarchar(50),
   Serect               nvarchar(8),
   Status               nvarchar(20),
   MobilePhone          nvarchar(11),
   FlowPakegeKey        int,
   RechargeTime         datetime,
   constraint PK_FD_FLOWACTIVECARDDETAILS primary key clustered (CardID)
);

/*==============================================================*/
/* Table: FD_FlowActiveHistories                                */
/*==============================================================*/
create table FD_FlowActiveHistories 
(
   FlowActiveHistoryKey nvarchar(50)                   not null,
   DistributionRecordKey nvarchar(50),
   Carrier              nvarchar(20),
   Code             nvarchar(100),
   Orders               nvarchar(100),
   Results              nvarchar(200),
   constraint PK_FD_FLOWACTIVEHISTORIES primary key clustered (FlowActiveHistoryKey)
);

/*==============================================================*/
/* Table: FD_FlowDistributionRecords                            */
/*==============================================================*/
create table FD_FlowDistributionRecords 
(
   DistributionRecordKey nvarchar(50)                   not null,
   SysUserKey           int,
   CompanyFlowPacketKey int,
   MobilePhone          nvarchar(11),
   OrderStatus          nvarchar(20),
   OrderNo              nvarchar(50),
   CreateTime           datetime,
   UpdateTime           datetime,
   Code             nvarchar(50),
   Carrier              nvarchar(20),
   ResultMsg            nvarchar(200),
   constraint PK_FD_FLOWDISTRIBUTIONRECORDS primary key clustered (DistributionRecordKey)
);

alter table FD_CardSampler
   add constraint FK_FD_CARDS_REFERENCE_FD_FLOWA foreign key (TransNo)
      references FD_FlowActiveCard (TransNo)
     

alter table FD_FlowActiveCardDetails
   add constraint FK_FD_FLOWA_REFERENCE_FD_FLOWA foreign key (TransNo)
      references FD_FlowActiveCard (TransNo)
    

alter table FD_FlowActiveHistories
   add constraint FK_FD_FLOWA_REFERENCE_FD_FLOWD foreign key (DistributionRecordKey)
      references FD_FlowDistributionRecords (DistributionRecordKey)
     

alter table FD_FlowDistributionRecords
   add constraint FK_FD_FLOWD_REFERENCE_FD_SYSTE foreign key (SysUserKey)
      references FD_System_Users (SysUserKey)
    

alter table FD_FlowDistributionRecords
   add constraint FK_FD_FLOWD_REFERENCE_FD_COMPA foreign key (CompanyFlowPacketKey)
      references FD_CompanyFlowPackets (CompanyFlowPacketKey)
     