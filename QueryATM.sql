INSERT INTO dbo.Clients
VALUES('Joris De Ridder','Joris.42@hotmail.com','Meloen', 'Meloen','Belgium','Lint','Kerkhofweg','42','2547',1,'1997-02-21');
INSERT INTO dbo.Clients
VALUES('Jolien Leducq','Jolien.leducq@icloud.com','Appel','Appel','Belgium','Lier','Maanstraat','13','2500',0,'2000-04-10');
INSERT INTO dbo.Clients
VALUES('Jarne Bauwens','Jarne@telenet.be','Banaan','Banaan','Belgium','Lier','Teststraat','33','2500',0,'2000-06-23');
INSERT INTO dbo.Clients
VALUES('test','t','t','t','Belgium','Lier','Teststraat','22','2500',0,'2000-04-23');

INSERT INTO dbo.TransactionTypes
VALUES('Deposit');
INSERT INTO dbo.TransactionTypes
VALUES('Withdraw');

INSERT INTO dbo.Transactions
VALUES(302,1);
INSERT INTO dbo.Transactions
VALUES(405,2);

INSERT INTO dbo.Balances
VALUES(4050);
INSERT INTO dbo.Balances
VALUES(340);

INSERT INTO dbo.Accounts
VALUES('BE 45 4545 6556 7894',450,1,3,1)
INSERT INTO dbo.Accounts
VALUES('BE56 1234 6573 0694',202,2,4,2)

INSERT INTO dbo.CardTypes
VALUES('Visa')
INSERT INTO dbo.CardTypes
VALUES('Mastercard')

INSERT INTO dbo.Cards
VALUES('Werk-kaart',2)
INSERT INTO dbo.Cards
VALUES('Persoonlijke kaart',1)

INSERT INTO dbo.CardAccounts
VALUES(1,2)
INSERT INTO dbo.CardAccounts
VALUES(2,3)



--SELECT *
--FROM dbo.Cards

--SELECT *
--FROM dbo.Accounts

--SELECT *
--FROM dbo.Transactions

--SELECT *
--FROM dbo.Clients

--SELECT *
--FROM dbo.CardAccounts

--SELECT *
--FROM dbo.CardTypes

--SELECT *
--FROM dbo.TransactionTypes

--SELECT *
--FROM dbo.Balances
