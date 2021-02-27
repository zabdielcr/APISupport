USE [Support]
GO

/****** Object:  Table [dbo].[Assignments]    Script Date: 2/26/2021 5:34:05 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Assignments](
	[idIssue] [int] NOT NULL,
	[idSupporter] [int] NOT NULL,
 CONSTRAINT [PK_Assignments] PRIMARY KEY CLUSTERED 
(
	[idIssue] ASC,
	[idSupporter] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[Assignments]  WITH CHECK ADD  CONSTRAINT [FK_Assignments_Issue] FOREIGN KEY([idIssue])
REFERENCES [dbo].[Issue] ([reportNumber])
GO

ALTER TABLE [dbo].[Assignments] CHECK CONSTRAINT [FK_Assignments_Issue]
GO

ALTER TABLE [dbo].[Assignments]  WITH CHECK ADD  CONSTRAINT [FK_Assignments_Supporter] FOREIGN KEY([idSupporter])
REFERENCES [dbo].[Supporter] ([id])
GO

ALTER TABLE [dbo].[Assignments] CHECK CONSTRAINT [FK_Assignments_Supporter]
GO


