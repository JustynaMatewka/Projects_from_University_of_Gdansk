from django.shortcuts import get_object_or_404, render
from django.http import HttpResponse, HttpResponseRedirect
from django.contrib.auth.mixins import LoginRequiredMixin
from django.views import generic
from django.urls import reverse, reverse_lazy
from django.contrib.auth import logout, authenticate
from .models import Rental, Rent, Book, Movie, CD
from django import forms


class IndexView(generic.ListView):
    template_name = 'rentals/index.html'
    context_object_name = 'latest_question_list'

    def get_queryset(self):
        """Return the rentals"""
        return Rental.objects.order_by('-ID')[:20]

class DetailView(generic.DetailView):
    model = Rental
    template_name = 'rentals/detail.html'
    
def logout_page(request):
    logout(request)
    return HttpResponseRedirect("http://127.0.0.1:8000/rentals/")

class Statistics(generic.ListView):
    model = Rental
    template_name = 'rentals/statistic.html'
    context_object_name = 'rents'

class Deposite(LoginRequiredMixin, generic.CreateView):
    model = Rent
    fields = '__all__'
    success_url = reverse_lazy('rentals:index')
    template_name = 'rentals/edit.html'

class Borrow(LoginRequiredMixin, generic.UpdateView):
    model = Rent
    template_name = 'rentals/borrow.html'
    fields = '__all__'
    pk_url_kwarg = 'pk'
    success_url = reverse_lazy('rentals:index')
def vote(request, question_id):
    return HttpResponse("Hello, world. You're at the polls index.")

def account(request):
    return HttpResponse('rentals/account.html')
