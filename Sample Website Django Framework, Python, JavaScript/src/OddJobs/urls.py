from django.urls import path

from . import views

app_name = 'OddJobs'
urlpatterns = [
    path('job_history', views.job_history_page, name="job_history"),
    path('job_history_listings', views.job_history_listings, name="job_history_listings"),
    path('<int:job_id>/rating_popup', views.rating_popup, name="rating_popup"),
    path('<int:job_id>/submit_rating', views.submit_rating, name="submit_rating"),
    path('balance_page/', views.balance_page, name="balance_page"),
    path('balance_page/<str:err_msg>/', views.balance_page, name="balance_page"),
    path('update_balance', views.update_balance, name="update_balance"),
    path('request_username/<str:email_address>/', views.request_username, name="request_username"),
    path('reset_code/<str:email_address>/', views.reset_code, name="reset_code"),
    path('reset_password', views.reset_password, name="reset_password"),
    path('account_info', views.account_info, name="account_info"),
    path('account_reset/', views.account_reset, name="account_reset"),
    path('account_reset/<str:err_msg>/', views.account_reset, name="account_reset"),
    path('archive_user', views.archive_user, name="archive_user"),
]

