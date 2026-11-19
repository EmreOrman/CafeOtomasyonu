Use CafeUygulamasi
go

select * from Kullanicilar;

Create Table Yöneticiler(
YöneticiID int primary key  identity,
YöneticiAd varchar(50) not null,
YöneticiSoyad varchar(50) not null,
YöneticiSifre varchar(50) not null
)

select * from Yöneticiler

/*
Update Kullanicilar set Ad = 'Yunus' , Soyad = 'Can' , Sifre = 'yunus12345' 
Where Soyad = 'Orman';
*/



insert into Yöneticiler(YöneticiAd,YöneticiSoyad,YöneticiSifre)
Values ('Emre', 'Orman', 'emre_12596'),
       ('Mesut', 'Orman', 'mesutorm92');