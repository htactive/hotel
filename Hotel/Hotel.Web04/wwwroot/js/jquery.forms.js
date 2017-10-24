jQuery(document).ready(function () {
    // Reservation Form
    var reservationform = jQuery('#reservationform');
    var reservationMessages = jQuery('#message');
    jQuery(reservationform).submit(function (e) {
        jQuery(reservationMessages).slideUp(750);
        jQuery(reservationMessages).hide();
        e.preventDefault();
        var formData = jQuery(reservationform).serialize();
        var action = jQuery(this).attr('action');
        jQuery.post(action, jQuery(reservationform).serialize(),
            function (data) {
                if (data.match('success') != null) jQuery('#reservationform .form-group, #reservationform .btn').slideUp('slow');
                if (data.match('success') != null) jQuery('#email').val('');
            }
        ).done(function (response) {
                jQuery(reservationMessages).html(response).slideDown(400);
            })
    });
});