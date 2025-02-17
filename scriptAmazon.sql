USE [master]
GO
/****** Object:  Database [Amazon]    Script Date: 17/12/2022 06:27:45 ******/
CREATE DATABASE [Amazon]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Amazon', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\Amazon.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'Amazon_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\Amazon_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [Amazon] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Amazon].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Amazon] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Amazon] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Amazon] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Amazon] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Amazon] SET ARITHABORT OFF 
GO
ALTER DATABASE [Amazon] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Amazon] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Amazon] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Amazon] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Amazon] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Amazon] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Amazon] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Amazon] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Amazon] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Amazon] SET  DISABLE_BROKER 
GO
ALTER DATABASE [Amazon] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Amazon] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Amazon] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Amazon] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Amazon] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Amazon] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Amazon] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Amazon] SET RECOVERY FULL 
GO
ALTER DATABASE [Amazon] SET  MULTI_USER 
GO
ALTER DATABASE [Amazon] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Amazon] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Amazon] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Amazon] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [Amazon] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [Amazon] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'Amazon', N'ON'
GO
ALTER DATABASE [Amazon] SET QUERY_STORE = OFF
GO
USE [Amazon]
GO
/****** Object:  User [Squall852]    Script Date: 17/12/2022 06:27:45 ******/
CREATE USER [Squall852] FOR LOGIN [Squall852] WITH DEFAULT_SCHEMA=[dbo]
GO
ALTER ROLE [db_owner] ADD MEMBER [Squall852]
GO
/****** Object:  Table [dbo].[Articulo]    Script Date: 17/12/2022 06:27:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Articulo](
	[IDArticulo] [nchar](10) NOT NULL,
	[Nombre] [nchar](50) NOT NULL,
	[Descripcion] [nchar](60) NOT NULL,
	[Precio] [int] NOT NULL,
	[Empresa] [nchar](50) NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Autorizacion]    Script Date: 17/12/2022 06:27:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Autorizacion](
	[IDAutorizacion] [nchar](10) NOT NULL,
	[IDCliente] [nchar](10) NOT NULL,
	[Nombre] [nchar](50) NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Cliente]    Script Date: 17/12/2022 06:27:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Cliente](
	[IDCliente] [nchar](10) NOT NULL,
	[Nombre] [nchar](50) NOT NULL,
	[Contraseña] [nchar](30) NOT NULL,
	[CorreoE] [nchar](50) NOT NULL,
	[Direccion] [nchar](70) NOT NULL,
	[Dinero] [int] NOT NULL,
	[IDPerfil] [nchar](10) NOT NULL,
 CONSTRAINT [PK_Cliente] PRIMARY KEY CLUSTERED 
(
	[IDCliente] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Localizacion]    Script Date: 17/12/2022 06:27:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Localizacion](
	[IDLocalizacion] [nchar](10) NOT NULL,
	[Descripcion] [nchar](50) NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Paquete]    Script Date: 17/12/2022 06:27:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Paquete](
	[IDPaquete] [nchar](10) NOT NULL,
	[IDCliente] [nchar](10) NOT NULL,
	[IDArticulo] [nchar](10) NOT NULL,
	[Entregado] [bit] NOT NULL,
	[Descripcion] [nchar](30) NOT NULL,
	[Fecha] [datetime] NOT NULL,
 CONSTRAINT [PK_Paquete] PRIMARY KEY CLUSTERED 
(
	[IDPaquete] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Perfil]    Script Date: 17/12/2022 06:27:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Perfil](
	[IDPerfil] [nchar](10) NOT NULL,
	[Descripcion] [nchar](20) NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Ruta]    Script Date: 17/12/2022 06:27:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Ruta](
	[IDRuta] [nchar](10) NOT NULL,
	[IDPaquete] [nchar](10) NOT NULL,
	[Fecha] [datetime] NOT NULL,
	[IDLocalizacion] [nchar](10) NOT NULL
) ON [PRIMARY]
GO
/****** Object:  StoredProcedure [dbo].[PA_AutenticacionCliente]    Script Date: 17/12/2022 06:27:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create procedure [dbo].[PA_AutenticacionCliente]
@Nombre nvarchar(50),
@Contraseña nvarchar(50)
as
Select * From Cliente where Nombre = @Nombre and Contraseña = @Contraseña and IDPerfil = '1'


GO
/****** Object:  StoredProcedure [dbo].[PA_AutenticacionClientenp]    Script Date: 17/12/2022 06:27:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create procedure [dbo].[PA_AutenticacionClientenp]
@Nombre nvarchar(50),
@Contraseña nvarchar(50)
as
Select * From Cliente where Nombre = @Nombre and IDPerfil = '1'


GO
/****** Object:  StoredProcedure [dbo].[PA_AutenticacionFuncionario]    Script Date: 17/12/2022 06:27:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create procedure [dbo].[PA_AutenticacionFuncionario]
@Nombre nvarchar(50),
@Contraseña nvarchar(50)
as
Select * From Cliente where Nombre = @Nombre and Contraseña = @Contraseña and IDPerfil = '2'


GO
/****** Object:  StoredProcedure [dbo].[PA_AutenticacionFuncionarionp]    Script Date: 17/12/2022 06:27:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create procedure [dbo].[PA_AutenticacionFuncionarionp]
@Nombre nvarchar(50),
@Contraseña nvarchar(50)
as
Select * From Cliente where Nombre = @Nombre and IDPerfil = '2'


GO
USE [master]
GO
ALTER DATABASE [Amazon] SET  READ_WRITE 
GO
