CREATE TABLE [dbo].[Groups] (
    [GroupID]      INT             IDENTITY (1, 1) NOT NULL,
    [GroupName]    NVARCHAR (50)   NULL,
    [ContactID] VARBINARY(MAX) NULL,
    [ContactName] VARBINARY(MAX) NULL, 
    PRIMARY KEY CLUSTERED ([GroupID] ASC)
);

