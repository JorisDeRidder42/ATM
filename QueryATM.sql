INSERT INTO dbo.Clients
VALUES('Joris De Ridder','Meloen', 'Meloen','Belgium','Lint','Kerkhofweg','42','2547',1,'1997-02-21');
INSERT INTO dbo.Clients
VALUES('Jolien Leducq','Meloen','Meloen','Belgium','Lier','Maanstraat','13','2500',0,'2000-04-10');

INSERT INTO dbo.Cards
VALUES('2010203040','Meloen');
INSERT INTO dbo.Cards
VALUES('1050405094','Meloen');

INSERT INTO dbo.Accounts
VALUES('Zichtrekening',1);
INSERT INTO dbo.Accounts
VALUES('Spaarrekening',2);

INSERT INTO dbo.Transactions
VALUES(300,1)
INSERT INTO dbo.Transactions
VALUES(500,2)

INSERT INTO dbo.ClientAccounts
VALUES(1,2);
INSERT INTO dbo.ClientAccounts
VALUES(2,1);

INSERT INTO dbo.TransactionTypes
VALUES('Withdraw',1)
INSERT INTO dbo.TransactionTypes
VALUES('Deposit',2)

INSERT INTO dbo.Logs
VALUES(1,'2022-07-21')
INSERT INTO dbo.Logs
VALUES(1,'2022-07-24')

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