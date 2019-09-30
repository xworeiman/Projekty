CREATE TABLE [mfk].[Stage] (
    [ID]                    INT            IDENTITY (1000000, 1) NOT NULL,
    [ParentID]             INT            NOT NULL,
    [OriginID]       INT            NOT NULL,
    [Version]               INT            CONSTRAINT [DF_Stage_Version] DEFAULT ((1)) NOT NULL,
    [PreviusVersionID]      INT            NULL,
    [CreateDate]            DATETIME       CONSTRAINT [DF_Stage_CreateDate] DEFAULT (getdate()) NOT NULL,
    [ModyfiDate]            DATETIME       CONSTRAINT [DF_Stage_ModyfiDate] DEFAULT (getdate()) NOT NULL,
    [Name]                  NVARCHAR (300) NULL,
    [EnterpriseID]          NVARCHAR (50)  NULL,
    [Removed]               BIT            CONSTRAINT [DF_Stage_Removed] DEFAULT ((0)) NOT NULL,
    [State]                 INT            NOT NULL,
    [OwnerID]               INT            NULL,
    [OwnerOrganisationUnit] NVARCHAR (200) NULL,
    CONSTRAINT [PK_Stage] PRIMARY KEY CLUSTERED ([ID] ASC),
    CONSTRAINT [FK_Stage_Origin] FOREIGN KEY ([OriginID]) REFERENCES [mfk].[Origin] ([ID]),
    CONSTRAINT [FK_Stage_Stage] FOREIGN KEY ([PreviusVersionID]) REFERENCES [mfk].[Stage] ([ID]),
    CONSTRAINT [FK_Stage_SubProcess] FOREIGN KEY ([ParentID]) REFERENCES [mfk].[SubProcess] ([ID])
);



