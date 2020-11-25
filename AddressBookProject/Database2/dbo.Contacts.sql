CREATE TABLE [dbo].Contacts
(
	[ContactID] INT NOT NULL IDENTITY(1, 1) PRIMARY KEY, 
	[FirstName] NVARCHAR(50) NULL, 
	[LastName] NVARCHAR(50) NULL, 
	[PhoneNumber] NVARCHAR(50) NULL, 
	[Address] NVARCHAR(50) NULL, 
	[Email] NVARCHAR(50) NULL 
)

GO
