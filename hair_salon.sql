USE [hair_salon]
GO
/****** Object:  Table [dbo].[clients]    Script Date: 7/15/2016 4:25:00 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[clients](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[client] [varchar](255) NULL
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[stylists]    Script Date: 7/15/2016 4:25:00 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[stylists](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[stylist] [varchar](255) NULL,
	[client_id] [int] NULL
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[stylists] ON 

INSERT [dbo].[stylists] ([id], [stylist], [client_id]) VALUES (1, N'Jon', NULL)
INSERT [dbo].[stylists] ([id], [stylist], [client_id]) VALUES (2, N'Dave', NULL)
INSERT [dbo].[stylists] ([id], [stylist], [client_id]) VALUES (3, N'Kris', NULL)
INSERT [dbo].[stylists] ([id], [stylist], [client_id]) VALUES (4, N'Danny', NULL)
SET IDENTITY_INSERT [dbo].[stylists] OFF
