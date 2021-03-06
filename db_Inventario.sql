USE [master]
GO
/****** Object:  Database [DB_Inventario]    Script Date: 15/09/2021 21:44:09 ******/
CREATE DATABASE [DB_Inventario]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'DB_Inventario', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\DB_Inventario.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'DB_Inventario_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\DB_Inventario_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [DB_Inventario] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [DB_Inventario].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [DB_Inventario] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [DB_Inventario] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [DB_Inventario] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [DB_Inventario] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [DB_Inventario] SET ARITHABORT OFF 
GO
ALTER DATABASE [DB_Inventario] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [DB_Inventario] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [DB_Inventario] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [DB_Inventario] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [DB_Inventario] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [DB_Inventario] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [DB_Inventario] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [DB_Inventario] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [DB_Inventario] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [DB_Inventario] SET  ENABLE_BROKER 
GO
ALTER DATABASE [DB_Inventario] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [DB_Inventario] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [DB_Inventario] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [DB_Inventario] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [DB_Inventario] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [DB_Inventario] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [DB_Inventario] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [DB_Inventario] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [DB_Inventario] SET  MULTI_USER 
GO
ALTER DATABASE [DB_Inventario] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [DB_Inventario] SET DB_CHAINING OFF 
GO
ALTER DATABASE [DB_Inventario] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [DB_Inventario] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [DB_Inventario] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [DB_Inventario] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [DB_Inventario] SET QUERY_STORE = OFF
GO
USE [DB_Inventario]
GO
/****** Object:  Table [dbo].[marca]    Script Date: 15/09/2021 21:44:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[marca](
	[id_marca] [int] IDENTITY(1,1) NOT NULL,
	[descripcion] [varchar](100) NULL,
PRIMARY KEY CLUSTERED 
(
	[id_marca] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[presentacion]    Script Date: 15/09/2021 21:44:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[presentacion](
	[id_presentacion] [int] IDENTITY(1,1) NOT NULL,
	[descripcion] [varchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[id_presentacion] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[producto]    Script Date: 15/09/2021 21:44:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[producto](
	[id_producto] [int] IDENTITY(1,1) NOT NULL,
	[id_marca] [int] NULL,
	[id_presentacion] [int] NULL,
	[id_proveedor] [int] NULL,
	[id_zona] [int] NULL,
	[codigo] [int] NULL,
	[descripcion_producto] [varchar](1000) NULL,
	[precio] [float] NOT NULL,
	[stock] [int] NOT NULL,
	[iva] [int] NULL,
	[peso] [float] NULL,
PRIMARY KEY CLUSTERED 
(
	[id_producto] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[proveedor]    Script Date: 15/09/2021 21:44:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[proveedor](
	[id_proveedor] [int] IDENTITY(1,1) NOT NULL,
	[descripcion] [varchar](100) NULL,
PRIMARY KEY CLUSTERED 
(
	[id_proveedor] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[zona]    Script Date: 15/09/2021 21:44:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[zona](
	[id_zona] [int] IDENTITY(1,1) NOT NULL,
	[descripcion] [varchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[id_zona] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[marca] ON 

INSERT [dbo].[marca] ([id_marca], [descripcion]) VALUES (2, N'Cafe de montaña')
SET IDENTITY_INSERT [dbo].[marca] OFF
GO
SET IDENTITY_INSERT [dbo].[presentacion] ON 

INSERT [dbo].[presentacion] ([id_presentacion], [descripcion]) VALUES (1, N'pequeña')
INSERT [dbo].[presentacion] ([id_presentacion], [descripcion]) VALUES (2, N'Mediana')
SET IDENTITY_INSERT [dbo].[presentacion] OFF
GO
SET IDENTITY_INSERT [dbo].[producto] ON 

INSERT [dbo].[producto] ([id_producto], [id_marca], [id_presentacion], [id_proveedor], [id_zona], [codigo], [descripcion_producto], [precio], [stock], [iva], [peso]) VALUES (14, 2, 1, 2, 1, 3093, N'café frio', 35.299999237060547, 4, 3, 5.4000000953674316)
INSERT [dbo].[producto] ([id_producto], [id_marca], [id_presentacion], [id_proveedor], [id_zona], [codigo], [descripcion_producto], [precio], [stock], [iva], [peso]) VALUES (15, 2, 1, 2, 1, 293, N'late', 35.299999237060547, 4, 3, 5.4000000953674316)
INSERT [dbo].[producto] ([id_producto], [id_marca], [id_presentacion], [id_proveedor], [id_zona], [codigo], [descripcion_producto], [precio], [stock], [iva], [peso]) VALUES (16, 2, 1, 2, 1, 2783, N'te', 35.299999237060547, 4, 3, 5.4000000953674316)
INSERT [dbo].[producto] ([id_producto], [id_marca], [id_presentacion], [id_proveedor], [id_zona], [codigo], [descripcion_producto], [precio], [stock], [iva], [peso]) VALUES (17, 2, 1, 2, 1, 234, N'granita de fruta', 30.299999237060547, 6, 3, 4.4000000953674316)
SET IDENTITY_INSERT [dbo].[producto] OFF
GO
SET IDENTITY_INSERT [dbo].[proveedor] ON 

INSERT [dbo].[proveedor] ([id_proveedor], [descripcion]) VALUES (2, N'Cafe de Santa Barbara')
SET IDENTITY_INSERT [dbo].[proveedor] OFF
GO
SET IDENTITY_INSERT [dbo].[zona] ON 

INSERT [dbo].[zona] ([id_zona], [descripcion]) VALUES (1, N'pruebando 1')
INSERT [dbo].[zona] ([id_zona], [descripcion]) VALUES (2, N'pruebando 2')
SET IDENTITY_INSERT [dbo].[zona] OFF
GO
ALTER TABLE [dbo].[marca] ADD  DEFAULT (NULL) FOR [descripcion]
GO
ALTER TABLE [dbo].[presentacion] ADD  DEFAULT (NULL) FOR [descripcion]
GO
ALTER TABLE [dbo].[producto] ADD  DEFAULT (NULL) FOR [codigo]
GO
ALTER TABLE [dbo].[producto] ADD  DEFAULT (NULL) FOR [descripcion_producto]
GO
ALTER TABLE [dbo].[producto] ADD  DEFAULT (NULL) FOR [iva]
GO
ALTER TABLE [dbo].[producto] ADD  DEFAULT (NULL) FOR [peso]
GO
ALTER TABLE [dbo].[proveedor] ADD  DEFAULT (NULL) FOR [descripcion]
GO
ALTER TABLE [dbo].[zona] ADD  DEFAULT (NULL) FOR [descripcion]
GO
ALTER TABLE [dbo].[producto]  WITH CHECK ADD FOREIGN KEY([id_marca])
REFERENCES [dbo].[marca] ([id_marca])
GO
ALTER TABLE [dbo].[producto]  WITH CHECK ADD FOREIGN KEY([id_marca])
REFERENCES [dbo].[marca] ([id_marca])
GO
ALTER TABLE [dbo].[producto]  WITH CHECK ADD FOREIGN KEY([id_presentacion])
REFERENCES [dbo].[presentacion] ([id_presentacion])
GO
ALTER TABLE [dbo].[producto]  WITH CHECK ADD FOREIGN KEY([id_presentacion])
REFERENCES [dbo].[presentacion] ([id_presentacion])
GO
ALTER TABLE [dbo].[producto]  WITH CHECK ADD FOREIGN KEY([id_proveedor])
REFERENCES [dbo].[proveedor] ([id_proveedor])
GO
ALTER TABLE [dbo].[producto]  WITH CHECK ADD FOREIGN KEY([id_proveedor])
REFERENCES [dbo].[proveedor] ([id_proveedor])
GO
ALTER TABLE [dbo].[producto]  WITH CHECK ADD FOREIGN KEY([id_zona])
REFERENCES [dbo].[zona] ([id_zona])
GO
ALTER TABLE [dbo].[producto]  WITH CHECK ADD FOREIGN KEY([id_zona])
REFERENCES [dbo].[zona] ([id_zona])
GO
USE [master]
GO
ALTER DATABASE [DB_Inventario] SET  READ_WRITE 
GO
