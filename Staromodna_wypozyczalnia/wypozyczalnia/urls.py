from django.urls import path
from django.contrib.auth.views import LoginView

from . import views

app_name = 'rentals'
urlpatterns = [
    path('', views.IndexView.as_view(), name='index'), #ogólnie wypozyczalnie
    path('<int:pk>/', views.DetailView.as_view(), name='detail'), #szczegóły wypożyczalni + wybór: book movie cd
    path('login/', LoginView.as_view(template_name='registration/login.html'), name = 'login'),
    path('logout/', views.logout_page, name='logout'),
    path('borrow/', views.Borrow.as_view(), name='borrow'),
    path('statistic/', views.Statistics.as_view(), name='statistic')
]

# Wewnątrz tego modułu zaimportowano obiekt ścieżki oraz views
# moduł aplikacji
# przy router wskazywane jest w jakiej sytuacji użyć, którego modułu
# Następnie utworzono listę wzorców adresów URL, 
# które odpowiadają różnym funkcjom widoku (api/ i api-auth/).