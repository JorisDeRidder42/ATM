INSERT INTO dbo.Clients
VALUES('Joris De Ridder','Joris.42@hotmail.com','Meloen', 'Meloen','Belgium','Lint','Kerkhofweg','42','2547',1,'1997-02-21');
INSERT INTO dbo.Clients
VALUES('Jolien Leducq','Jolien.leducq@icloud.com','Appel','Appel','Belgium','Lier','Maanstraat','13','2500',0,'2000-04-10');
INSERT INTO dbo.Clients
VALUES('Jarne Bauwens','Jarne@telenet.be','Banaan','Banaan','Belgium','Lier','Teststraat','33','2500',0,'2000-06-23');
INSERT INTO dbo.Clients
VALUES('Sven Meert','Sven@outlook.be','Peer','Peer','Belgium','Ekeren','Pantraat','45','2000',0,'1998-03-12');


INSERT INTO dbo.TransactionTypes
VALUES('Deposit');
INSERT INTO dbo.TransactionTypes
VALUES('Withdraw');

INSERT INTO dbo.Transactions
VALUES(302,1);
INSERT INTO dbo.Transactions
VALUES(405,2);
INSERT INTO dbo.Transactions
VALUES(200,1);
INSERT INTO dbo.Transactions
VALUES(500,2);

INSERT INTO dbo.Accounts
VALUES('BE45 4545 6556 7894',450,3,1)
INSERT INTO dbo.Accounts
VALUES('BE56 1234 6573 0694',202,4,2)
INSERT INTO dbo.Accounts
VALUES('BE23 3535 1245 4939',2013,3,2)
INSERT INTO dbo.Accounts
VALUES('BE12 1324 5867 5474',202,6,3)
INSERT INTO dbo.Accounts
VALUES('BE56 1234 6573 0694',342,7,4)
INSERT INTO dbo.Accounts
VALUES('BE41 2356 1356 1284',21,5,3)

INSERT INTO dbo.CardTypes
VALUES('Visa')
INSERT INTO dbo.CardTypes
VALUES('Mastercard')
INSERT INTO dbo.CardTypes
VALUES('Kredietkaart')
INSERT INTO dbo.CardTypes
VALUES('Prepaidkaart')
INSERT INTO dbo.CardTypes
VALUES('Virtualkaart')
INSERT INTO dbo.CardTypes
VALUES('Debietkaart')

INSERT INTO dbo.Cards
VALUES('Jobkaart',2)
INSERT INTO dbo.Cards
VALUES('Persoonlijke kaart',1)
INSERT INTO dbo.Cards
VALUES('Bankkaart hubo',3)
INSERT INTO dbo.Cards
VALUES('Geekstore kaart',5)


INSERT INTO dbo.CardAccounts
VALUES(1,2)
INSERT INTO dbo.CardAccounts
VALUES(2,12)
INSERT INTO dbo.CardAccounts
VALUES(2,3)
INSERT INTO dbo.CardAccounts
VALUES(2,6)
INSERT INTO dbo.CardAccounts
VALUES(2,13)
INSERT INTO dbo.CardAccounts
VALUES(2,14)
