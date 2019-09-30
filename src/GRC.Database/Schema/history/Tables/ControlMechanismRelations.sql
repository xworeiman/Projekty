CREATE TABLE [history].[ControlMechanismRelations] (
    [ID]                 INT           NOT NULL,
    [OriginID]    INT           NOT NULL,
    [ControlMechanizmID] INT           NOT NULL,
    [ProcessID]          INT           NULL,
    [SubProcessID]       INT           NULL,
    [StageID]            INT           NULL,
    [Version]            INT           NOT NULL,
    [PreviusVersionID]   INT           NULL,
    [CreateDate]         DATETIME      NOT NULL,
    [Removed]            BIT           NOT NULL,
    [SysStartTime]       DATETIME2 (0) NOT NULL,
    [SysEndTime]         DATETIME2 (0) NOT NULL
);


GO
CREATE CLUSTERED INDEX [ix_ControlMechanismRelations]
    ON [history].[ControlMechanismRelations]([SysEndTime] ASC, [SysStartTime] ASC);

