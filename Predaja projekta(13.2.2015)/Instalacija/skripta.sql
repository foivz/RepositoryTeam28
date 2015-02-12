USE [master]
GO
/****** Object:  Database [BookerDB]    Script Date: 15.6.2014. 15:25:12 ******/
CREATE DATABASE [BookerDB]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'BookerDB', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.MSSQLSERVER\MSSQL\DATA\BookerDB.mdf' , SIZE = 5120KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'BookerDB_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.MSSQLSERVER\MSSQL\DATA\BookerDB_log.ldf' , SIZE = 2048KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [BookerDB] SET COMPATIBILITY_LEVEL = 110
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [BookerDB].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [BookerDB] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [BookerDB] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [BookerDB] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [BookerDB] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [BookerDB] SET ARITHABORT OFF 
GO
ALTER DATABASE [BookerDB] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [BookerDB] SET AUTO_CREATE_STATISTICS ON 
GO
ALTER DATABASE [BookerDB] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [BookerDB] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [BookerDB] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [BookerDB] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [BookerDB] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [BookerDB] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [BookerDB] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [BookerDB] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [BookerDB] SET  DISABLE_BROKER 
GO
ALTER DATABASE [BookerDB] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [BookerDB] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [BookerDB] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [BookerDB] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [BookerDB] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [BookerDB] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [BookerDB] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [BookerDB] SET RECOVERY FULL 
GO
ALTER DATABASE [BookerDB] SET  MULTI_USER 
GO
ALTER DATABASE [BookerDB] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [BookerDB] SET DB_CHAINING OFF 
GO
ALTER DATABASE [BookerDB] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [BookerDB] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
EXEC sys.sp_db_vardecimal_storage_format N'BookerDB', N'ON'
GO
USE [BookerDB]
GO
/****** Object:  Table [dbo].[autor]    Script Date: 15.6.2014. 15:25:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[autor](
	[id_autor] [int] IDENTITY(1,1) NOT NULL,
	[ime] [varchar](20) NOT NULL,
	[prezime] [varchar](50) NOT NULL,
 CONSTRAINT [PK__autor__5FC3872D4B6D740D] PRIMARY KEY CLUSTERED 
(
	[id_autor] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[autori_knjiga]    Script Date: 15.6.2014. 15:25:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[autori_knjiga](
	[id_knjiga_autor] [int] IDENTITY(1,1) NOT NULL,
	[knjigaid_knjiga] [int] NOT NULL,
	[autorid_autor] [int] NOT NULL,
	[datum_upisa] [datetime] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id_knjiga_autor] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[izdavac]    Script Date: 15.6.2014. 15:25:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[izdavac](
	[id_izdavac] [int] IDENTITY(1,1) NOT NULL,
	[naziv] [varchar](30) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id_izdavac] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[knjiga]    Script Date: 15.6.2014. 15:25:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[knjiga](
	[id_knjiga] [int] IDENTITY(1,1) NOT NULL,
	[isbn] [varchar](20) NOT NULL,
	[naslov] [varchar](100) NOT NULL,
	[godina_izdanja] [varchar](5) NOT NULL,
	[tema] [varchar](160) NULL,
	[izdanje] [int] NULL,
	[kolicina] [int] NOT NULL,
	[izdavacid_izdavac] [int] NOT NULL,
	[korisniciid_korisnici] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id_knjiga] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[knjiga_vrsta]    Script Date: 15.6.2014. 15:25:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[knjiga_vrsta](
	[id_knjiga_vrsta] [int] IDENTITY(1,1) NOT NULL,
	[knjigaid_knjiga] [int] NOT NULL,
	[vrstaid_vrsta] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id_knjiga_vrsta] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[komentari]    Script Date: 15.6.2014. 15:25:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[komentari](
	[id_komentar] [int] IDENTITY(1,1) NOT NULL,
	[korisniciid_korisnici] [int] NOT NULL,
	[knjigaid_knjiga] [int] NOT NULL,
	[komentar] [varchar](1000) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id_komentar] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[korisnici]    Script Date: 15.6.2014. 15:25:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[korisnici](
	[id_korisnici] [int] IDENTITY(1,1) NOT NULL,
	[kor_ime] [varchar](20) NOT NULL,
	[lozinka] [varchar](20) NOT NULL,
	[email] [varchar](30) NOT NULL,
	[pravaid_prava] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id_korisnici] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[posudba]    Script Date: 15.6.2014. 15:25:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[posudba](
	[id_posudba] [int] IDENTITY(1,1) NOT NULL,
	[knjigaid_knjiga] [int] NOT NULL,
	[korisniciid_korisnici] [int] NOT NULL,
	[korisniciid_korisnici2] [int] NOT NULL,
	[datum_posudbe] [datetime] NOT NULL,
	[datum_vracanja] [datetime] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id_posudba] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[prava]    Script Date: 15.6.2014. 15:25:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[prava](
	[id_prava] [int] IDENTITY(1,1) NOT NULL,
	[naziv] [varchar](20) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id_prava] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[vrsta]    Script Date: 15.6.2014. 15:25:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[vrsta](
	[id_vrsta] [int] IDENTITY(1,1) NOT NULL,
	[naziv] [varchar](100) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id_vrsta] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
ALTER TABLE [dbo].[autori_knjiga]  WITH CHECK ADD  CONSTRAINT [FKautori_knj317470] FOREIGN KEY([autorid_autor])
REFERENCES [dbo].[autor] ([id_autor])
GO
ALTER TABLE [dbo].[autori_knjiga] CHECK CONSTRAINT [FKautori_knj317470]
GO
ALTER TABLE [dbo].[autori_knjiga]  WITH CHECK ADD  CONSTRAINT [FKautori_knj993339] FOREIGN KEY([knjigaid_knjiga])
REFERENCES [dbo].[knjiga] ([id_knjiga])
GO
ALTER TABLE [dbo].[autori_knjiga] CHECK CONSTRAINT [FKautori_knj993339]
GO
ALTER TABLE [dbo].[knjiga]  WITH CHECK ADD  CONSTRAINT [FKknjiga49108] FOREIGN KEY([korisniciid_korisnici])
REFERENCES [dbo].[korisnici] ([id_korisnici])
GO
ALTER TABLE [dbo].[knjiga] CHECK CONSTRAINT [FKknjiga49108]
GO
ALTER TABLE [dbo].[knjiga]  WITH CHECK ADD  CONSTRAINT [FKknjiga573149] FOREIGN KEY([izdavacid_izdavac])
REFERENCES [dbo].[izdavac] ([id_izdavac])
GO
ALTER TABLE [dbo].[knjiga] CHECK CONSTRAINT [FKknjiga573149]
GO
ALTER TABLE [dbo].[knjiga_vrsta]  WITH CHECK ADD  CONSTRAINT [FKknjiga_vrs495553] FOREIGN KEY([knjigaid_knjiga])
REFERENCES [dbo].[knjiga] ([id_knjiga])
GO
ALTER TABLE [dbo].[knjiga_vrsta] CHECK CONSTRAINT [FKknjiga_vrs495553]
GO
ALTER TABLE [dbo].[knjiga_vrsta]  WITH CHECK ADD  CONSTRAINT [FKknjiga_vrs651193] FOREIGN KEY([vrstaid_vrsta])
REFERENCES [dbo].[vrsta] ([id_vrsta])
GO
ALTER TABLE [dbo].[knjiga_vrsta] CHECK CONSTRAINT [FKknjiga_vrs651193]
GO
ALTER TABLE [dbo].[komentari]  WITH CHECK ADD  CONSTRAINT [FKkomentari409049] FOREIGN KEY([korisniciid_korisnici])
REFERENCES [dbo].[korisnici] ([id_korisnici])
GO
ALTER TABLE [dbo].[komentari] CHECK CONSTRAINT [FKkomentari409049]
GO
ALTER TABLE [dbo].[komentari]  WITH CHECK ADD  CONSTRAINT [FKkomentari484522] FOREIGN KEY([knjigaid_knjiga])
REFERENCES [dbo].[knjiga] ([id_knjiga])
GO
ALTER TABLE [dbo].[komentari] CHECK CONSTRAINT [FKkomentari484522]
GO
ALTER TABLE [dbo].[korisnici]  WITH CHECK ADD  CONSTRAINT [FKkorisnici944314] FOREIGN KEY([pravaid_prava])
REFERENCES [dbo].[prava] ([id_prava])
GO
ALTER TABLE [dbo].[korisnici] CHECK CONSTRAINT [FKkorisnici944314]
GO
ALTER TABLE [dbo].[posudba]  WITH CHECK ADD  CONSTRAINT [FKposudba426958] FOREIGN KEY([korisniciid_korisnici])
REFERENCES [dbo].[korisnici] ([id_korisnici])
GO
ALTER TABLE [dbo].[posudba] CHECK CONSTRAINT [FKposudba426958]
GO
ALTER TABLE [dbo].[posudba]  WITH CHECK ADD  CONSTRAINT [FKposudba587068] FOREIGN KEY([korisniciid_korisnici2])
REFERENCES [dbo].[korisnici] ([id_korisnici])
GO
ALTER TABLE [dbo].[posudba] CHECK CONSTRAINT [FKposudba587068]
GO
ALTER TABLE [dbo].[posudba]  WITH CHECK ADD  CONSTRAINT [FKposudba648514] FOREIGN KEY([knjigaid_knjiga])
REFERENCES [dbo].[knjiga] ([id_knjiga])
GO
ALTER TABLE [dbo].[posudba] CHECK CONSTRAINT [FKposudba648514]
GO
USE [master]
GO
ALTER DATABASE [BookerDB] SET  READ_WRITE 
GO
