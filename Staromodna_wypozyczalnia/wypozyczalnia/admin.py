from django.contrib import admin
from .models import Rental, Book, Movie, CD

# Register your models here.
@admin.register(Rental)
class RentalAdmin(admin.ModelAdmin):
    list_display = ['ID', 'nazwa']


@admin.register(Book)
class BookAdmin(admin.ModelAdmin):
    list_display = ['tytul', 'autor']
    search_fields = ['tytul']
    list_filter = ['gatunek']


@admin.register(Movie)
class MovieAdmin(admin.ModelAdmin):
    list_display = ['tytul', 'rezyser']
    search_fields = ['tytul']
    list_filter = ['gatunek']


@admin.register(CD)
class CDAdmin(admin.ModelAdmin):
    list_display = ['tytul', 'zespol']
    search_fields = ['tytul']
    list_filter = ['gatunek']
