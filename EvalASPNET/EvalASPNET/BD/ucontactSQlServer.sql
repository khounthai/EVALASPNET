USE [ucontact]
GO
/****** Object:  Table [dbo].[CHAMP]    Script Date: 14/04/2018 16:02:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CHAMP](
	[idchamp] [int] NOT NULL,
	[libelle] [varchar](50) NULL,
 CONSTRAINT [PK_CHAMP] PRIMARY KEY CLUSTERED 
(
	[idchamp] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CONTACT]    Script Date: 14/04/2018 16:02:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CONTACT](
	[idcontact] [int] NOT NULL,
	[iduser] [int] NOT NULL,
	[Civilite] [varchar](10) NULL,
	[Nom] [varchar](255) NULL,
	[Prenom] [varchar](255) NULL,
	[DateNaissance] [date] NULL,
	[Adresse] [varchar](255) NULL,
	[CP] [varchar](255) NULL,
	[Ville] [varchar](255) NULL,
	[Pays] [varchar](255) NULL,
	[Telephone] [varchar](255) NULL,
	[Portable] [varchar](255) NULL,
	[Email] [varchar](255) NULL,
 CONSTRAINT [PK_CONTACT] PRIMARY KEY CLUSTERED 
(
	[idcontact] ASC,
	[iduser] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DONNEE]    Script Date: 14/04/2018 16:02:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DONNEE](
	[iddonnee] [int] NOT NULL,
	[iduser] [int] NOT NULL,
	[idcontact] [int] NOT NULL,
	[libellechamp] [varchar](50) NULL,
	[valeur] [varchar](255) NULL,
	[ordre] [int] NULL,
	[accueil] [bit] NULL,
 CONSTRAINT [PK_DONNEE] PRIMARY KEY CLUSTERED 
(
	[iddonnee] ASC,
	[iduser] ASC,
	[idcontact] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[USER]    Script Date: 14/04/2018 16:02:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[USER](
	[iduser] [int] NOT NULL,
	[login] [varchar](50) NULL,
	[password] [varchar](255) NULL,
PRIMARY KEY CLUSTERED 
(
	[iduser] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  View [dbo].[VueChamp]    Script Date: 14/04/2018 16:02:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[VueChamp]
AS
SELECT DISTINCT TOP (100) PERCENT libellechamp, ordre
FROM            dbo.DONNEE
ORDER BY ordre
GO
ALTER TABLE [dbo].[DONNEE] ADD  CONSTRAINT [DF_DONNEE_ordre]  DEFAULT ((0)) FOR [ordre]
GO
ALTER TABLE [dbo].[DONNEE] ADD  CONSTRAINT [DF_DONNEE_accueil]  DEFAULT ((1)) FOR [accueil]
GO
ALTER TABLE [dbo].[CONTACT]  WITH CHECK ADD  CONSTRAINT [FK_CONTACT_USER] FOREIGN KEY([iduser])
REFERENCES [dbo].[USER] ([iduser])
GO
ALTER TABLE [dbo].[CONTACT] CHECK CONSTRAINT [FK_CONTACT_USER]
GO
/****** Object:  StoredProcedure [dbo].[deleteContact]    Script Date: 14/04/2018 16:02:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[deleteContact]
	-- Add the parameters for the stored procedure here
	@iduser	int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	DELETE 
	FROM [ucontact].[dbo].[CONTACT]
	WHERE iduser=@iduser;		
END
GO
/****** Object:  StoredProcedure [dbo].[deleteContactByID]    Script Date: 14/04/2018 16:02:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[deleteContactByID]
	-- Add the parameters for the stored procedure here
	@idcontact	int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	DELETE 
	FROM [ucontact].[dbo].[CONTACT]
	WHERE idcontact=@idcontact;		
END
GO
/****** Object:  StoredProcedure [dbo].[GetChamps]    Script Date: 14/04/2018 16:02:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[GetChamps]	
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT idchamp,libelle from CHAMP;
		
END
GO
/****** Object:  StoredProcedure [dbo].[GetUser]    Script Date: 14/04/2018 16:02:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetUser]
	-- Add the parameters for the stored procedure here
	@iduser	int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT [iduser]
      ,[login]
      ,[password]
	FROM [ucontact].[dbo].[USER]
	WHERE iduser=@iduser;
		
END
GO
/****** Object:  StoredProcedure [dbo].[GetUserBYLoginAndPassword]    Script Date: 14/04/2018 16:02:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetUserBYLoginAndPassword]
	-- Add the parameters for the stored procedure here
	@login		varchar(255),
	@password	varchar(255)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT [iduser]
      ,[login]
      ,[password]
	FROM [ucontact].[dbo].[USER]
	WHERE login=@login and password=@password;
		
END
GO
/****** Object:  StoredProcedure [dbo].[saveChamp]    Script Date: 14/04/2018 16:02:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[saveChamp]
	@idchamp	int=0,
	@libelle	varchar(50)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	IF exists (select idchamp from CHAMP where idchamp=@idchamp) 
		update CHAMP set libelle=@libelle where idchamp=@idchamp;
	ELSE
		insert into CHAMP (idchamp,libelle) values (@idchamp,@libelle);	
END
GO
/****** Object:  StoredProcedure [dbo].[saveContact]    Script Date: 14/04/2018 16:02:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[saveContact] 
	-- Add the parameters for the stored procedure here
	@idcontact		int,
	@iduser			int,
	@libellechamp	varchar(50)=null,
	@valeur		varchar(255)=null
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	if not exists(select idcontact from CONTACT where idcontact=@idcontact and iduser=@iduser)
		insert into CONTACT (idcontact,iduser) values (@idcontact,@iduser);

	if (@libellechamp ='Civilite')
		update CONTACT set civilite=@valeur where idcontact=@idcontact and iduser=@iduser;

	if (@libellechamp ='Nom')
		update CONTACT set Nom=@valeur where idcontact=@idcontact and iduser=@iduser;

	if (@libellechamp ='Prénom')
		update CONTACT set Prenom=@valeur where idcontact=@idcontact and iduser=@iduser;

	if (@libellechamp ='Date de naissance')
		update CONTACT set DateNaissance=Convert(date,Convert(datetime,@valeur,110)) where idcontact=@idcontact and iduser=@iduser;

	if (@libellechamp ='Adresse')
		update CONTACT set Adresse=@valeur where idcontact=@idcontact and iduser=@iduser;

	if (@libellechamp ='CP')
		update CONTACT set CP=@valeur where idcontact=@idcontact and iduser=@iduser;
	
	if (@libellechamp ='Ville')		
		update CONTACT set Ville=@valeur where idcontact=@idcontact and iduser=@iduser;

	if (@libellechamp ='Pays')		
		update CONTACT set Pays=@valeur where idcontact=@idcontact and iduser=@iduser;

	if (@libellechamp ='Telephone')		
		update CONTACT set Telephone=@valeur where idcontact=@idcontact and iduser=@iduser;

	if (@libellechamp ='Portable')		
		update CONTACT set Portable=@valeur where idcontact=@idcontact and iduser=@iduser;

	if (@libellechamp ='Email')		
		update CONTACT set Email=@valeur where idcontact=@idcontact and iduser=@iduser;

END
GO
/****** Object:  StoredProcedure [dbo].[SaveUser]    Script Date: 14/04/2018 16:02:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[SaveUser]
	-- Add the parameters for the stored procedure here
	@iduser int=0,
	@login varchar(255)=null,
	@password varchar(255)=null
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	IF exists (select iduser from [dbo].[USER] where iduser=@iduser) 
		update [dbo].[USER] set login=@login, password=@password where iduser=@iduser;
	ELSE
		insert into [dbo].[USER] (iduser,login,password) values (@iduser,@login,@password);	
END
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[40] 4[20] 2[20] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "DONNEE"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 281
               Right = 453
            End
            DisplayFlags = 280
            TopColumn = 0
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
      Begin ColumnWidths = 9
         Width = 284
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 1440
         Alias = 900
         Table = 1170
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'VueChamp'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=1 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'VueChamp'
GO
