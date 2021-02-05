USE [Support]
GO

CREATE TABLE [dbo].[Supporter_Supervisor](
	[id] [int] PRIMARY KEY IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](30) NOT NULL,
	[firstName] [nvarchar](30) NOT NULL,
	[secondName] [nvarchar](30) NOT NULL,
	[address] [nvarchar](40) NOT NULL,
	[email] [nvarchar](40) NOT NULL,
	[password] [nvarchar](40) NOT NULL,
	[services] [nvarchar](50) NOT NULL
 )

Create table Issue(
	id integer primary key identity(1,1),
	id_client integer,
	[description] varchar(500),
	time_stamp date,
	contact_phone varchar(255),
	contact_email varchar(255),
	[classification] varchar(255),
	[status] varchar(255),
)

Create table Supporter_Issue(
id_supporter integer foreign key references Supporter_Supervisor(id), 
id_issue integer foreign key references Issue(id)
) 


CREATE TABLE [dbo].[Note](
	[id_notes] [int] IDENTITY(1,1) NOT NULL,
	[description] [nvarchar](50) NOT NULL,
	[noteTimestamp] [timestamp] NOT NULL,
	[id_issue] [int] NOT NULL,
 CONSTRAINT [PK_Note] PRIMARY KEY CLUSTERED 
(
	[id_notes] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON,) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[Note]  WITH CHECK ADD  CONSTRAINT [FK_Note_Issue] FOREIGN KEY([IdIssue])
REFERENCES [dbo].[Issue] ([ReportNumber])
GO

ALTER TABLE [dbo].[Note] CHECK CONSTRAINT [FK_Note_Issue]
GO

CREATE TABLE [dbo].[Service](
	[id_service] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](30) NULL,
	[idSupporter] [nvarchar](40) NULL,
	[id_issue] [int] NULL,
 CONSTRAINT [PK_Service] PRIMARY KEY CLUSTERED 
(
	[id_service] ASC
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

