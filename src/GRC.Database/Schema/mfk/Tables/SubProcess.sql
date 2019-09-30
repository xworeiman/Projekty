CREATE TABLE [mfk].[SubProcess] (
    [ID]                    INT            IDENTITY (100000, 1) NOT NULL,
    [ParentID]             INT            NOT NULL,
    [OriginID]       INT            NOT NULL,
    [Version]               INT            CONSTRAINT [DF_SubProcess_Version] DEFAULT ((1)) NOT NULL,
    [PreviusVersionID]      INT            NULL,
    [CreateDate]            DATETIME       CONSTRAINT [DF_SubProcess_CreateDate] DEFAULT (getdate()) NOT NULL,
    [ModyfiDate]            DATETIME       CONSTRAINT [DF_SubProcess_ModyfiDate] DEFAULT (getdate()) NOT NULL,
    [Name]                  NVARCHAR (300) NULL,
    [EnterpriseID]          NVARCHAR (50)  NULL,
    [Removed]               BIT            CONSTRAINT [DF_SubProcess_Removed] DEFAULT ((0)) NOT NULL,
    [State]                 INT            NOT NULL,
    [OwnerID]               INT            NULL,
    [OwnerOrganisationUnit] NVARCHAR (200) NULL,
    CONSTRAINT [PK_SubProcess] PRIMARY KEY CLUSTERED ([ID] ASC),
    CONSTRAINT [FK_SubProcess_Process] FOREIGN KEY ([ParentID]) REFERENCES [mfk].[Process] ([ID]),
    CONSTRAINT [FK_SubProcess_Origin] FOREIGN KEY ([OriginID]) REFERENCES [mfk].[Origin] ([ID]),
    CONSTRAINT [FK_SubProcess_SubProcess] FOREIGN KEY ([PreviusVersionID]) REFERENCES [mfk].[SubProcess] ([ID])
);



