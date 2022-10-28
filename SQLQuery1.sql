USE Dotnet_Core_Training

--=========================================================
--Author- Pranav G
--Creation date- 18/10/2022
--Description- Table to store login credentials of a user
--=========================================================
CREATE TABLE USER_LOGIN
(
    ID INT PRIMARY KEY IDENTITY(1,1),
    USERNAME VARCHAR(8),
    PASSWORD INT
    
)

INSERT INTO USER_LOGIN
VALUES
(
  'Admin',12345
)
SELECT * FROM USER_LOGIN

DROP TABLE USER_LOGIN

--=========================================================
--Author- Pranav G
--Creation date- 18/10/2022
--Description- Table to store details of a user
--=========================================================

CREATE TABLE USER_DETAILS
(
    USER_ID INT  IDENTITY(1,1),
    NAME VARCHAR(50),
    EMAIL VARCHAR(50),
    ADDRESS VARCHAR(50),
    PHONE_NUMBER VARCHAR(10)
     constraint CK_USER_LOGIN_PHONE_NUMBER check (PHONE_NUMBER like '[0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9]'),
    FOREIGN KEY (USER_ID) REFERENCES USER_LOGIN(ID)
)

SELECT * FROM USER_DETAILS

DROP TABLE USER_DETAILS

INSERT INTO USER_DETAILS
VALUES('Admin','admin@gmail.com','kollam',9876543210)

--===================================================
--Author- Aparna K V
--Creation date- 18/10/2022
--Description- SP to get the list of all the users
--====================================================

CREATE PROCEDURE SP_GET_ALL_USERS
AS
    SELECT USER_ID,NAME,EMAIL,ADDRESS,PHONE_NUMBER
    FROM USER_DETAILS
GO

EXEC SP_GET_ALL_USERS

DROP PROCEDURE SP_GET_ALL_USERS
--===================================================
--Author- Aparna K V
--Creation date- 18/10/2022
--Description- SP to get the details of a user by ID
--===================================================
CREATE PROCEDURE SP_GET_USER_DETAILS
(
    @ID INT
)
AS
    SELECT USER_ID,NAME,EMAIL,ADDRESS,PHONE_NUMBER
    FROM USER_DETAILS
    WHERE  USER_ID=@ID
GO

EXEC SP_GET_USER_DETAILS 1
DROP PROCEDURE SP_GET_USER_DETAILS
--============================================
--Author- Melwen T Abraham
--Creation date- 18/10/2022
--Description- SP to insert a new user
--=============================================
CREATE PROCEDURE SP_CREATE_USER
(
    @NAME VARCHAR(50),
    @EMAIL VARCHAR(50),
    @ADDRESS VARCHAR(50),
    @PHONE_NUMBER VARCHAR(10),
    @USER_NAME VARCHAR(50),
    @PASSWORD INT
)
AS
    INSERT INTO USER_LOGIN(USERNAME,PASSWORD)
    VALUES(@USER_NAME,@PASSWORD)

   INSERT INTO USER_DETAILS(NAME, EMAIL, ADDRESS, PHONE_NUMBER)
    VALUES (@NAME,@EMAIL,@ADDRESS,@PHONE_NUMBER)
GO
EXEC SP_CREATE_USER ammu,'ammu@gmail.com',tvm,6894532237,ammus,4567

DROP PROCEDURE SP_CREATE_USER
--============================================
--Author- Anitta Thomas
--Creation date- 18/10/2022
--Description- SP to update user details
--=============================================
CREATE PROCEDURE SP_UPDATE_USER
(
    @ID INT,
    @NAME VARCHAR(50),
    @EMAIL VARCHAR(50),
    @ADDRESS VARCHAR(50),
    @PHONE_NUMBER VARCHAR(10)
)
AS
    UPDATE USER_DETAILS
    SET NAME=@NAME,EMAIL=@EMAIL,ADDRESS=@ADDRESS,PHONE_NUMBER=@PHONE_NUMBER
    WHERE USER_ID=@ID    
GO
EXEC SP_UPDATE_USER 6,QWERT,'efg@gmail.com',tvm,4576654783

DROP PROCEDURE SP_UPDATE_USER
--==============================================
--Author- Sona Mariya Baby
--Creation date- 18/10/2022
--Description- SP to delete a user from the list
--===============================================
CREATE PROCEDURE SP_DELETE_USER
(
    @ID INT
)
AS
    DELETE FROM USER_DETAILS WHERE USER_ID=@ID
    DELETE FROM USER_LOGIN WHERE ID=@ID
GO

EXEC SP_DELETE_USER 2
DROP PROCEDURE SP_DELETE_USER
SELECT * FROM USER_LOGIN
--=============================================================================
--Author- Sona Mariya Baby
--Creation date- 18/10/2022
--Description- SP to get the details of user while login if the user exist
--=============================================================================
CREATE PROCEDURE SP_GET_USER_LOGIN
(
    @USER_NAME VARCHAR(50),
    @PASSWORD VARCHAR(50)
)
AS
    SELECT USER_ID,USERNAME,PASSWORD,NAME,EMAIL,ADDRESS,PHONE_NUMBER
    FROM USER_DETAILS INNER JOIN USER_LOGIN
    ON USER_DETAILS.USER_ID=USER_LOGIN.ID
    WHERE USERNAME=@USER_NAME AND PASSWORD=@PASSWORD
GO
EXEC SP_GET_USER_LOGIN Admin,12345

DROP PROCEDURE SP_GET_USER_LOGIN





CREATE PROCEDURE SP_CHECK_USER_LOGIN
(@USER_NAME VARCHAR(50),@PASSWORD VARCHAR(50))
AS
BEGIN
IF  EXISTS(SELECT USERNAME,PASSWORD FROM USER_LOGIN WHERE USERNAME=@USER_NAME AND PASSWORD=@PASSWORD )
BEGIN


EXEC SP_GET_USER_LOGIN @USER_NAME,@PASSWORD

END


ELSE
BEGIN

PRINT 'USER NOT FOUND!'
END

END

EXEC SP_CHECK_USER_LOGIN Admin,12345

DROP PROCEDURE SP_CHECK_USER_LOGIN