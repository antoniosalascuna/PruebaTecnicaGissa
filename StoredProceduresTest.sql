/****** Script for SelectTopNRows command from SSMS  ******/
CREATE PROC test_sp_ResgistrarUsuario(
@USER_LastName varchar(50),
@USER_NickName varchar(50),
@USER_UserType varchar(1),
@USER_Type_Ced varchar(1),
@USER_Ced varchar(50),
@USER_Pass varchar(100),
@USER_Email varchar(50),
@Message varchar(100) output,

)
AS
BEGIN
    /*VALIDO SI NO EXISTE UN USUARIO YA CREADO CON ESTE NICKNAME*/
IF(NOT EXISTS(SELECT * FROM dbo.test_user WHERE test_user.USER_NickName = @USER_NickName ))
		BEGIN 
			INSERT INTO dbo.test_user (USER_LastName, USER_NickName, USER_UserType, USER_Type_Ced, USER_Ced, USER_Pass, USER_Email) VALUES(@USER_LastName, @USER_NickName, @USER_UserType, @USER_Type_Ced, @USER_Ced, @USER_Pass, @USER_Email)
			SET @Message = 'Usuario Registrado con exito'
		END
		ELSE 
		BEGIN
			SET @Message = 'Usuario no Registrado' 
		END
	
END

DECLARE @Message varchar(100)

EXEC test_sp_ResgistrarUsuario 'Antonio','ASalas02','C','N','604400332','machines1','antoniosalas1996@gmail.com', @Message output

Select @Message


Alter PROC test_sp_ValidarUsuario(
@USER_NickName varchar(50),
@USER_Pass varchar(20)
)
AS 
BEGIN
	
  IF (EXISTS (SELECT *FROM test_user  WHERE test_user.USER_Nickname = @USER_NickName and test_user.USER_Pass = @USER_Pass))
			SELECT USER_UserType FROM  test_user WHERE test_user.USER_Nickname = @USER_NickName and test_user.USER_Pass = @USER_Pass 
			
  ELSE 
	SELECT '0'
END



DECLARE @User_Type varchar(20)
EXEC test_sp_ValidarUsuario 'ASalas','machines1'


Select @User_Type

