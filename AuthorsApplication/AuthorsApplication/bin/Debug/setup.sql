CREATE or ALTER PROCEDURE proc_ainfo
@au_id varchar(11)
,@address varchar(40)
,@city varchar(20)
,@state char(2)
,@zip char(5)
AS
BEGIN 
	DECLARE @returnValue int
		,@ERR_MSG AS NVARCHAR(4000) 
		,@ERR_STA AS SMALLINT 

	SET @returnValue = 0
	SET NOCOUNT ON
	BEGIN TRY
		UPDATE dbo.authors 
			SET address = @address,
				city = @city,
				state = @state,
				zip = @zip
			WHERE au_id = @au_id
		IF @@ROWCOUNT = 0
		  THROW 50001, 'No authors updated', 1
		SET @returnValue = 0 --it worked
	END TRY
	BEGIN CATCH
		 SELECT @ERR_MSG = ERROR_MESSAGE(),
		 @ERR_STA = ERROR_STATE()
 
		 SET @ERR_MSG= 'Error occurred while updating the database: ' + @ERR_MSG;
 
		 THROW 50001, @ERR_MSG, @ERR_STA;
		 SET @returnValue = 1
	END CATCH
	RETURN @returnValue
END