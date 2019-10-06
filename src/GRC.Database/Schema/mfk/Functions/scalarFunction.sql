CREATE FUNCTION [mfk].[scalarFunction]
(
	@processID int
)
RETURNS BIT
AS
BEGIN
	DECLARE @ret bit = 0;
	SELECT @ret = 1 
	FROM [mfk].[Process] p
	WHERE ID = @processID AND EXISTS(
		SELECT 1 FROM [mfk].[ControlMechanism] cm WHERE cm.OriginID = p.OriginID);
	
	RETURN @ret;
END
