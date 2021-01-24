$(document).ready(function () {
    BackToTopButton('#btnTop');
});

function hasNull(target) {
    /// <summary>
    /// Checking the object null value(s)
    /// </summary>
    /// <param name="target" type="object">Json Object Details</param>
    /// <returns type="boolean">Returns True or False</returns>

    for (var member in target) {
        if (target[member] === '' || target[member] === undefined || target[member] === null) {
            return true;
        }
    }
    return false;
}

function IsEmpty(value) {
    if (value === null || value.toString().toLowerCase() === 'null' || value === '' || value.toString().toLowerCase() === undefined) {
        return true;
    } else {
        return false;
    }
}

function AddMultipleDataRow(table, data) {
    $.each(data, function (index, value) {
        table.row.add(value).draw('false');
    });
}
function BackToTopButton(buttonId) {
    /// <summary>
    /// Back the page to top
    /// </summary>
    /// <param name="buttonId">Button id</param>
    $(window).scroll(function () {
        var height = $(window).scrollTop();

        if (height > 100) {
            $(buttonId).fadeIn();
        }
        else {
            $(buttonId).fadeOut();
        }
    });

    $(buttonId).click(function (event) {
        event.preventDefault();
        $('html, body').animate({ scrollTop: 0 }, 'slow');

        return false;
    });
};

function SetCookie(cname, cvalue, exdays) {
    /// <summary>
    /// Set Cookie
    /// </summary>
    /// <param name="cname">Cookie name</param>
    /// <param name="cvalue">Cookie value</param>
    /// <param name="exdays">Expiration day</param>
    var d = new Date();
    d.setTime(d.getTime() + (exdays * 24 * 60 * 60 * 1000));
    var expires = "expires=" + d.toUTCString();
    if (cname && cvalue) { document.cookie = cname + "=" + cvalue + ";" + expires + ";path=/"; };
}

function GetCookie(cname) {
    /// <summary>
    /// Gets Cookie
    /// </summary>
    /// <param name="cname">Cookie Name</param>
    /// <returns type=""></returns>
    var name = cname + "=";
    var ca = document.cookie.split(';');
    for (var i = 0; i < ca.length; i++) {
        var c = ca[i];
        while (c.charAt(0) == ' ') {
            c = c.substring(1);
        }
        if (c.indexOf(name) == 0) {
            return c.substring(name.length, c.length);
        }
    }
    return "";
}

function DeleteCookie(cname) {
    /// <summary>
    /// Deletes Cookie
    /// </summary>
    /// <param name="cname">Cookie Name</param>

    if (cname !== '*') {
        document.cookie = cname + "=;Path=/;Expires=Thu, 01 Jan 1970 00:00:01 GMT;";
    } else {
        var cookies = document.cookie.split(";");

        for (var i = 0; i < cookies.length; i++) {
            var cookie = cookies[i];
            var eqPos = cookie.indexOf("=");
            var name = eqPos > -1 ? cookie.substr(0, eqPos) : cookie;
            document.cookie = name + "=;Path=/;Expires=Thu, 01 Jan 1970 00:00:01 GMT;";
        }
    }
};