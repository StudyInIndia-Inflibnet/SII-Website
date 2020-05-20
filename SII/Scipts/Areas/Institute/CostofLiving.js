function page_event() { 
    page_click();
    Select_Costofliving()
}

function page_click() {
    $("#btnNew").on("click", function (t) {
        Clear()
    });

    $("#btnUpload").on("click", function (t) {
        var btn = $(this);
        t.preventDefault();
        
        var files = '';
        if ($("#fileUpload").get(0).files.length > 0) {
            var AllowedFileExtension = ['pdf'];
            var files = $("#fileUpload").get(0).files;
            if ($.inArray($("#fileUpload").val().split('.').pop().toLowerCase(), AllowedFileExtension) == -1) {
                swal("", "Only formats are allowed : " + AllowedFileExtension.join(', '), 'error');
                btn.text('Upload');
                btn.removeClass('disabled');
                return;
            }
        }

        var fileData = new FormData();

        for (var i = 0; i < files.length; i++) {
            fileData.append(files[i].name, files[i]);
        }

        //if (e.parsley().validate(), !e.parsley().isValid()) return !1;
        var btn = $(this);
        btn.text("Processing...");
        btn.addClass("disabled");
        $.ajax({
            url: '/Institute/Fees/UploadDoc',
            type: "POST",
            contentType: false,
            processData: false,
            data: fileData, 
            success: function (t) { }
        }).done(function (data) {
            if (data.c.toString().toLowerCase() == "success") {
                swal({
                    title: "Success!",
                    text: "File Uploaded Successfully",
                    type: "",
                    closeOnConfirm: !0,
                    confirmButtonText: "OK",
                    confirmButtonClass: "btn-primary",
                    showLoaderOnConfirm: !0
                }).then(function () { 
                    $("#btnViewFile").attr('href', data.p.toString()); 
                    $("#UploadedFilePath").val(data.p.toString());

                    $("#btnViewFile").toggle();
                });
            }
            
            btn.text("Upload");
            btn.removeClass("disabled");

        }).error(function () {
            swal("Oops...!", "Something went wrong! Please try again.");
            btn.text("Save");
            btn.removeClass("disabled");
        })

    });

    //$("#btnViewFile").on("click", function (t) {

    //    var btnViewFile = $(this);
    //    alert(btnViewFile.attr('data-UploadedFilePath'));
    //    //window.location = btnViewFile.attr('data-UploadedFilePath');
    //});
    $("#btnSave").on("click", function (t) {
        t.preventDefault();
        var e = $("#frmCostofliving");

        if (e.parsley().validate(), !e.parsley().isValid()) return !1;
        console.log(e.serialize() + '$');

        var n = $(this);
        n.text("Processing..."), n.addClass("disabled"), $.ajax({
            method: "POST",
            url: "/Institute/Fees/Save_CostofLiving",
            data: e.serialize(),
            async: !1,
            success: function (t) { }
        }).done(function (t) {
            "true" == t.flag.toString().toLowerCase() ? swal({
                title: "Success!",
                text: "Record Save Successfully",
                type: "",
                closeOnConfirm: !0,
                confirmButtonText: "OK",
                confirmButtonClass: "btn-primary",
                showLoaderOnConfirm: !0
            }).then(function () {
                Clear(), Select_Costofliving()
            }) : swal("Warning!", "Nature of cost category Exist.", "warning"), n.text("Save"), n.removeClass("disabled")
        }).error(function () {
            swal("Oops...!", "Something went wrong! Please try again."), n.text("Save"), n.removeClass("disabled")
        })
    });
    $("#tbodyCostofliving").on("click", ".btnGridEdit", function () {
        var t = $(this);
        $.ajax({
            method: "get",
            async: !1,
            url: "/Institute/Fees/Select_CostofLiving",
            data: {
                ID: t.attr("data-id")
            },
            success: function (t) { }
        }).done(function (t) {
            var e = t.List[0];
            $("#hdfID").val(e.ID);
            $("#drpNatureofcost").val(e.Natureofcostcategory_id);
            $("#txtappoxcost").val(e.ApproximatCost);
            $("#ApproximatCostType").val(e.ApproximatCostType);

            $("#btnViewFile").hide();

            if (e.UploadedFilePath == "") {
                $("#btnViewFile").hide();
            } else {
                $("#btnViewFile").show();
            }

            $("#btnViewFile").attr('href', e.UploadedFilePath); 
            $("#UploadedFilePath").val(e.UploadedFilePath);


        }).error(function () {
            swal("Oops...!", "Something went wrong! Please try again.")
        })
    });
    $("#tbodyCostofliving").on("click", ".btnDelete", function () {
        var t = $(this).attr("data-id");
        swal({
            title: "Are you sure?",
            text: "You will not be able to recover this data!",
            type: "",
            closeOnConfirm: !0,
            showCancelButton: !0,
            confirmButtonText: "Yes, delete it!",
            confirmButtonClass: "btn-warning",
            showLoaderOnConfirm: !0
        }).then(function () {
            $.ajax({
                method: "POST",
                url: "/Institute/Fees/Delete_CostofLiving",
                data: {
                    ID: t
                },
                success: function (t) { }
            }).done(function (t) {
                Select_Costofliving(), swal("Success!", "Your data has been deleted.")
            }).error(function () {
                swal("Oops...!", "Something went wrong from our side.")
            })
        })
    })

}

function Clear() {
    $("#hdfID").val(0);
    $("#drpNatureofcost").val("");
    $("#txtappoxcost").val("");
    $("#ApproximatCostType").val("");

    $("#UploadedFilePath").val("");
    $("#btnViewFile").hide();
    $("#btnViewFile").attr('href', ''); 
}

function Select_Costofliving() {
    $("#tbodyCostofliving").html("");
    $.ajax({
        method: "GET",
        async: !1,
        url: "/Institute/Fees/Select_CostofLiving",
        success: function (t) { }
    }).done(function (t) {
        var e = 1;
        $.each(t.List, function (t, n) {
            var o = $("<tr></tr>");
            o.append("<td>" + e++ + "</td>");
            o.append("<td>" + n.Natureofcostcategoryname + "</td>");
            o.append("<td>" + n.ApproximatCost + "</td>");

            editbtn = '<button class="btn btn-success btnGridEdit" title="Edit" data-toggle="tooltip" type="button" data-id="' + n.ID + '" ><i class="glyphicon glyphicon-pencil"></i></button>';
            deletebtn = '<a class="btn btn-danger btnDelete" title="Delete" data-toggle="tooltip" data-id="' + n.ID + '"><i class="glyphicon glyphicon-trash"></i></a>';
            o.append("<td>" + editbtn + "&nbsp;" + deletebtn + "</td>");
            $("#tbodyCostofliving").append(o)
        })
    }).error(function () {
        swal("Oops...!", "Something went wrong! Please try again.")
    });
}
$(document).ready(function () {
    page_event()
});