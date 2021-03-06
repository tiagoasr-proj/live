USE [GerenciadorLives]
GO
/****** Object:  Table [dbo].[Inscricoes]    Script Date: 01/03/2021 15:19:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Inscricoes](
	[InscricaoId] [int] IDENTITY(1,1) NOT NULL,
	[LiveId] [int] NOT NULL,
	[InscritoId] [int] NOT NULL,
	[StatusPagamento] [bit] NOT NULL,
	[ValorInscricao] [decimal](10, 2) NULL,
	[DataVencimento] [smalldatetime] NULL,
 CONSTRAINT [PK_Inscricoes] PRIMARY KEY CLUSTERED 
(
	[InscricaoId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Inscricoes] ON 

INSERT [dbo].[Inscricoes] ([InscricaoId], [LiveId], [InscritoId], [StatusPagamento], [ValorInscricao], [DataVencimento]) VALUES (6, 1, 1, 1, CAST(500.00 AS Decimal(10, 2)), CAST(N'2021-03-30T20:00:00' AS SmallDateTime))
INSERT [dbo].[Inscricoes] ([InscricaoId], [LiveId], [InscritoId], [StatusPagamento], [ValorInscricao], [DataVencimento]) VALUES (7, 2, 2, 0, CAST(500.00 AS Decimal(10, 2)), CAST(N'2021-02-27T00:00:00' AS SmallDateTime))
SET IDENTITY_INSERT [dbo].[Inscricoes] OFF
GO
ALTER TABLE [dbo].[Inscricoes]  WITH CHECK ADD  CONSTRAINT [FK_Inscricoes_Inscritos_InscritoId] FOREIGN KEY([InscritoId])
REFERENCES [dbo].[Inscritos] ([InscritoId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Inscricoes] CHECK CONSTRAINT [FK_Inscricoes_Inscritos_InscritoId]
GO
ALTER TABLE [dbo].[Inscricoes]  WITH CHECK ADD  CONSTRAINT [FK_Inscricoes_Lives_LiveId] FOREIGN KEY([LiveId])
REFERENCES [dbo].[Lives] ([LiveId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Inscricoes] CHECK CONSTRAINT [FK_Inscricoes_Lives_LiveId]
GO
