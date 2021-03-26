CREATE VIEW [dbo].[V_MoviesComplete]
	AS SELECT m.*, s.FirstName + s.LastName as ScriptWriter, r.FirstName + r.LastName as Director FROM [Movies] m join [Staff] s on m.ScriptWriterId = s.Id join [Staff] r on m.DirectorId = r.Id 
