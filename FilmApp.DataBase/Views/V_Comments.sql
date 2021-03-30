CREATE VIEW [dbo].[V_Comments]
	AS SELECT * from [Comments] where [Disable_at] is null;
