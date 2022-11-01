

$(".our-causes .owl-carousel").owlCarousel({
    loop: false,
    margin: 10,
    nav: false,
    responsive: {
        0: {
            items: 1,
        },
        480: {
            items: 2,
        },
        768: {
            items: 3,
        },
        992: {
            items: 3,
        },
        1200: {
            items: 3
        }
    }
});

$(".causes-galery .owl-carousel").owlCarousel({
    loop: true,
    margin: 10,
    nav: false,
    autoplay: false,
    responsiveClass:true,
    responsive: {
        0: {
            items: 1,
        },
        380: {
            items: 1,
        },
        480: {
            items: 2,
        },
        678: {
            items: 3,
        },
        992: {
            items: 3,
        },
        1200: {
            items: 4,
        },
    },
});

window.addEventListener("scroll", (e) => {
    e.preventDefault();
    if (window.pageYOffset > 100) {
        document.querySelector(".main-navbar").classList.add("active");
    } else {
        document.querySelector(".main-navbar").classList.remove("active");
    }
});

//   Got top start
let Top = document.querySelector(".go-top");

window.addEventListener("scroll", (e) => {
    if (window.pageYOffset > 500) {
        Top.classList.add("active");
    } else {
        Top.classList.remove("active");
    }
});
Top.addEventListener("click", (e) => {
    window.scrollTo(0, 0);
});

//   Got top end

// Show More start

$(function() {
    // causes to show
    var increment = 5;

    var startFilter = 0;
    var endFilter = increment;

    // causeslist selector
    var $this = $(".causes");

    var elementLength = $this.find("div").length;
    $(".listLength").text(elementLength);

    // show/hide the Load More button
    if (elementLength > 2) {
        $(".buttonToogle").show();
    }

    $(".causes .causeslist").slice(startFilter, endFilter).addClass("shown");
    $(".shownLength").text(endFilter);
    $(".causes .causeslist").not(".shown").hide();
    $(".buttonToogle .showMore").on("click", function() {
        if (elementLength > endFilter) {
            startFilter += increment;
            endFilter += increment;
            $(".causes .causeslist")
                .slice(startFilter, endFilter)
                .not(".shown")
                .addClass("shown")
                .toggle(500);
            $(".shownLength").text(
                endFilter > elementLength ? elementLength : endFilter
            );
            if (elementLength <= endFilter) {
                $(this).remove();
            }
        }
    });
});

// Show More end


$(document).ready(function() {
    $(".image-popup-vertical-fit").magnificPopup({
        type: "image",
        closeOnContentClick: true,
        mainClass: "mfp-img-mobile",
        image: {
            verticalFit: true,
        },
    });
});


// Accardion start

const accordion = document.getElementsByClassName("accordion-item");
const accordiontitle = document.getElementsByClassName("accordion-title");

for (let i = 0; i < accordiontitle.length; i++) {
    accordiontitle[i].addEventListener("click", (e) => {
        e.preventDefault();

        for (let j = 0; j < accordion.length; j++) {
            if (!accordion[i].classList.contains("active")) {
                accordion[j].classList.remove("active");
            }
        }
        accordion[i].classList.toggle("active");
    });
}




// Accardion end

// Accardion click start
// let SectionAccordionPrivate = document.querySelectorAll(".section-accordion-private");
// let tab1 = document.getElementById("tab1");
// let tab2 = document.getElementById("tab2");
// let one = document.getElementById("one");
// let two = document.getElementById("two");

// tab1.addEventListener("click", (e) => {
//   e.preventDefault();

//   one.style.color = "#fff";
//   tab1.style.borderColor = "#f83730";
//   tab1.style.backgroundColor = "#f83730";

//   tab2.style.borderColor = "#666";
//   two.style.color = "#666";
//   tab2.style.backgroundColor = "#fff";

//   for (let i = 0; i < SectionAccordionPrivate.length; i++) {
//     SectionAccordionPrivate[i].classList.remove("art");
//   }
// });

// tab2.addEventListener("click", (e) => {
//   e.preventDefault();

//   one.style.color = "#666";
//   tab1.style.borderColor = "#666";
//   tab1.style.backgroundColor = "#fff";

//   tab2.style.borderColor = "#f83730";
//   two.style.color = "#fff";
//   tab2.style.backgroundColor = "#f83730";

//   for (let i = 0; i < SectionAccordionPrivate.length; i++) {
//     SectionAccordionPrivate[i].classList.add("art");
//   }
// });

// Accardion click end

var open21 = document.getElementsByClassName("default")[0];
var donate = document.getElementsByClassName("donate-form")[0];
var close21 = document.getElementById("close");
var body21 = document.getElementsByTagName("body")[0];

open21.addEventListener("click", () => {
    donate.style.opacity = "1";
    donate.style.visibility = "visible";
    body21.style.overflow = "hidden";
});

close21.addEventListener("click", () => {
    donate.style.opacity = "0";
    donate.style.visibility = "hidden";
    body21.style.overflow = "auto";
});

// Donate 10$ 20$
//var label21 = document.getElementsByClassName("button");
//var input21 = document.getElementsByName("donor[amount]");

//for (let i = 0; i < input21.length; i++) {
//    input21[i].addEventListener("click", (e) => {
//        e.preventDefault();

//        for (let j = 0; j < label21.length; j++) {
//            if (!label21[i].classList.contains("active")) {
//                label21[j].classList.remove("active");
//            }
//        }
//        label21[i].classList.add("active");
//    });
//}

var ar = $(".donor22");

$(".donor22").click(function () {

    for (var i = 0; i < ar.length; i++) {

        ar[i].classList.remove("active");

    }

    $(this).addClass("active");

})




