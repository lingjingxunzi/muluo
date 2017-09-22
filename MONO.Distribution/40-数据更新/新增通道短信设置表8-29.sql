USE [MONO.Distribution]
GO

/****** Object:  Table [dbo].[FD_ChannelMsgSettings]    Script Date: 2017/8/29 16:40:14 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[FD_ChannelMsgSettings](
	[ChannelMsgSettingKey] [int] IDENTITY(1,1) NOT NULL,
	[ChannelName] [nvarchar](20) NULL,
	[MsgTemp] [nvarchar](200) NULL,
	[Status] [nvarchar](1) NULL
) ON [PRIMARY]

GO


