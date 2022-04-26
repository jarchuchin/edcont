var esChrome = navigator.userAgent.toLowerCase().indexOf("chrome") > -1;
var esExplorer = navigator.userAgent.toLowerCase().indexOf("msie ") > -1;
var esFireFox = navigator.userAgent.toLowerCase().indexOf("firefox") > -1;
var esSafari = !esChrome && navigator.userAgent.toLowerCase().indexOf("safari") > -1;
var esIpad = navigator.userAgent.toLowerCase().indexOf("ipad") > -1;

var waitactive = true;






//transparent header

$(window).on('load', (function () {
    $('body').scrollspy({
        target: '.bs-docs-sidebar',
        offset: 40
    });



}));


$(document).ready(function () {

    $('.ventanaSuper').magnificPopup({
        tClose: 'Cerrar (Esc)',
        tLoading: 'Cargando...',
        type: 'iframe',
        closeOnBgClick: false,
        callbacks: {
            open: function () {
                $(".mfp-bg").show();
                waitMagnific(true);

                var mfpIframe = $(".mfp-iframe");
                mfpIframe.on('load', function () {
                    waitMagnific(false);

                    resizePopup();


                });
            },
            close: function () {
                $(".mfp-iframe-holder").css("padding-bottom", "40px");
            }
        }
    });

});

function waitMagnific(activar) {
    if (activar) {
        $(".mfp-iframe").hide();
        $(".mfp-close").hide();
        $(".mfp-bg").hide();
    }
    else {
        $(".mfp-iframe").show();
        $(".mfp-close").show();
        $(".mfp-bg").show();
    }
}

function resizePopup() {
    var mfpIframe = $(".mfp-iframe");

    if (mfpIframe.contents().find("#divMaster4").length > 0) {
        mfpIframe.height(mfpIframe.contents().find("#divMaster4").outerHeight() + 30);
    }
    else {
        mfpIframe.height("90%");
    }
    mfpIframe.css("background", "white");

    resizePopupIframe();

    if (mfpIframe.height() < $(window).height()) {
        mfpIframe.css({ "margin": "auto", "left": "0", "right": "0", "top": "0", "bottom": "0" });
        //if(!esFireFox) $(".mfp-iframe-scaler").css("display", "table-row");
        //   $(".mfp-iframe-scaler").css("padding-top", "0px");
        //   $(".mfp-iframe-holder").css("padding-bottom", "40px");

        if (esFireFox) $(".mfp-container").css("height", "0px");
    }
    else {
        mfpIframe.css({ "margin": "0" });
        $(".mfp-iframe-scaler").css("padding-top", "56.25%");

        $(".mfp-iframe-holder").css("padding-bottom", mfpIframe.height() + 50);
    }
    $(".mfp-close").offset({ top: mfpIframe.offset().top - $(".mfp-close").height() + 35 });
    $(".mfp-close").css({ "color": "#333333", "width": "3%", "right": "3px;" });
}

function resizePopupIframe() {
    var mfpContent = $(".mfp-content");
    if (mfpContent.length == 1) {
        if ($(window).width() < 992) {
            mfpContent.css({ "width": "90%" });
        }
        else if ($(".mfp-iframe").length == 1) {
            var mfpIframe = $(".mfp-iframe");

            var iframeOptions = mfpIframe.contents().find("#iframe-options");
            if (iframeOptions.length == 1) {
                mfpContent.css({ "width": iframeOptions.attr("iframe-width"), "top": "75px" });
            }
            else {
                mfpContent.css({ "width": "90%" });
            }
        }
        else {
            mfpContent.css({ "width": "auto" });
        }
    }
}

function closeDoxPopup() {
    setTimeout(function () {
        $.magnificPopup.close();
    }, 50);

}


