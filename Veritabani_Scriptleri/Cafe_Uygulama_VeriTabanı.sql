/*Create Table Kullanicilar(

id int identity primary key,
Ad nvarchar(50) not null ,
Soyad nvarchar(50),
Sifre nvarchar(14)
);
*/




/*

INSERT INTO Kullanicilar(Ad,Soyad,Sifre)
Values('Emre','Orman','emre_12596'),
	  ('Hasan','Alataş','hasan123'),
	  ('Sudenur','Algın', 'Sude_555'),
	  ('Salih', 'Boz', 'SalBz01'),
	  ('Aslı', 'Yağan', 'AslıYağan-55');
	  */


	  select * from Kullanicilar;

	  /* Kullanicilar tablosuna eposta sütununu ekledik
	  
	  Alter Table Kullanicilar
	  Add eposta varchar(50)
	  */

	  /*
	  update Kullanicilar set eposta = 'yunuscan@gmail.com' where Ad = 'Yunus';

	  update Kullanicilar 
	  set eposta = ad + '@gmail.com'
	  where eposta is null;

	  */
	 
	 select * from Kullanicilar

	 ALTER TABLE Kullanicilar ADD KayitTarihi DATETIME DEFAULT GETDATE();

	 UPDATE Kullanicilar
SET KayitTarihi = DATEADD(day, id, '2024-01-01')
WHERE KayitTarihi IS NULL;

select * from KahveYonetim