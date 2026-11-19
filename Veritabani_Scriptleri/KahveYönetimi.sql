Use CafeUygulamasi
go


select * from Kullanicilar

/*
Create Table KahveYonetim(

id INT IDENTITY(1,1) PRIMARY KEY,
KahveAdi NVARCHAR(50),
Fiyat DECIMAL(10,2),
Stok INT,
ResimYolu NVARCHAR(250)
)
*/


/*
Alter Table KahveYonetim ADD Kategori NVARCHAR(50) NULL;

UPDATE KahveYonetim SET Kategori = 'Sicak'; 
UPDATE KahveYonetim SET Kategori = 'Soğuk' WHERE KahveAdi IN('Frappe','Iced Mocha','Iced Americano');
*/

select * from KahveYonetim

