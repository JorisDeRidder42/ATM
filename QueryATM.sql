INSERT INTO dbo.Clients
VALUES('Joris De Ridder','Lint','Kerkhofweg','42','2547','Meloen',0,'1997-02-21','2022-07-19');
INSERT INTO dbo.Clients
VALUES('Jolien Leducq','Lier','Maanstraat','13','2500','Meloen',0,'2000-04-10','2022-07-19');

INSERT INTO dbo.Cards
VALUES('2010203040','Appel',0);

INSERT INTO dbo.Cards
VALUES('1050405094','Meloen',0);

INSERT INTO dbo.Transactions
VALUES(20);
INSERT INTO dbo.Transactions
VALUES(50);
INSERT INTO dbo.Transactions
VALUES(100);
INSERT INTO dbo.Transactions
VALUES(200);

INSERT INTO dbo.Accounts
VALUES('BE58 7310 3344 9674', 'Zichtrekening', 2, 1);
INSERT INTO dbo.Accounts
VALUES('BE11 7432 5499 1453', 'Spaarrekening', 1, 2);

INSERT INTO dbo.Logs
VALUES(1500, '2022-07-21')