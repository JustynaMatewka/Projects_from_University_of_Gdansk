from django.db import models
from django.contrib.auth.models import User

# Create your models here.
class Rental(models.Model):
    ID = models.BigAutoField(primary_key = True)
    nazwa = models.CharField(max_length=255)
    miasto = models.CharField(max_length=50)
    ulica = models.TextField()
    nr_lokalu = models.CharField(max_length=25)

    def __str__(self):
        return self.nazwa


class Book(models.Model):
    gatunki_ksiazek = (
        ('Fantastyka', 'Fantastyka'),
        ('Sci–Fi', 'Science Fiction'),
        ('Romans', 'Romans'),
        ('Powieść historyczna', 'Powieść historyczna'),
        ('Horror', 'Horror'),
        ('Kryminał i thriller', 'Kryminał i thriller'),
        ('Biografia', 'Biografia'),
        ('Reportaż ', 'Reportaż'),
        ('Powieść młodzieżowa ', 'Powieść młodzieżowa'),
        ('Reportaż ', 'Reportaż'),
        ('Powieść naukowa', 'Powieść naukowa'),
        ('Poradnik', 'Poradnik'),
        ('Dla dzieci', 'Dla dzieci')
    )
    autor = models.CharField(max_length=255)
    tytul = models.CharField(max_length=255)
    gatunek = models.CharField(choices=gatunki_ksiazek, max_length=40, default='Wybierz')
    ISBN = models.CharField(unique=True, max_length=70)
    dostepne = models.BooleanField(default=True)
    ID_wypozyczalni = models.ForeignKey(Rental, on_delete=models.CASCADE)
    

    def __str__(self):
        return self.tytul
    
    class Meta:
        constraints = [
            models.UniqueConstraint(fields=['tytul', 'autor', 'gatunek'], name='unique_book')
        ]


class Movie(models.Model):
    gatunki_filmow = (
        ('Akcji', 'Akcji'),
        ('Animowany', 'Animowany'),
        ('Biograficzny', 'Biograficzny'),
        ('Dokumentalny', 'Dokumentalny'),
        ('Dramat', 'Dramat'),
        ('Edukacyjny', 'Edukacyjny'),
        ('Familijny', 'Familijny'),
        ('Fantasy', 'Fantasy'),
        ('Science-Fiction', 'Science-Fiction'),
        ('Horror', 'Horror'),
        ('Historyczny', 'Historyczny'),
        ('Komedia', 'Komedia'),
        ('Kryminał', 'Kryminał'),
        ('Obyczajowy', 'Obyczajowy'),
        ('Polityczny', 'Polityczny'),
        ('Przyrodniczy', 'Przyrodniczy'),
        ('Religijny', 'Religijny'),
        ('Romans', 'Romans'),
        ('Sport', 'Sport'),
        ('Thriller', 'Thriller')
    )
    rezyser = models.CharField(max_length=255)
    tytul = models.CharField(max_length=255)
    gatunek = models.CharField(choices=gatunki_filmow, max_length=40, default='Wybierz')
    czas_trwania = models.CharField(max_length=25)
    dostepne = models.BooleanField(default=True)
    ID_wypozyczalni = models.ForeignKey(Rental, on_delete=models.CASCADE)

    def __str__(self):
        return self.tytul
    
    class Meta:
        constraints = [
            models.UniqueConstraint(fields=['tytul', 'rezyser', 'gatunek'], name='unique_movie')
        ]


class CD(models.Model):
    gatunki_muzyczne = (
        ('Blues', 'Blues'),
        ('Country', 'Country'),
        ('Dance', 'Dance'),
        ('Electronica', 'Electronica'),
        ('Folk', 'Folk'),
        ('Funk', 'Funk'),
        ('Metal', 'Metal'),
        ('Hip hop', 'Hip hop'),
        ('Rap', 'Rap'),
        ('House', 'House'),
        ('Muzyka klasyczna', 'Muzyka klasyczna'),
        ('Inne', 'Inne'),
        ('Pop', 'Pop'),
        ('Jazz', 'Jazz')
    )
    zespol = models.CharField(max_length=255)
    tytul = models.CharField(max_length=255)
    gatunek = models.CharField(choices=gatunki_muzyczne, max_length=40, default='Wybierz')
    lista_utworow = models.TextField(null=True, blank=True)
    czas_trwania = models.CharField(max_length=25)
    dostepne = models.BooleanField(default=True)
    ID_wypozyczalni = models.ForeignKey(Rental, on_delete=models.CASCADE)

    def __str__(self):
        return self.tytul


class Rent(models.Model):
    user = models.ForeignKey(User, on_delete=models.CASCADE)
    depositet_book = models.OneToOneField(Book, null=True, blank=True, on_delete=models.CASCADE)
    depositet_movie = models.OneToOneField(Movie, null=True, blank=True, on_delete=models.CASCADE)
    depositet_cd = models.OneToOneField(CD, null=True, blank=True, on_delete=models.CASCADE)
    deposit_date = models.DateField()
    deposit_length = models.DateField()


#Zmień swoje modele (w models.py).
#Uruchom python manage.py makemigrations, aby stworzyć migracje dla tych zmian
#Uruchom python manage.py migrate, aby zastosować te zmiany na bazie danych.
# Migracja to plik zawierający klasę Migration z regułami, które informują Django, 
# jakie zmiany należy wprowadzić w bazie danych
# db.sqlite3 - baza wypozyczalni