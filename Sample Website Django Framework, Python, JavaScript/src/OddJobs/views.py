from django.contrib.auth import login, logout
from django.contrib.auth.decorators import login_required, user_passes_test
from django.http import HttpResponse
from django.shortcuts import render, redirect, get_object_or_404
from .models import User, Job
from django.http import Http404
from django.core.mail import send_mail
from django.conf import settings
from datetime import date

#job-history
@login_required()
def job_history_page(request):
    if not request.user.is_authenticated:
        return redirect('OddJobs:index')
    return render(request, 'OddJobs/job_history.html', {})


def job_history_listings(request):
    if not request.user.is_authenticated:
        return redirect('OddJobs:index')
    elif 'start_date' not in request.GET or 'end_date' not in request.GET:
        raise Http404("Missing required parameters - must have start_date and end_date")
    else:
        try:
            print(str(request.user))
            job_history = JobHistory.get_job_history(request)
            return render(request, 'OddJobs/job_history_listings.html', {'user': request.user, 'job_history': job_history, 'range': range(1, 6)})
        except:
            raise Http404("Error obtaining job history")


def rating_popup(request, job_id):
    job = get_object_or_404(Job, pk=job_id)
    if not request.user.is_authenticated or job.customer != request.user:
        return redirect('OddJobs:index')
    return render(request, 'OddJobs/rating_popup.html', {'job_id': job_id})


def submit_rating(request, job_id):
    job = get_object_or_404(Job, pk=job_id)
    if not request.user.is_authenticated or job.customer != request.user:
        return redirect('OddJobs:index')
    try:
        selected_rating = int(request.POST['rating'])
    except:
        raise Http404("Error Submitting Rating")
    else:
        job.rating = selected_rating
        job.save()
        return redirect('OddJobs:job_history')

@login_required()
def balance_page(request, err_msg=""):
    print("Balance Pager error message: " + str(err_msg))
    if request.user.is_authenticated:
        return render(request, 'OddJobs/balance_page.html', {'err_msg': err_msg})
    else:
        return redirect('OddJobs:index')


def update_balance(request):
    if not request.user.is_authenticated:
        return redirect('OddJobs:index')
    try:
        if not request.user.update_balance(request.POST['action'], request.POST['amount']):
            return redirect('OddJobs:balance_page', err_msg="Invalid amount.")
    except:
        return redirect('OddJobs:balance_page', err_msg="Error updating balance.")
    else:
        return redirect('OddJobs:balance_page')

@login_required()
def account_info(request):
    if request.user.is_authenticated:
        return render(request, 'OddJobs/account_info.html')
    else:
        return redirect('OddJobs:login')


def account_reset(request, err_msg=""):
    return render(request, 'OddJobs/account_reset.html', {'err_msg': err_msg})


def request_username(request, email_address):
    try:
        user = User.objects.get(email=email_address)
    except User.DoesNotExist:
        return HttpResponse("We were unable to find a user with that email address.")
    except:
        return HttpResponse("An error occurred.")
    else:
        user.email_user(subject='Your OddJobs Username', message=f"Your username is {user.username}",
                  from_email=settings.EMAIL_HOST_USER)
        return HttpResponse("success")


def reset_code(request, email_address):
    try:
        user = User.objects.get(email=email_address)
    except User.DoesNotExist:
        return HttpResponse("We were unable to find a user with that email address.")
    except:
        return HttpResponse("An error occurred.")
    else:
        msg = f"Your reset code is: {AccountInfo.get_six_digit_hash(user.email)}\n" \
              f"This code is valid until {date.today().strftime('%m/%d/%Y')} at 11:59 pm (MST)."
        user.email_user(subject='Password Reset Code', message=msg,
                  from_email=settings.EMAIL_HOST_USER)
        return HttpResponse("success")


def reset_password(request):
    try:
        email_address = request.POST['email']
        code = int(request.POST['code'])
        newPassword = request.POST['password']
        user = User.objects.get(email=email_address)
    except User.DoesNotExist:
        return redirect('OddJobs:account_reset', err_msg="We were unable to find a user with that email address.")
    except:
        return redirect('OddJobs:account_reset', err_msg="Please make sure you have entered your email, code, and new password.")
    else:
        if code == AccountInfo.get_six_digit_hash(user.email):
            user.set_password(newPassword)
            user.save()
            return redirect('OddJobs:login')
        else:
            return redirect('OddJobs:account_reset', err_msg="Incorrect code entered.")


def archive_user(request):
    if request.user.is_authenticated:
        user = request.user
        user.is_active = False
        user.save()
    return redirect('OddJobs:index')


class JobHistory:

    @staticmethod
    def get_job_history(request):
        current_user = request.user
        start_date = request.GET['start_date']
        end_date = request.GET['end_date']

        print(f'Current User: {current_user}\nStart Date: {start_date}\nEnd Date: {end_date}')

        return list(current_user.get_job_history(start_date, end_date))

class AccountInfo:

    #not a great way to do identity verification, but for purposes of this example website
    @staticmethod
    def get_six_digit_hash(string):
        string = str(date.day) + string[0:2] + str(date.month) + string[2:]
        stop = int(len(string) * 0.75)
        bytes = string[0:stop].encode() #default encoding is utf-8
        hash = 0
        for byte in bytes:
            hash += byte
            hash += (hash << 10)
            hash ^= (hash >> 6)
        hash += (hash << 3)
        hash ^= (hash >> 11)
        hash += (hash << 15)

        return hash % 1000000
