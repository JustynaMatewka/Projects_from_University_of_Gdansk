from dataclasses import field
from .models import Rental, Book, Movie, CD
from rest_framework import serializers

class RentalSerializer(serializers.HyperlinkedModelSerializer):
    class Meta:
        model = Rental
        fields = ['ID', 'nazwa', 'miasto', 'ulica', 'nr_lokalu']

class BookSerializar(serializers.HyperlinkedModelSerializer):
    class Meta:
        model = Book
        fields = ['autor', 'tytul', 'gatunek', 'ISBN', 'ID_wypozyczalni']

class MovieSerializar(serializers.HyperlinkedModelSerializer):
    class Meta:
        model = Movie
        fields = ['rezyser', 'tytul', 'gatunek', 'czas_trwania', 'ID_wypozyczalni']
        
class CDSerializar(serializers.HyperlinkedModelSerializer):
    class Meta:
        model = CD
        fields = ['zespol', 'tytul', 'gatunek', 'lista_utworow', 'czas_trwania', 'ID_wypozyczalni']
        