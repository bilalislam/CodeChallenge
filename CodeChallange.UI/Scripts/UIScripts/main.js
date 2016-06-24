var main = {
    init: function () {
        global.mask();
        $("#createModal").on('hidden.bs.modal', function () {
            global.reset("form");
        });
    },
    setCaptchaCss: function () {
        $("#CaptchaInputText").addClass("form-control");
    },
    updateUser: function () {
        $('.update').on('click', function (e) {
            var url = $(this).data('url');
            $.get(url, function (data) {
                $('.modal-content #container').html(data);
            });
        });
    },
    setIdForDelete: function () {
        $('#confirm-delete').on('show.bs.modal', function (e) {
            $(this).find('.btn-ok').attr('id', $(e.relatedTarget).data('id'));
        });
    },
    deleteUser: function (id) {
        $.post(ROOT + "/Home/Delete", { id: id }).done(function (result) {
            if (result.isSuccess) {
                global.successAlert();
                $('#confirm-delete').modal('hide');
                global.read();
            }
        });
    },
    setPaging: function () {
        var count = parseInt($('#count').val());
        $('#pagination').bootpag({
            total: Math.ceil((count / 10))
        }).on("page", function (event, num) {

            $.get(ROOT + "/Home/Read/?skip=" + num, function (data) {
                $("#content").html('');
                $("#content").html(data);
            });

            $(this).bootpag({
                total: parseInt(count),
                maxVisible: Math.ceil((count / 10))
            });
        });
    }
};