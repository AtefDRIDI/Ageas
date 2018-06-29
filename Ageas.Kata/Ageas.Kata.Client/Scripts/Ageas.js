
    $(document).ready(function () {

        //

        $("#Delete").click(function () {

            checkedIds = $(".ckb").filter(":checked").map(function () { return this.id; });
            $.ajax({
                type: "POST",
                url: "/Ageas/DeleteUsers",
                traditional: true,
                data: { Ids: checkedIds.toArray() },
                success: successFunc,
                error: errorFunc

            });

            function successFunc(data, status) {
                // alert(data);
                // location.reload();
                $("#Data").html(data);
                BindSelectAll()
            }

            function errorFunc() {
                alert('error');
            }

        });


    $("#SendEmails").click(function () {
        checkedIds = $(".ckb").filter(":checked").map(function () { return this.id; });
    $.ajax({
        type: "POST",
        url: "/Ageas/SendEmails",
    traditional: true,
                data: {Ids: checkedIds.toArray()},
success: successFunc,
error: errorFunc

});

        function successFunc(data, status) {

        $("#Data").html(data);
    BindSelectAll();
}

            function errorFunc() {
        $("#Data").html(data);
    alert('error');
}

});


     $("#approuveUsers").click(function () {
        checkedIds = $(".ckb").filter(":checked").map(function () { return this.id; });
    $.ajax({
        type: "POST",
        url: "/Ageas/ApprouveUsers",
    traditional: true,
                data: {Ids: checkedIds.toArray()},
success: successFunc,
error: errorFunc

});

        function successFunc(data, status) {

        $("#Data").html(data);
    BindSelectAll();
}

            function errorFunc() {
        $("#Data").html(data);
    alert('error');
}

});

         $("#approuveUsersMock").click(function () {
        checkedIds = $(".ckb").filter(":checked").map(function () { return this.id; });
    $.ajax({
        type: "POST",
        url: "/Ageas/ApprouveUsersMock",
    traditional: true,
                data: {Ids: checkedIds.toArray()},
success: successFunc,
error: errorFunc

});

        function successFunc(data, status) {

        $("#Data").html(data);
    BindSelectAll();
}

            function errorFunc() {
        $("#Data").html(data);
    alert('error');
}

});

});






    function BindSelectAll() {
        $("#selectall").click(function (event) {
            if (this.checked) {
                $('.ckb').each(function () {
                    this.checked = true;
                });
            } else {
                $('.ckb').each(function () {
                    this.checked = false;
                });

            }
        });

    }



