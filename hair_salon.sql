USE [hair_salon]
GO
/****** Object:  Table [dbo].[clients]    Script Date: 7/27/2016 3:18:04 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[clients](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[client] [varchar](255) NULL,
	[stylist_id] [int] NULL
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[stylists]    Script Date: 7/27/2016 3:18:04 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[stylists](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[stylist] [varchar](255) NULL
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[stylists] ON 

INSERT [dbo].[stylists] ([id], [stylist]) VALUES (1, N'Jon')
INSERT [dbo].[stylists] ([id], [stylist]) VALUES (2, N'Dave')
INSERT [dbo].[stylists] ([id], [stylist]) VALUES (3, N'Kris')
INSERT [dbo].[stylists] ([id], [stylist]) VALUES (4, N'Danny')
SET IDENTITY_INSERT [dbo].[stylists] OFF
