--USE [Client]
USE [NGZ_client_2021]

GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Clients](
	[users_id] int IDENTITY (1,1) PRIMARY KEY NOT NULL,
	[name] [nvarchar](30) NOT NULL,
	[first_name] [nchar](10) NOT NULL,
	[second_name] [nchar](10) NOT NULL,
	[address] [nchar](10) NOT NULL,
	[phone] [nchar](10) NOT NULL,
	[second_contact] [nchar](10) NOT NULL,
	[email] [nvarchar](30) NOT NULL,
	[password] [nvarchar](30) NOT NULL,
	time_stamp date NOT NULL)
GO


CREATE TABLE [dbo].[Issue](
	[Description] [nvarchar](50) NOT NULL,
	[ReportNumber] [int] IDENTITY(100,1) NOT NULL,
	[RegisterTimestamp] [timestamp] NOT NULL,
	[Address] [nvarchar](50) NOT NULL,
	[ContactPhone] [int] NOT NULL,
	[ContactEmail] [nvarchar](50) NOT NULL,
	[Status] [nvarchar](50) NOT NULL,
	[SupportUserAssigned] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Issue] PRIMARY KEY CLUSTERED 
(
	[ReportNumber] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[Comment](
	[Id] [int] NOT NULL PRIMARY KEY IDENTITY(1,1),
	[ReportNumber] [int] NOT NULL,
	[Description] [nvarchar](50) NOT NULL,
	[CommentTimestamp] [timestamp] NOT NULL
	CONSTRAINT fk_commentIssue FOREIGN KEY (ReportNumber) 
	REFERENCES Issue (ReportNumber) 
)
GO

CREATE TABLE [dbo].[Service](
	[Id] [int] NOT NULL PRIMARY KEY IDENTITY(1,1),
	[Name] [nvarchar](50) NOT NULL,
	[EmailUser] [nvarchar](30) NOT NULL,
	[ReportNumber] [int] NOT NULL
	CONSTRAINT fk_ServiceEmailUser FOREIGN KEY (EmailUser)
	REFERENCES [Clients] (email), 
	CONSTRAINT fk_ServiceReportNumber FOREIGN KEY (ReportNumber)
	REFERENCES Issue (ReportNumber),
) 
GO



