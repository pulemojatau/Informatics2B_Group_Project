CREATE TABLE [dbo].[User]
(
	[Id]        INT           IDENTITY (1, 1) NOT NULL,
    [FirstName] VARCHAR (50)  NOT NULL,
    [Surname]   VARCHAR (50)  NOT NULL,
    [Email]     VARCHAR (50)  NOT NULL,
    [Password]  VARCHAR (MAX) NOT NULL,
    [UserType]  VARCHAR (10)  NOT NULL,
    [Username]  VARCHAR (15)  NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
)
