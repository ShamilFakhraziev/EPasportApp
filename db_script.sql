USE [master]
GO
/****** Object:  Database [EPasport]    Script Date: 09.03.2025 1:16:51 ******/
CREATE DATABASE [EPasport]
USE [EPasport]
GO
/****** Object:  Table [dbo].[MaintenanceWorksSet]    Script Date: 09.03.2025 1:16:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MaintenanceWorksSet](
	[Id] [uniqueidentifier] NOT NULL,
	[Title] [nvarchar](max) NOT NULL,
	[Time] [datetime] NOT NULL,
	[EngineerName] [nvarchar](max) NOT NULL,
	[PriceOfWork] [decimal](18, 0) NOT NULL,
	[TechObject_Id] [uniqueidentifier] NOT NULL,
 CONSTRAINT [PK_MaintenanceWorksSet] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TechObjectSet]    Script Date: 09.03.2025 1:16:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TechObjectSet](
	[Id] [uniqueidentifier] NOT NULL,
	[Number] [nvarchar](max) NOT NULL,
	[Series] [nvarchar](max) NOT NULL,
	[ProductionTime] [datetime] NOT NULL,
	[DateOfSale] [datetime] NOT NULL,
	[Price] [decimal](18, 0) NOT NULL,
	[SellerName] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_TechObjectSet] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Index [IX_FK_TechObjectMaintenanceWorks]    Script Date: 09.03.2025 1:16:51 ******/
CREATE NONCLUSTERED INDEX [IX_FK_TechObjectMaintenanceWorks] ON [dbo].[MaintenanceWorksSet]
(
	[TechObject_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[MaintenanceWorksSet]  WITH CHECK ADD  CONSTRAINT [FK_TechObjectMaintenanceWorks] FOREIGN KEY([TechObject_Id])
REFERENCES [dbo].[TechObjectSet] ([Id])
GO
ALTER TABLE [dbo].[MaintenanceWorksSet] CHECK CONSTRAINT [FK_TechObjectMaintenanceWorks]
GO
USE [master]
GO
ALTER DATABASE [EPasport] SET  READ_WRITE 
GO
