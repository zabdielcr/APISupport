USE [Support]
GO

CREATE TABLE [dbo].[Supporter](
	[Id] [int] PRIMARY KEY IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](30) NOT NULL,
	[FirstName] [nvarchar](30) NOT NULL,
	[SecondName] [nvarchar](30) NOT NULL,
	[Address] [nvarchar](40) NOT NULL,
	[Email] [nvarchar](40) NOT NULL,
	[Password] [nvarchar](40) NOT NULL,
	[role] [int] NOT NULL,
 )

 CREATE TABLE [dbo].[Supervisor](
	[Id] [int] PRIMARY KEY IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](30) NOT NULL,
	[FirstName] [nvarchar](30) NOT NULL,
	[SecondName] [nvarchar](30) NOT NULL,
	[Address] [nvarchar](40) NOT NULL,
	[Email] [nvarchar](40) NOT NULL,
	[Password] [nvarchar](40) NOT NULL,
	[role] [int] NOT NULL,
)
GO

Create table Issue(
	Id integer primary key identity(1,1),
	Id_client integer,
	[Description] varchar(500),
	Time_stamp date,
	Contact_phone varchar(255),
	Contact_email varchar(255),
	[Classification] varchar(255),
	[status] varchar(255),
)



CREATE TABLE [dbo].[Note](
	[IdNotes] [int] IDENTITY(1,1) NOT NULL,
	[Description] [nvarchar](50) NOT NULL,
	[NoteTimestamp] [timestamp] NOT NULL,
	[IdIssue] [int] NOT NULL,
 CONSTRAINT [PK_Note] PRIMARY KEY CLUSTERED 
(
	[IdNotes] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON,) ON [PRIMARY]
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
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
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





ALTER TABLE [dbo].[Supporter]  WITH CHECK ADD  CONSTRAINT [FK_Supporter_Supervisor] FOREIGN KEY([IdSupervisor])
REFERENCES [dbo].[Supervisor] ([Email])
GO

ALTER TABLE [dbo].[Supporter] CHECK CONSTRAINT [FK_Supporter_Supervisor]
GO

