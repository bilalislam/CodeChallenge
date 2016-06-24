$(document).ready(function () {
    main.setIdForDelete();
    main.setPaging();
    /*details popup ve index(home.js) htmllerinde olmak üzere 2 yerde çağrılıyor çünkü js sorunundan dolayı override etmesi lazım tekrar ekranı !
      çünkü partial viewlerin içinde razor labellar var.JS'nin bunları tekrar render etmesi lazım.
    */
    main.updateUser();
    $('.btn-ok').click(function (e) {
        e.preventDefault();
        var userId = $('#confirm-delete').find('.btn-ok').attr('id');
        main.deleteUser(userId);        
    });
});


