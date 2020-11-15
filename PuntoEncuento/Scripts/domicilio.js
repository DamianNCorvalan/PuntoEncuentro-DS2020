//carga los select para cargar el domicilio
$(document).ready(function () {
    $('#IdProvincia').val('');
    $('#IdProvincia').trigger('change');
    $('#IdProvincia').change(function () {
        if ($(this).val()) {
    $.ajax({
        url: '../Partido/Details?id=' + $(this).val(),
        method: 'GET',
        success: function (data) {
            $('#IdPartido').empty();
            for (i = 0, j = data.length; i < j; i++) {
                $('#IdPartido').append('<option value="' + data[i].IdPartido + '">' + data[i].Nombre + '</option>');
                $('#IdPartido').val('');
                $('#IdPartido').trigger('change');
            }
        }
    });
        }
    });

    $('#IdPartido').change(function () {
        if ($(this).val()) {
    $.ajax({
        url: '../Localidad/Details?id=' + $(this).val(),
        method: 'GET',
        success: function (data) {
            $('#IdLocalidad').empty();
            for (i = 0, j = data.length; i < j; i++) {
                $('#IdLocalidad').append('<option value="' + data[i].IdLocalidad + '">' + data[i].Nombre + '</option>');
                $('#IdLocalidad').val('');
                $('#IdLocalidad').trigger('change');
            }
        }
    });
        }
    });

});