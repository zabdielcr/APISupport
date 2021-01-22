USE [dbSupport]
GO

/****** Object:  Table [dbo].[Issue]    Script Date: 1/22/2021 12:30:21 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Issue](
	[ReportNumber] [int] IDENTITY(1,1) NOT NULL,
	[Classification] [nvarchar](30) NOT NULL,
	[Status] [nvarchar](30) NOT NULL,
	[ReportTimestamp] [timestamp] NOT NULL,
	[ResolutionComment] [nvarchar](50) NOT NULL,
	[IdSupporter] [nvarchar](40) NOT NULL,
 CONSTRAINT [PK_Issue] PRIMARY KEY CLUSTERED 
(
	[ReportNumber] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[Issue]  WITH CHECK ADD  CONSTRAINT [FK_Issue_Supporter] FOREIGN KEY([IdSupporter])
REFERENCES [dbo].[Supporter] ([Email])
GO

ALTER TABLE [dbo].[Issue] CHECK CONSTRAINT [FK_Issue_Supporter]
GO

CREATE TABLE [dbo].[Note](
	[IdNotes] [int] IDENTITY(1,1) NOT NULL,
	[Description] [nvarchar](50) NOT NULL,
	[NoteTimestamp] [timestamp] NOT NULL,
	[IdIssue] [int] NOT NULL,
 CONSTRAINT [PK_Note] PRIMARY KEY CLUSTERED 
(
	[IdNotes] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[Note]  WITH CHECK ADD  CONSTRAINT [FK_Note_Issue] FOREIGN KEY([IdIssue])
REFERENCES [dbo].[Issue] ([ReportNumber])
GO

ALTER TABLE [dbo].[Note] CHECK CONSTRAINT [FK_Note_Issue]
GO

CREATE TABLE [dbo].[Service](
	[IdService] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](30) NULL,
	[IdSupporter] [nvarchar](40) NULL,
	[IdIssue] [int] NULL,
 CONSTRAINT [PK_Service] PRIMARY KEY CLUSTERED 
(
	[IdService] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[Service]  WITH CHECK ADD  CONSTRAINT [FK_Service_Issue] FOREIGN KEY([IdIssue])
REFERENCES [dbo].[Issue] ([ReportNumber])
GO

ALTER TABLE [dbo].[Service] CHECK CONSTRAINT [FK_Service_Issue]
GO

ALTER TABLE [dbo].[Service]  WITH CHECK ADD  CONSTRAINT [FK_Service_Supporter] FOREIGN KEY([IdSupporter])
REFERENCES [dbo].[Supporter] ([Email])
GO

ALTER TABLE [dbo].[Service] CHECK CONSTRAINT [FK_Service_Supporter]
GO

CREATE TABLE [dbo].[Supervisor](
	[Name] [nvarchar](30) NOT NULL,
	[FirtsSurname] [nvarchar](30) NOT NULL,
	[SecondSurname] [nvarchar](30) NOT NULL,
	[Email] [nvarchar](40) NOT NULL,
 CONSTRAINT [PK_Supervisor] PRIMARY KEY CLUSTERED 
(
	[Email] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[Supporter](
	[Name] [nvarchar](30) NOT NULL,
	[FirstSurname] [nvarchar](30) NOT NULL,
	[SecondSurname] [nvarchar](30) NOT NULL,
	[Email] [nvarchar](40) NOT NULL,
	[IdSupervisor] [nvarchar](40) NOT NULL,
 CONSTRAINT [PK_Supporter] PRIMARY KEY CLUSTERED 
(
	[Email] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[Supporter]  WITH CHECK ADD  CONSTRAINT [FK_Supporter_Supervisor] FOREIGN KEY([IdSupervisor])
REFERENCES [dbo].[Supervisor] ([Email])
GO

ALTER TABLE [dbo].[Supporter] CHECK CONSTRAINT [FK_Supporter_Supervisor]
GO

