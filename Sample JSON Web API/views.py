from django.http import JsonResponse
from django.shortcuts import render, get_object_or_404

from .models import Conversion


# Create your views here.

def convert(request):
    valid_units = ['T', 'g', 't_oz', 'kg', 'lb', 'oz']
    response = {}

    print(str(request.GET))
    if 'from' not in request.GET or 'to' not in request.GET or 'value' not in request.GET:
        print("Missing parameter")
        response['error'] = "Invalid unit conversion request."
    else:
        try:
            from_unit = request.GET['from']
            to_unit = request.GET['to']
            value = float(request.GET['value'])
        except:
            response['error'] = "Invalid unit conversion request."

        if from_unit not in valid_units or to_unit not in valid_units:
            print("Invalid units")
            response['error'] = "Invalid unit conversion request."
        else:
            response['units'] = to_unit
            response['value'] = convert_units(from_unit, to_unit, value)
    json = JsonResponse(response)
    json.status_code = 200
    return json


def convert_units(from_unit, to_unit, value):
    from_conv = 'g_to_' + from_unit

    conv_obj_from = get_object_or_404(Conversion, conv=from_conv)
    cf_from_to_g = 1 / float(conv_obj_from.cf)

    from_unit_in_g = value * cf_from_to_g

    to_conv = 'g_to_' + to_unit
    conv_obj_to = get_object_or_404(Conversion, conv=to_conv)
    cf_to = float(conv_obj_to.cf)
    result = from_unit_in_g * cf_to

    return result
