INSERT INTO dbo.Clients
VALUES('Joris De Ridder','Joris.42@hotmail.com','Meloen', 'Meloen','Belgium','Lint','Kerkhofweg','42','2547',1,'1997-02-21');
INSERT INTO dbo.Clients
VALUES('Jolien Leducq','Jolien.leduqc@icloud.com','Appel','Appel','Belgium','Lier','Maanstraat','13','2500',0,'2000-04-10');
INSERT INTO dbo.Clients
VALUES('Jarne Bauwens','Jarne@telenet.be','Banaan','Banaan','Belgium','Lier','Teststraat','33','2500',0,'2000-06-23');




INSERT INTO dbo.Clientaccounts
VALUES(1,'2022-07-21')

INSERT INTO dbo.Logs
VALUES(1,'2022-07-21')
INSERT INTO dbo.Logs
VALUES(1,'2022-07-24')


INSERT INTO dbo.Accounts
VALUES('Zichtrekening',1);
INSERT INTO dbo.Accounts
VALUES('Spaarrekening',2);

SELECT *
FROM dbo.Cards

SELECT *
FROM dbo.Accounts

SELECT *
FROM dbo.Logs

SELECT *
FROM dbo.Transactions

SELECT *
FROM dbo.Clients