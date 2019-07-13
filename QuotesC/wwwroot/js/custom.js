$(document).ready(function () {
    var html_click_avail = true;
    $("html").on("click", function () {
        if (html_click_avail)
            $(".x-navigation-horizontal li,.x-navigation-minimized li").removeClass('active');
    });

    $(".x-navigation-horizontal .panel").on("click", function (e) {
        e.stopPropagation();
    });

    /* WIDGETS (DEMO)*/
    $(".widget-remove").on("click", function () {
        $(this).parents(".widget").fadeOut(400, function () {
            $(this).remove();
            $("body > .tooltip").remove();
        });
        return false;
    });
    /* END WIDGETS */

    /* Gallery Items */
    $(".gallery-item .iCheck-helper").on("click", function () {
        var wr = $(this).parent("div");
        if (wr.hasClass("checked")) {
            $(this).parents(".gallery-item").addClass("active");
        } else {
            $(this).parents(".gallery-item").removeClass("active");
        }
    });
    $(".gallery-item-remove").on("click", function () {
        $(this).parents(".gallery-item").fadeOut(400, function () {
            $(this).remove();
        });
        return false;
    });
    $("#gallery-toggle-items").on("click", function () {

        $(".gallery-item").each(function () {

            var wr = $(this).find(".iCheck-helper").parent("div");

            if (wr.hasClass("checked")) {
                $(this).removeClass("active");
                wr.removeClass("checked");
                wr.find("input").prop("checked", false);
            } else {
                $(this).addClass("active");
                wr.addClass("checked");
                wr.find("input").prop("checked", true);
            }

        });

    });
    /* END Gallery Items */

});

/* X-NAVIGATION CONTROL FUNCTIONS */
function x_navigation_onresize() {

    var inner_port = window.innerWidth || $(document).width();

    if (inner_port < 1025) {
        $(".page-sidebar .x-navigation").removeClass("x-navigation-minimized");
        $(".page-container").removeClass("page-container-wide");
        $(".page-sidebar .x-navigation li.active").removeClass("active");


        $(".x-navigation-horizontal").each(function () {
            if (!$(this).hasClass("x-navigation-panel")) {
                $(".x-navigation-horizontal").addClass("x-navigation-h-holder").removeClass("x-navigation-horizontal");
            }
        });


    } else {
        if ($(".page-navigation-toggled").length > 0) {
            x_navigation_minimize("close");
        }

        $(".x-navigation-h-holder").addClass("x-navigation-horizontal").removeClass("x-navigation-h-holder");
    }

}

function x_navigation_minimize(action) {

    if (action == 'open') {
        $(".page-container").removeClass("page-container-wide");
        $(".page-sidebar .x-navigation").removeClass("x-navigation-minimized");
        $(".x-navigation-minimize").find(".fa").removeClass("fa-indent").addClass("fa-dedent");
        $(".page-sidebar.scroll").mCustomScrollbar("update");
    }

    if (action == 'close') {
        $(".page-container").addClass("page-container-wide");
        $(".page-sidebar .x-navigation").addClass("x-navigation-minimized");
        $(".x-navigation-minimize").find(".fa").removeClass("fa-dedent").addClass("fa-indent");
        $(".page-sidebar.scroll").mCustomScrollbar("disable", true);
    }

    $(".x-navigation li.active").removeClass("active");

}

function x_navigation() {

    $(".x-navigation-control").click(function () {
        $(this).parents(".x-navigation").toggleClass("x-navigation-open");

        onresize();

        return false;
    });

    if ($(".page-navigation-toggled").length > 0) {
        x_navigation_minimize("close");
    }

    $(".x-navigation-minimize").click(function () {

        if ($(".page-sidebar .x-navigation").hasClass("x-navigation-minimized")) {
            $(".page-container").removeClass("page-navigation-toggled");
            x_navigation_minimize("open");
        } else {
            $(".page-container").addClass("page-navigation-toggled");
            x_navigation_minimize("close");
        }

        onresize();

        return false;
    });

    $(".x-navigation  li > a").click(function () {

        var li = $(this).parent('li');
        var ul = li.parent("ul");

        ul.find(" > li").not(li).removeClass("active");

    });

    $(".x-navigation li").click(function (event) {
        event.stopPropagation();

        var li = $(this);

        if (li.children("ul").length > 0 || li.children(".panel").length > 0 || $(this).hasClass("xn-profile") > 0) {
            if (li.hasClass("active")) {
                li.removeClass("active");
                li.find("li.active").removeClass("active");
            } else
                li.addClass("active");

            onresize();

            if ($(this).hasClass("xn-profile") > 0)
                return true;
            else
                return false;
        }
    });

    /* XN-SEARCH */
    $(".xn-search").on("click", function () {
        $(this).find("input").focus();
    })
    /* END XN-SEARCH */

}
/* EOF X-NAVIGATION CONTROL FUNCTIONS */