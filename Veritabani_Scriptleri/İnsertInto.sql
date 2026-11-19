use CafeUygulamasi
go

select * from Kullanicilar;


insert into Kullanicilar(Ad,Soyad,Sifre,eposta)
Values('Rasim','Canik','rasim_425','rasimcanin@gmail.com');

insert into Kullanicilar(id,Ad,Soyad,Sifre,eposta)
Values('Senem','Babi','SenemBab_274','senembabi@gmail.com');

alter table Kullanicilar Drop Column Soyad;