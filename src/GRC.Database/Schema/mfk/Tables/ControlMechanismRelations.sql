CREATE TABLE [mfk].[ControlMechanismRelations] (
    [ID]                 INT                                                IDENTITY (1, 1) NOT NULL,
    [OriginID]    INT                                                NOT NULL,
    [ControlMechanizmID] INT                                                NOT NULL,
    [ProcessID]          INT                                                NULL,
    [SubProcessID]       INT                                                NULL,
    [StageID]            INT                                                NULL,
    [Version]            INT                                                CONSTRAINT [DF_ControlMechanismRelations_Version] DEFAULT ((1)) NOT NULL,
    [PreviusVersionID]   INT                                                NULL,
    [CreateDate]         DATETIME                                           CONSTRAINT [DF_ControlMechanismRelations_CreateDate] DEFAULT (getdate()) NOT NULL,
    [Removed]            BIT                                                CONSTRAINT [DF_ControlMechanismRelations_Removed] DEFAULT ((0)) NOT NULL,
    [SysStartTime]       DATETIME2 (0) GENERATED ALWAYS AS ROW START HIDDEN NOT NULL,
    [SysEndTime]         DATETIME2 (0) GENERATED ALWAYS AS ROW END HIDDEN   NOT NULL,
	CONSTRAINT [CHK_ControlMechanismRelation] CHECK ([ProcessID] IS NOT NULL OR [SubProcessID] IS NOT NULL OR [StageID] IS NOT NULL),
    CONSTRAINT [PK_ControlMechanismRelation] PRIMARY KEY CLUSTERED ([ID] ASC),
    CONSTRAINT [FK_ControlMechanismRelations_ControlMechanism] FOREIGN KEY ([ControlMechanizmID]) REFERENCES [mfk].[ControlMechanism] ([ID]),
    CONSTRAINT [FK_ControlMechanismRelations_ControlMechanismRelations] FOREIGN KEY ([PreviusVersionID]) REFERENCES [mfk].[ControlMechanismRelations] ([ID]),
    CONSTRAINT [FK_ControlMechanismRelations_Process] FOREIGN KEY ([ProcessID]) REFERENCES [mfk].[Process] ([ID]),
    CONSTRAINT [FK_ControlMechanismRelations_Origin] FOREIGN KEY ([OriginID]) REFERENCES [mfk].[Origin] ([ID]),
    CONSTRAINT [FK_ControlMechanismRelations_Stage] FOREIGN KEY ([StageID]) REFERENCES [mfk].[Stage] ([ID]),
    CONSTRAINT [FK_ControlMechanismRelations_SubProcess] FOREIGN KEY ([SubProcessID]) REFERENCES [mfk].[SubProcess] ([ID]),
    PERIOD FOR SYSTEM_TIME ([SysStartTime], [SysEndTime])
)
WITH (SYSTEM_VERSIONING = ON (HISTORY_TABLE=[history].[ControlMechanismRelations], DATA_CONSISTENCY_CHECK=ON));

GO
CREATE UNIQUE NONCLUSTERED INDEX [UIX_ControlMechanismRelations] ON [mfk].[ControlMechanismRelations]
(
	[ControlMechanizmID] ASC,
	[ProcessID] ASC,
	[SubProcessID] ASC,
	[StageID] ASC,
	[Version] ASC
) 
GO
--
    



