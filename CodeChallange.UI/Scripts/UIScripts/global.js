$(document).ajaxStop(function () {
    global.loading(false);
});
$(document).ajaxStart(function () {
    global.loading(true);
});

var global = {
    mask: function () {
        $("input[name='Phone']").mask("(999) 999-99-99");
    },
    reset: function (form) {
        $(form).find("input[type=text]").val("");
        $("#popup-error-alert").hide();
    },
    read: function () {
        location.reload();
        //$.get(ROOT + "/Home/Read", function (data) {
        //    $("#content").html('');
        //    $("#content").html(data);
        //});
    },
    successAlert: function () {
        $("#success-alert").show();
        $("#success-alert").fadeTo(2000, 500).slideUp(500, function () {
            $("#success-alert").hide();
        });
    },
    errorAlert: function () {
        $("#error-alert").show();
        $("#error-alert").fadeTo(2000, 500).slideUp(500, function () {
            $("#error-alert").hide();
        });
    },
    popupAlert: function () {
        $("#popup-error-alert").show();
        $("#popup-error-alert").fadeTo(2000, 500).slideUp(500, function () {
            $("#popup-error-alert").hide();
        });
    },
    loading: function (isShow) {
        if (isShow) {
            $("#ajax_loader").show();
        } else {
            $("#ajax_loader").hide();
        }
    }
}