!function (e) { "use strict"; jQuery(document).ready(function (e) { e.fn.owlCarousel && (e(".hero-slide").owlCarousel({ loop: !0, items: 1, autoplay: !0, dots: !0, nav: !1, autoplayTimeout: 3e3 }), e(".hero-slide").on("translate.owl.carousel", function () { e(".hero-bg img").removeClass("animated fadeInRight").css("opacity", "0"), e(".hero-single-slide h1, .hero-single-slide h4").removeClass("animated fadeInLeft").css("opacity", "0"), e(".hero-single-slide .slide-btn").removeClass("animated fadeInRight").css("opacity", "0") }), e(".hero-slide").on("translated.owl.carousel", function () { e(".hero-bg img").addClass("animated fadeInRight").css("opacity", "1"), e(".hero-single-slide h1, .hero-single-slide h4, .hero-single-slide a").addClass("animated fadeInLeft").css("opacity", "1"), e(".hero-single-slide .slide-btn").addClass("animated fadeInRight").css("opacity", "1") })), e.fn.owlCarousel && e(".about-carousel-left-slide").owlCarousel({ loop: !0, items:3, autoplay: !0, margin: 22, dots: !1, nav: !0, navText: ['<i class="zmdi zmdi-long-arrow-left"></i>', '<i class="zmdi zmdi-long-arrow-right"></i>'], responsiveClass: !0, responsive: { 0: { items: 1 }, 600: { items: 1 } } }), e.fn.owlCarousel && e(".about-carousel-right-slide").owlCarousel({ loop: !0, items: 1, autoplay: !0, dots: !1, nav: !0, navText: ['<i class="zmdi zmdi-long-arrow-left"></i>', '<i class="zmdi zmdi-long-arrow-right"></i>'] }), e.fn.owlCarousel && e(".another-story-slide").owlCarousel({ loop: !0, items: 1, autoplay: !0, dots: !0, nav: !1, margin: 30, responsiveClass: !0, responsive: { 0: { items: 1 }, 600: { items: 1 }, 1e3: { items: 1 } } }), e.fn.niceSelect && e(".select-option").niceSelect(), e.fn.countTo && e(".counter-area").on("inview", function (i, s, o, a) { s && (e(this).find(".counter-active").each(function () { var i = e(this); e({ Counter: 0 }).animate({ Counter: i.text() }, { duration: 5e3, easing: "swing", step: function () { i.text(Math.ceil(this.Counter)) } }) }), e(this).off("inview")) }), e.fn.slicknav && e(".mainmenu-area ul").slicknav({ prependTo: ".responsive_menu", label: "" }) }), jQuery(window).load(function () { (new WOW).init(), e("#loading").delay(1500).fadeOut("slow", function () { e(this).remove() }) }) }(jQuery);