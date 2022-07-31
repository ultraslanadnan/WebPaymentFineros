window.alert = function (msg) {
    if (msg != null) msg = msg.toString().replace(/\n/g, '<br />');

    genelAlert("", msg);
   
}

function genelAlert(strBaslik, strMesaj) {
    NoticeSabitAlert(strMesaj);
}
function NoticeSabitAlertOk(strMesaj) {

    $('body').append('<div class="divNoticeOk">' + strMesaj + '</div>');

    $('.divNoticeOk').fadeIn(200);

    setTimeout("$('.divNoticeOk').fadeOut(2000, function () { $(this).remove() });", 2000);
}


function NoticeSabitAlert2(strMesaj) {
    /*        strMesaj = strMesaj.charAt(strMesaj.length - 1);*/
   /* console.log(strMesaj);*/
    strMesaj= strMesaj.replace('<br />','');
    mesajlar = strMesaj.split(';');
    var labels = '';
    var lng = mesajlar.length;
    if (lng > 1) {

        for (var i = 1; i < lng; i++) {
            if (i == (lng - 1)) {



                labels += '<label class="borderNoLine">' + mesajlar[i - 1] + '</label>'

            }
            else {

                labels += '<label class="borderLine">' + mesajlar[i - 1] + '</label>'
                /*         if (lng == 1) { labels = '<br />' + labels }*/
            }

        }

    }
    else {
        labels = '<label class="borderNoLine">' + strMesaj + '</label>';
    }
    $('body').append('<div class="divAlertFix">' + labels + '</div>');

    $('.divAlertFix').fadeIn(200);

    setTimeout("$('.divAlertFix').fadeOut(21500, function () { $(this).remove() });", 3500);
}
function NoticeSabitAlert(strMesaj) {
    /*        strMesaj = strMesaj.charAt(strMesaj.length - 1);*/
    strMesaj = strMesaj.replaceAll('<br />', '').replaceAll('<br>', '');


    /*console.log(strMesaj);*/
    var mesajlar = strMesaj.split(';');
    var labels = '';
    var lng = mesajlar.length;
    if (lng > 1) {

        for (var i = 1; i < lng; i++) {
            if (i == (lng - 1)) {



                labels += '<label class="borderNoLine">' + mesajlar[i - 1] + '</label>'

            }
            else {

                labels += '<label class="borderLine">' + mesajlar[i - 1] + '</label>'
                /*         if (lng == 1) { labels = '<br />' + labels }*/
            }

        }

    }
    else {
        labels = '<label class="borderNoLine">' + strMesaj + '</label>';
    }
    $('body').append('<div class="divAlertFix">' + labels + '</div>');

    $('.divAlertFix').fadeIn(200);

    setTimeout("$('.divAlertFix').fadeOut(3500, function () { $(this).remove() });", 3500);
}