$( document ).ready(function() {
	//var loc = $(".item-compare:odd").addClass("item-par");
	//alert(loc);
    LoadEvenData()
});

function LoadEvenData() {
    $(".item-compare:even").addClass("item-par");
    $(".thumbs-all .col-sm-3").each(function (index) {
        $(this).find(".btn-primary:eq(0)").css("border-left", "0");
    });
}