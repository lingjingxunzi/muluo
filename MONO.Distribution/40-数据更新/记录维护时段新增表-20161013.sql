
create table FD_CarrierMaintainRecords(
CarrierMaintainRecordKey [int] IDENTITY(1,1) NOT NULL,
	StartDate datetime  NULL,
	EndDate datetime  NULL,
	RecoveryStatus nvarchar(20), 
	CONSTRAINT [PK_FD_CarrierMaintainRecord] PRIMARY KEY CLUSTERED 
(
	CarrierMaintainRecordKey ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]




create table FD_CarrierMaintainDetails(
CarrierMaintainDetailKey  nvarchar(50) NOT NULL,
	CarrierMaintainRecordKey int  NULL,
	FlowKey int null ,
	CONSTRAINT [PK_FD_CarrierMaintainDetail] PRIMARY KEY CLUSTERED 
(
	CarrierMaintainDetailKey ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]


 

