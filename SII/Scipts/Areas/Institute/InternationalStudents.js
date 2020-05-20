﻿function page_init() { fill_details() } function ChangeEvent() { $("#drpcelloffice").on("change", function (e) { "1" == $("#drpcelloffice").val() ? ($("#cellbrief").show(), $("#textStudentCell").attr("required")) : ($("#cellbrief").hide(), $("#textStudentCell").removeAttr("required")) }), $("#drpvisassistance").on("change", function (e) { "1" == $("#drpvisassistance").val() ? ($("#visabrief").show(), $("#textStudentCell").attr("required")) : ($("#visabrief").hide(), $("#textStudentCell").removeAttr("required")) }) } function page_click() { $("#btnSaveStudentFacility").on("click", function (e) { e.preventDefault(); var t = $("#frmStudentFacility"); if (t.parsley().validate(), !t.parsley().isValid()) return !1; var a = $(this); a.addClass("disabled"), a.text("Processing..."), $.ajax({ method: "POST", url: $("#hdfBaseUrl").val() + "Institute/InternationalStudents/Save_StudentFacility", data: t.serialize(), async: !1 }).done(function (e) { "false" == e.flag.toString().toLowerCase() ? (swal("Oops...!", "Something went wrong! Please try again."), a.text("Save"), a.removeClass("disabled")) : swal({ title: "Success!", text: "Data saved successfully", type: "", closeOnConfirm: !0, confirmButtonText: "OK", confirmButtonClass: "btn-primary", showLoaderOnConfirm: !0 }).then(function () { clear(), fill_details() }), a.removeClass("disabled"), a.text("Save") }).error(function () { swal("Oops...!", "Something went wrong! Please try again."), a.text("Save"), a.removeClass("disabled") }), a.removeClass("disabled"), a.text("Save") }) } function fill_details() { $.ajax({ method: "GET", url: $("#hdfBaseUrl").val() + "Institute/InternationalStudents/Select_InternationalSchool" }).done(function (e) { $.each(e.List, function (e, t) { $("#hdfID").val(t.ID), "true" == t.HasCellOffice.toString().toLowerCase() ? ($("#drpcelloffice").val("1"), $("#drpcelloffice").trigger("change")) : ($("#drpcelloffice").val("0"), $("#drpcelloffice").trigger("change")), "true" == t.HasVisaAssistance.toString().toLowerCase() ? ($("#drpvisassistance").val("1"), $("#drpvisassistance").trigger("change")) : ($("#drpvisassistance").val("0"), $("#drpvisassistance").trigger("change")), $("#textStudentCell").val(t.CellOfficeDesc), $("#textVisaAssistanceFacilities").val(t.VisaAssistanceDesc), "true" == t.HasCulturalEngagement.toString().toLowerCase() && $("#chkcultural").prop("checked", !0), "true" == t.HasStudentBoarding.toString().toLowerCase() && $("#chkboarding").prop("checked", !0), "true" == t.HasArrival.toString().toLowerCase() && $("#chkarrivalwelcome").prop("checked", !0), "true" == t.IntroProgram.toString().toLowerCase() && $("#chkinduction").prop("checked", !0), $("#txtname").val(t.ContactPersonName), $("#txtemail").val(t.ContactPersonEmail), $("#txtmobile").val(t.ContactPersonMobile), $("#txtphone").val(t.ContactPersonPhone) }) }).error(function () { swal("Oops...!", "Please try after some time"), btn.text("Save"), btn.removeClass("disabled") }) } $(document).ready(function () { page_click(), page_init(), ChangeEvent() });