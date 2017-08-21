$(function () { 
    $('.link_like').click(function () {

        $(this).parent().find('i').removeClass('fa fa-thumbs-o-up');
        $(this).parent().find('i').addClass('fa fa-thumbs-up');
    })

})