INSERT INTO dbo.Clients
VALUES('Joris De Ridder','Joris.42@hotmail.com','Meloen', 'Meloen','Belgium','Lint','Kerkhofweg','42','2547',1,'1997-02-21');
INSERT INTO dbo.Clients
VALUES('Jolien Leducq','Jolien.leduqc@icloud.com','Appel','Appel','Belgium','Lier','Maanstraat','13','2500',0,'2000-04-10');
INSERT INTO dbo.Clients
VALUES('Jarne Bauwens','Jarne@telenet.be','Banaan','Banaan','Belgium','Lier','Teststraat','33','2500',0,'2000-06-23');
INSERT INTO dbo.Clients
VALUES('test','t','t','t','Belgium','Lier','Teststraat','22','2500',0,'2000-04-23');

INSERT INTO dbo.Logs
VALUES('2022-08-06');
INSERT INTO dbo.Logs
VALUES('2022-08-02');

INSERT INTO dbo.TransactionTypes
VALUES('Withdraw');
INSERT INTO dbo.TransactionTypes
VALUES('Deposit');

INSERT INTO dbo.Transactions
VALUES(300,1);
INSERT INTO dbo.Transactions
VALUES(200,2);

INSERT INTO dbo.Balances
VALUES(402);
INSERT INTO dbo.Balances
VALUES(312);

INSERT INTO dbo.Accounts
VALUES('BE58 5475 3432 9889',0, 1204,1,1);
INSERT INTO dbo.Accounts
VALUES('BE58 5645 2424 9645',0, 3467,2,2);
INSERT INTO dbo.Accounts
VALUES('BE48 5632 2321 9890',0, 243,1,2);

INSERT INTO dbo.Clientaccounts
VALUES(1,1);
INSERT INTO dbo.Clientaccounts
VALUES(2,2);

INSERT INTO dbo.Cards
VALUES('KaartJoris',1,1);
INSERT INTO dbo.Cards
VALUES('KaartJolien',2,2);

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