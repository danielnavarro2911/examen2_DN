USE [examen2]
GO
/****** Object:  Table [dbo].[partido]    Script Date: 7/22/2024 8:21:12 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[partido](
	[ID] [int] IDENTITY(100,1) NOT NULL,
	[nombre_partido] [varchar](50) NOT NULL,
	[nombre_candidato] [varchar](50) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[votos]    Script Date: 7/22/2024 8:21:12 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[votos](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[fecha_voto] [date] NOT NULL,
	[nombre_partido] [varchar](255) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  View [dbo].[VotosPorPartido2]    Script Date: 7/22/2024 8:21:12 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[VotosPorPartido2] AS
SELECT 
    p.nombre_partido,
    COUNT(v.ID) AS total_votos
FROM 
    votos v
INNER JOIN 
    partido p ON v.nombre_partido = p.nombre_partido
GROUP BY 
    p.nombre_partido;
GO
ALTER TABLE [dbo].[votos] ADD  DEFAULT (getdate()) FOR [fecha_voto]
GO
