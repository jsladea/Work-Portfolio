from django.db import models


# Create your models here.
class Conversion(models.Model):
    conv = models.CharField(max_length=4)
    cf = models.DecimalField(max_digits=45, decimal_places=15)
