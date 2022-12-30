CREATE TABLE test_user (
    USER_Primary_ID int IDENTITY(1,1) NOT NULL ,
    USER_LastName varchar(50) NOT NULL,
    USER_NickName varchar(50),
    USER_UserType varchar(1),
	USER_Type_Ced varchar(1),
	USER_Ced varchar (50),
	USER_Pass varchar (20),
	USER_Email varchar (100)
	PRIMARY KEY (USER_PRIMARY_ID)
);


CREATE TABLE test_contact (
    TEL_PRIMARY_ID int IDENTITY(1,1) NOT NULL , 
	TEL_Number varchar(20),
	TEL_Type varchar(20),
	TEL_State varchar(1),
	USER_Primary_ID int,
	PRIMARY KEY(TEL_PRIMARY_ID),
	CONSTRAINT FK_UserID FOREIGN KEY (USER_Primary_ID) REFERENCES test_user(USER_Primary_ID)

);


CREATE TABLE test_habilities (
    HAB_PRIMARY_ID int IDENTITY(1,1) NOT NULL,
	HAB_Name varchar(40),
	HAB_Descripcion varchar(40),
	USER_Primary_ID int,
	PRIMARY KEY (HAB_PRIMARY_ID),
	CONSTRAINT FK_UserID_Habilities FOREIGN KEY (USER_Primary_ID) REFERENCES test_user(USER_Primary_ID)
);