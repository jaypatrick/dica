SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Playlists]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Playlists](
	[PlaylistsID] [int] NOT NULL,
	[StationTitle] [nvarchar](50) NULL,
	[StationUrl] [nvarchar](50) NULL,
	[GenerateTime] [datetime] NULL,
 CONSTRAINT [PK_Playlists] PRIMARY KEY CLUSTERED 
(
	[PlaylistsID] ASC
)WITH (PAD_INDEX  = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Event]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Event](
	[EventID] [int] NOT NULL,
	[GenerateTime] [datetime] NULL,
 CONSTRAINT [PK_Event] PRIMARY KEY CLUSTERED 
(
	[EventID] ASC
)WITH (PAD_INDEX  = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Track]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Track](
	[TrackID] [int] NOT NULL,
	[TrackTitle] [nvarchar](50) NULL,
	[StartTime] [datetime] NULL,
	[RecordLabel] [nvarchar](50) NULL,
	[TrackUrl] [nvarchar](50) NULL,
	[BoardCount] [int] NOT NULL,
 CONSTRAINT [PK_Track] PRIMARY KEY CLUSTERED 
(
	[TrackID] ASC
)WITH (PAD_INDEX  = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Channel]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Channel](
	[ChannelID] [int] NOT NULL,
	[ChannelTitle] [nvarchar](50) NULL,
 CONSTRAINT [PK_Channel] PRIMARY KEY CLUSTERED 
(
	[ChannelID] ASC
)WITH (PAD_INDEX  = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ChannelsPlaylists]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[ChannelsPlaylists](
	[ChannelsID] [int] NOT NULL,
	[PlaylistsID] [int] NOT NULL,
 CONSTRAINT [PK_ChannelsPlaylists_1] PRIMARY KEY CLUSTERED 
(
	[ChannelsID] ASC
)WITH (PAD_INDEX  = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[EventDetails]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[EventDetails](
	[EventDetailsID] [int] NOT NULL,
	[EventID] [int] NOT NULL,
	[Date] [datetime] NULL,
	[Title] [nvarchar](50) NULL,
	[Subtitle] [nvarchar](100) NULL,
	[Timezone] [int] NULL,
	[StartTime] [datetime] NULL,
	[Endtime] [datetime] NULL,
	[ChannelID] [int] NULL,
	[Url] [nvarchar](50) NULL
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ExtraUrl]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[ExtraUrl](
	[Title] [nvarchar](50) NULL,
	[Text] [nvarchar](50) NULL,
	[TrackID] [int] NOT NULL
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[BuyUrl]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[BuyUrl](
	[From] [nvarchar](50) NULL,
	[TrackID] [int] NOT NULL
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[TracksChannel]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[TracksChannel](
	[TrackID] [int] NOT NULL,
	[ChannelID] [int] NOT NULL,
 CONSTRAINT [PK_TracksChannel_1] PRIMARY KEY CLUSTERED 
(
	[TrackID] ASC
)WITH (PAD_INDEX  = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_ChannelsPlaylists_Playlists]') AND parent_object_id = OBJECT_ID(N'[dbo].[ChannelsPlaylists]'))
ALTER TABLE [dbo].[ChannelsPlaylists]  WITH CHECK ADD  CONSTRAINT [FK_ChannelsPlaylists_Playlists] FOREIGN KEY([PlaylistsID])
REFERENCES [dbo].[Playlists] ([PlaylistsID])
GO
ALTER TABLE [dbo].[ChannelsPlaylists] CHECK CONSTRAINT [FK_ChannelsPlaylists_Playlists]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_EventDetails_Channel]') AND parent_object_id = OBJECT_ID(N'[dbo].[EventDetails]'))
ALTER TABLE [dbo].[EventDetails]  WITH CHECK ADD  CONSTRAINT [FK_EventDetails_Channel] FOREIGN KEY([ChannelID])
REFERENCES [dbo].[Channel] ([ChannelID])
GO
ALTER TABLE [dbo].[EventDetails] CHECK CONSTRAINT [FK_EventDetails_Channel]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_EventDetails_Event]') AND parent_object_id = OBJECT_ID(N'[dbo].[EventDetails]'))
ALTER TABLE [dbo].[EventDetails]  WITH CHECK ADD  CONSTRAINT [FK_EventDetails_Event] FOREIGN KEY([EventID])
REFERENCES [dbo].[Event] ([EventID])
GO
ALTER TABLE [dbo].[EventDetails] CHECK CONSTRAINT [FK_EventDetails_Event]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_ExtraUrl_Track]') AND parent_object_id = OBJECT_ID(N'[dbo].[ExtraUrl]'))
ALTER TABLE [dbo].[ExtraUrl]  WITH CHECK ADD  CONSTRAINT [FK_ExtraUrl_Track] FOREIGN KEY([TrackID])
REFERENCES [dbo].[Track] ([TrackID])
GO
ALTER TABLE [dbo].[ExtraUrl] CHECK CONSTRAINT [FK_ExtraUrl_Track]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_BuyUrl_Track]') AND parent_object_id = OBJECT_ID(N'[dbo].[BuyUrl]'))
ALTER TABLE [dbo].[BuyUrl]  WITH CHECK ADD  CONSTRAINT [FK_BuyUrl_Track] FOREIGN KEY([TrackID])
REFERENCES [dbo].[Track] ([TrackID])
GO
ALTER TABLE [dbo].[BuyUrl] CHECK CONSTRAINT [FK_BuyUrl_Track]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_TracksChannel_Track]') AND parent_object_id = OBJECT_ID(N'[dbo].[TracksChannel]'))
ALTER TABLE [dbo].[TracksChannel]  WITH CHECK ADD  CONSTRAINT [FK_TracksChannel_Track] FOREIGN KEY([ChannelID])
REFERENCES [dbo].[Channel] ([ChannelID])
GO
ALTER TABLE [dbo].[TracksChannel] CHECK CONSTRAINT [FK_TracksChannel_Track]
 