CREATE TABLE [mfk].[Process] (
    [ID]                    INT            IDENTITY (1, 1) NOT NULL,
    [OriginID]       INT            NOT NULL,
    [Version]               INT            CONSTRAINT [DF_Process_Version] DEFAULT ((1)) NOT NULL,
    [PreviusVersionID]      INT            NULL,
    [CreateDate]            DATETIME       CONSTRAINT [DF_Process_CreateDate] DEFAULT (getdate()) NOT NULL,
    [AcceptDate]            DATETIME       NULL,
    [Name]                  NVARCHAR (300) NULL,
    [EnterpriseID]          NVARCHAR (50)  NULL,
    [Removed]               BIT            CONSTRAINT [DF_Process_Removed] DEFAULT ((0)) NOT NULL,
    [State]                 INT            NOT NULL,
    [OwnerID]               INT            NULL,
    [OwnerOrganisationUnit] NVARCHAR (200) NULL,
    [Substantial]           BIT            NOT NULL,
    CONSTRAINT [PK_Process] PRIMARY KEY CLUSTERED ([ID] ASC),
    CONSTRAINT [FK_Process_PreviusVersion] FOREIGN KEY ([PreviusVersionID]) REFERENCES [mfk].[Process] ([ID]),
    CONSTRAINT [FK_Process_Origin] FOREIGN KEY ([OriginID]) REFERENCES [mfk].[Origin] ([ID])
);



