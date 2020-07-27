Create Table [dbo].[BookItems]
(
	[Id] int IDENTITY(1,1),
	[Title] nvarchar(100),
	[Author] nvarchar(100),
	[Publisher] nvarchar(100),
	[Genre] nvarchar(100),
	[Price] int
	PRIMARY KEY(Id)
);