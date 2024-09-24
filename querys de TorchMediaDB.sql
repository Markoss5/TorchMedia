USE [master]
GO
/****** Object:  Database [TorchMediaDB]    Script Date: 24/9/2024 12:41:02 ******/
CREATE DATABASE [TorchMediaDB]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'TorchMediaDB', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.MSSQLSERVER\MSSQL\DATA\TorchMediaDB.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'TorchMediaDB_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.MSSQLSERVER\MSSQL\DATA\TorchMediaDB_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [TorchMediaDB] SET COMPATIBILITY_LEVEL = 140
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [TorchMediaDB].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [TorchMediaDB] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [TorchMediaDB] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [TorchMediaDB] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [TorchMediaDB] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [TorchMediaDB] SET ARITHABORT OFF 
GO
ALTER DATABASE [TorchMediaDB] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [TorchMediaDB] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [TorchMediaDB] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [TorchMediaDB] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [TorchMediaDB] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [TorchMediaDB] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [TorchMediaDB] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [TorchMediaDB] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [TorchMediaDB] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [TorchMediaDB] SET  ENABLE_BROKER 
GO
ALTER DATABASE [TorchMediaDB] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [TorchMediaDB] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [TorchMediaDB] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [TorchMediaDB] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [TorchMediaDB] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [TorchMediaDB] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [TorchMediaDB] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [TorchMediaDB] SET RECOVERY FULL 
GO
ALTER DATABASE [TorchMediaDB] SET  MULTI_USER 
GO
ALTER DATABASE [TorchMediaDB] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [TorchMediaDB] SET DB_CHAINING OFF 
GO
ALTER DATABASE [TorchMediaDB] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [TorchMediaDB] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [TorchMediaDB] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'TorchMediaDB', N'ON'
GO
ALTER DATABASE [TorchMediaDB] SET QUERY_STORE = OFF
GO
USE [TorchMediaDB]
GO
/****** Object:  User [alumno]    Script Date: 24/9/2024 12:41:02 ******/
CREATE USER [alumno] FOR LOGIN [alumno] WITH DEFAULT_SCHEMA=[dbo]
GO
/****** Object:  Table [dbo].[Disponibilidad]    Script Date: 24/9/2024 12:41:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Disponibilidad](
	[DisponibilidadID] [int] IDENTITY(1,1) NOT NULL,
	[Fecha] [datetime] NOT NULL,
	[HoraInicio] [time](7) NOT NULL,
	[HoraFin] [time](7) NOT NULL,
	[Disponible] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[DisponibilidadID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[FooterContent]    Script Date: 24/9/2024 12:41:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[FooterContent](
	[FooterID] [int] IDENTITY(1,1) NOT NULL,
	[Texto] [nvarchar](255) NULL,
	[Correo] [nvarchar](100) NULL,
	[InstagramUrl] [nvarchar](255) NULL,
PRIMARY KEY CLUSTERED 
(
	[FooterID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[HeroContent]    Script Date: 24/9/2024 12:41:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[HeroContent](
	[HeroContentID] [int] IDENTITY(1,1) NOT NULL,
	[Titulo] [nvarchar](255) NULL,
	[Descripcion] [nvarchar](max) NULL,
	[VideoUrl] [nvarchar](255) NULL,
PRIMARY KEY CLUSTERED 
(
	[HeroContentID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ProyectosContent]    Script Date: 24/9/2024 12:41:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProyectosContent](
	[ProyectoID] [int] IDENTITY(1,1) NOT NULL,
	[VideoUrl] [nvarchar](255) NULL,
	[ImagenUrl] [nvarchar](255) NULL,
PRIMARY KEY CLUSTERED 
(
	[ProyectoID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[QuienesSomosContent]    Script Date: 24/9/2024 12:41:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[QuienesSomosContent](
	[QuienesSomosID] [int] IDENTITY(1,1) NOT NULL,
	[Titulo] [nvarchar](255) NULL,
	[Descripcion] [nvarchar](max) NULL,
	[ImagenUrl] [nvarchar](255) NULL,
PRIMARY KEY CLUSTERED 
(
	[QuienesSomosID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ServiciosContent]    Script Date: 24/9/2024 12:41:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ServiciosContent](
	[ServicioID] [int] IDENTITY(1,1) NOT NULL,
	[Titulo] [nvarchar](255) NULL,
	[Descripcion] [nvarchar](max) NULL,
	[IconoUrl] [nvarchar](255) NULL,
PRIMARY KEY CLUSTERED 
(
	[ServicioID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TestimoniosContent]    Script Date: 24/9/2024 12:41:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TestimoniosContent](
	[TestimonioID] [int] IDENTITY(1,1) NOT NULL,
	[VideoUrl] [nvarchar](255) NULL,
	[ImagenUrl] [nvarchar](255) NULL,
PRIMARY KEY CLUSTERED 
(
	[TestimonioID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Turnos]    Script Date: 24/9/2024 12:41:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Turnos](
	[TurnoID] [int] IDENTITY(1,1) NOT NULL,
	[UsuarioID] [int] NOT NULL,
	[FechaAgendada] [datetime] NOT NULL,
	[Estado] [nvarchar](50) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[TurnoID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Usuarios]    Script Date: 24/9/2024 12:41:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Usuarios](
	[UsuarioID] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [nvarchar](100) NOT NULL,
	[Correo] [nvarchar](100) NOT NULL,
	[TextoAdicional] [nvarchar](max) NULL,
	[Password] [nvarchar](255) NOT NULL,
	[EsAdmin] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[UsuarioID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[FooterContent] ON 

INSERT [dbo].[FooterContent] ([FooterID], [Texto], [Correo], [InstagramUrl]) VALUES (1, N'© 2024 Todos los Derechos Reservados TorchMediaGrowth S.A.', N'infotorchmedia@gmail.com', N'https://www.instagram.com/torchmediagrowth')
SET IDENTITY_INSERT [dbo].[FooterContent] OFF
GO
SET IDENTITY_INSERT [dbo].[HeroContent] ON 

INSERT [dbo].[HeroContent] ([HeroContentID], [Titulo], [Descripcion], [VideoUrl]) VALUES (1, N'BIENVENIDO A TorchMedia', N'Transforma tus ideas en realidad con nuestra agencia de edición de video y embudos de ventas. Impulsa tu negocio con contenido visual impactante y estrategias de conversión efectivas. Descubre cómo podemos ayudarte a alcanzar tus objetivos hoy.', N'Video/videoFondo.mp4')
SET IDENTITY_INSERT [dbo].[HeroContent] OFF
GO
SET IDENTITY_INSERT [dbo].[ProyectosContent] ON 

INSERT [dbo].[ProyectosContent] ([ProyectoID], [VideoUrl], [ImagenUrl]) VALUES (1, N'Video/video-1.mp4', N'Img/video-1.jpg')
INSERT [dbo].[ProyectosContent] ([ProyectoID], [VideoUrl], [ImagenUrl]) VALUES (2, N'Video/video-2.mp4', N'Img/video-2.jpg')
INSERT [dbo].[ProyectosContent] ([ProyectoID], [VideoUrl], [ImagenUrl]) VALUES (3, N'Video/video-3.mp4', N'Img/video-3.jpg')
SET IDENTITY_INSERT [dbo].[ProyectosContent] OFF
GO
SET IDENTITY_INSERT [dbo].[QuienesSomosContent] ON 

INSERT [dbo].[QuienesSomosContent] ([QuienesSomosID], [Titulo], [Descripcion], [ImagenUrl]) VALUES (1, N'QUIÉNES SOMOS', N'En TorchMedia, transformamos ideas en videos impactantes y estrategias de ventas efectivas para hacer crecer tu negocio. Con compromiso absoluto hacia la calidad y resultados, estamos aquí para llevar tu éxito al siguiente nivel.', N'Img/logo.png')
SET IDENTITY_INSERT [dbo].[QuienesSomosContent] OFF
GO
SET IDENTITY_INSERT [dbo].[ServiciosContent] ON 

INSERT [dbo].[ServiciosContent] ([ServicioID], [Titulo], [Descripcion], [IconoUrl]) VALUES (1, N'Edición y estrategias de contenido', N'Transformamos tus ideas en experiencias visuales memorables. Desde la edición experta hasta la estrategia de contenido, optimizamos cada detalle para captar y retener la atención de tu audiencia.', N'Img/video edit icon.png')
INSERT [dbo].[ServiciosContent] ([ServicioID], [Titulo], [Descripcion], [IconoUrl]) VALUES (2, N'Guiones y portadas para tus videos', N'Creamos narrativas cautivadoras y portadas visualmente atractivas que destacan entre la multitud. Nuestros guiones y diseño de portadas garantizan que cada video no solo cuente una historia, sino que también impulse la acción de tu audiencia.', N'Img/icono-2.png')
INSERT [dbo].[ServiciosContent] ([ServicioID], [Titulo], [Descripcion], [IconoUrl]) VALUES (3, N'Embudos de venta', N'Diseñamos embudos de venta personalizados que convierten visitantes en clientes. Desde la captación inicial hasta la conversión final, optimizamos cada etapa para maximizar tus conversiones y aumentar tus ingresos.', N'Img/sales-funnel.jpg')
SET IDENTITY_INSERT [dbo].[ServiciosContent] OFF
GO
SET IDENTITY_INSERT [dbo].[TestimoniosContent] ON 

INSERT [dbo].[TestimoniosContent] ([TestimonioID], [VideoUrl], [ImagenUrl]) VALUES (1, N'path/to/tu-video.mp4', N'Img/testimonio-1.png')
SET IDENTITY_INSERT [dbo].[TestimoniosContent] OFF
GO
SET IDENTITY_INSERT [dbo].[Usuarios] ON 

INSERT [dbo].[Usuarios] ([UsuarioID], [Nombre], [Correo], [TextoAdicional], [Password], [EsAdmin]) VALUES (1, N'Marco', N'marco@gmail.com', NULL, N'123Banfield', 1)
INSERT [dbo].[Usuarios] ([UsuarioID], [Nombre], [Correo], [TextoAdicional], [Password], [EsAdmin]) VALUES (2, N'Marcoss', N'marcosbeider@gmail.com', NULL, N'Banfield', 0)
SET IDENTITY_INSERT [dbo].[Usuarios] OFF
GO
ALTER TABLE [dbo].[Disponibilidad] ADD  DEFAULT ((1)) FOR [Disponible]
GO
ALTER TABLE [dbo].[Usuarios] ADD  DEFAULT ((0)) FOR [EsAdmin]
GO
ALTER TABLE [dbo].[Turnos]  WITH CHECK ADD  CONSTRAINT [FK_Turnos_Usuarios] FOREIGN KEY([UsuarioID])
REFERENCES [dbo].[Usuarios] ([UsuarioID])
GO
ALTER TABLE [dbo].[Turnos] CHECK CONSTRAINT [FK_Turnos_Usuarios]
GO
USE [master]
GO
ALTER DATABASE [TorchMediaDB] SET  READ_WRITE 
GO
