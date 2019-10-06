CREATE FUNCTION [mfk].[tableFunction]
(
	@processID int 
)
RETURNS @returntable TABLE
(
	ContainsCM bit
)
AS
BEGIN
	INSERT @returntable
	SELECT ContainsCM = CONVERT(BIT, 1)
	FROM [mfk].[Process] p 
	WHERE ID = @processID AND EXISTS (
		SELECT 1 FROM [mfk].[ControlMechanism] cm WHERE cm.OriginID = p.OriginID
	)
	RETURN
END
