/****** Object:  Table [dbo].[Customers]    Script Date: 6/8/2014 2:10:51 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[Customers](
	[CustomerId] [int] NOT NULL,
	[Name] [varchar](100) NOT NULL,
	[Country] [varchar](50) NOT NULL
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

INSERT INTO Customers
SELECT 1, 'John Hammond', 'United States'
UNION ALL
SELECT 2, 'Mudassar Khan', 'India'
UNION ALL
SELECT 3, 'Suzanne Mathews', 'France'
UNION ALL
SELECT 4, 'Robert Schidner', 'Russia'