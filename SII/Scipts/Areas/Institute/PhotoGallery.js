﻿function page_init_photo_gallery() { fill_grid_photo_gallery() } function page_click_photo_gallery() { $("#btnCancelPhoto").on("click", function (t) { t.preventDefault(), $("#hdfPhotoID").val("0"), $("#drpPhotoCategoryID").val(""), $("#fuPhotoImagePath").val(""), $("#txtPhotoDescription").val("") }), $("#btnNewImage").on("click", function (t) { t.preventDefault(), $("#hdfPhotoID").val("0"), $("#drpPhotoCategoryID").val(""), $("#fuPhotoImagePath").val(""), $("#txtPhotoDescription").val("") }), $("#btnSavePhoto").on("click", function (t) { t.preventDefault(); var e = $("#frmPhotoGallery"); if (e.parsley().validate(), !e.parsley().isValid()) return !1; var a = $(this); a.addClass("disabled"), a.text("Processing..."); var o = $("#fuPhotoImagePath").get(0); if (void 0 !== window.FormData && $("#fuPhotoImagePath").get(0).files.length > 0) { var n = $("#fuPhotoImagePath").get(0).files[0].size, l = ["png", "jpg", "jpeg"]; if (-1 == $.inArray($("#fuPhotoImagePath").val().split(".").pop().toLowerCase(), l)) return swal("", "Only formats are allowed : " + l.join(", "), "error"), a.text("Save"), void a.removeClass("disabled"); if (!("1048576" >= n)) return swal("", "1 Mb file size allow", "warning"), a.text("Save"), void a.removeClass("disabled") } for (var r = o.files, i = new FormData, s = 0; s < r.length; s++)i.append(r[s].name, r[s]); i.append("InstituteID", $("#hdfInstituteID").val()), i.append("CategoryID", $("#drpPhotoCategoryID").val()), i.append("Description", $("#txtPhotoDescription").val()), i.append("__RequestVerificationToken", $('input[name="__RequestVerificationToken"]', e).val()), $.ajax({ method: "POST", url: $("#hdfBaseUrl").val() + "Institute/Gallery/Save_Institute_Photo_Gallery", data: i, async: !1, cache: !1, contentType: !1, processData: !1, success: function (t) { } }).done(function (t) { "false" == t.flag.toString().toLowerCase() ? swal("Oops...!", "Image category already exists!") : swal({ title: "Success!", text: "Data saved successfully", type: "success", closeOnConfirm: !0, confirmButtonText: "OK", confirmButtonClass: "btn-primary", showLoaderOnConfirm: !0 }).then(function () { $("#btnCancelPhoto").trigger("click"), fill_grid_photo_gallery() }), a.removeClass("disabled"), a.text("Save") }).error(function () { swal("Oops...!", "Please try after some time"), a.text("Save"), a.removeClass("disabled") }), a.removeClass("disabled"), a.text("Save") }), $("#tbodyPhotoGallery").on("click", ".btnEdit", function (t) { t.preventDefault(); var e = $(this).attr("data-id"); $.ajax({ method: "GET", url: $("#hdfBaseUrl").val() + "Institute/Gallery/Select_Institute_Photo_Gallery", data: { ID: e } }).done(function (t) { $.each(t.List, function (t, e) { $("#hdfThingsToDo_ID").val(e.ID), $("#txtThingsToDo_ThingsToDo").val(e.ThingsToDo), $("#txtThingsToDo_Discription").val(e.Discription) }) }).error(function () { swal("Oops...!", "Please try after some time"), btn.text("Save"), btn.removeClass("disabled") }) }), $("#tbodyPhotoGallery").on("click", ".btnDelete", function (t) { t.preventDefault(); var e = $(this).attr("data-id"); swal({ title: "Are you sure?", text: "You will not be able to recover this data!", type: "", closeOnConfirm: !0, showCancelButton: !0, confirmButtonText: "Yes, delete it!", confirmButtonClass: "btn-warning", showLoaderOnConfirm: !0 }).then(function () { $.ajax({ method: "POST", url: $("#hdfBaseUrl").val() + "Institute/Gallery/Delete_Institute_Photo_Gallery", data: { ID: e }, success: function (t) { } }).done(function (t) { fill_grid_photo_gallery(), swal("Success!", "Your data has been deleted.") }).error(function () { swal("Oops...!", "Something went wrong from our side.") }) }) }) } function fill_grid_photo_gallery() { $.ajax({ method: "GET", url: $("#hdfBaseUrl").val() + "Institute/Gallery/Select_Institute_Photo_Gallery" }).done(function (t) { $("#tbodyPhotoGallery").html(""); var e = 1; if (t.List.length > 0) $.each(t.List, function (t, a) { var o = $("<tr></tr>"); o.append("<td>" + e++ + "</td>"), o.append("<td>" + a.CategoryName.toString() + "</td>"), o.append("<td>" + a.Description.toString() + "</td>"); var n = '<a class="btn btn-danger btnDelete" data-id="' + a.ID + '"><i class="glyphicon glyphicon-trash"></i></a>'; o.append("<td>" + n + "</td>"), $("#tbodyPhotoGallery").append(o) }); else { var a = $("<tr></tr>"); a.append('<td colspan="4">No data available.</td>'), $("#tbodyPhotoGallery").append(a) } }).error(function () { swal("Oops...!", "Please try after some time"), btn.text("Save"), btn.removeClass("disabled") }) } $(document).ready(function () { page_click_photo_gallery(), page_init_photo_gallery() });