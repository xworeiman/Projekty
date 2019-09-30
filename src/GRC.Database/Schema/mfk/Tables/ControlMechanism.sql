CREATE TABLE [mfk].[ControlMechanism] (
    [ID]                    INT            IDENTITY (1, 1) NOT NULL,
    [OriginID]       INT            NOT NULL,
    [Version]               INT            CONSTRAINT [DF_ControlMechanism_Version] DEFAULT ((1)) NOT NULL,
    [PreviusVersionID]      INT            NULL,
    [CreateDate]            DATETIME       CONSTRAINT [DF_ControlMechanism_CreateDate] DEFAULT (getdate()) NOT NULL,
    [ModyfiDate]            DATETIME       CONSTRAINT [DF_ControlMechanism_ModyfiDate] DEFAULT (getdate()) NOT NULL,
    [Name]                  NVARCHAR (300) NULL,
    [EnterpriseID]          NVARCHAR (50)  NULL,
    [Removed]               BIT            CONSTRAINT [DF_ControlMechanism_Removed] DEFAULT ((0)) NOT NULL,
    [State]                 INT            NOT NULL,
    [OwnerID]               INT            NULL,
    [OwnerOrganisationUnit] NVARCHAR (200) NULL,
    [Critical]              BIT            NOT NULL,
    [Monitored]             BIT            NOT NULL,
    CONSTRAINT [PK_ControlMechanism] PRIMARY KEY CLUSTERED ([ID] ASC),
    CONSTRAINT [FK_ControlMechanism_ControlMechanism] FOREIGN KEY ([PreviusVersionID]) REFERENCES [mfk].[ControlMechanism] ([ID]),
    CONSTRAINT [FK_ControlMechanism_Origin] FOREIGN KEY ([OriginID]) REFERENCES [mfk].[Origin] ([ID])
);



