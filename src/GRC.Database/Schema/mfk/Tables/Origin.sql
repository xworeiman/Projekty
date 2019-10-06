CREATE TABLE [mfk].[Origin] (
    [ID] INT NOT NULL,
    CONSTRAINT [PK_Origin] PRIMARY KEY CLUSTERED ([ID] ASC)
);
GO  
  
-- Add a default value for the DepartmentID column  
ALTER TABLE [mfk].[Origin] 
ADD CONSTRAINT [DF_Origin_ID] DEFAULT (NEXT VALUE FOR [mfk].[OriginPK]) FOR [ID];
