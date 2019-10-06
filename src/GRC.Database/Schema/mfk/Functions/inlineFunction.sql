CREATE FUNCTION [mfk].[inlineFunction]
(
	@processID int
)
RETURNS TABLE AS RETURN
(
	SELECT ContainsCM = CONVERT(BIT, 1)
	FROM [mfk].[Process] p 
	WHERE ID = @processID AND EXISTS (
		SELECT 1 FROM [mfk].[ControlMechanism] cm WHERE cm.OriginID = p.OriginID
	)
)
