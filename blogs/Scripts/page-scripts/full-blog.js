$(function () { 
    $('.link_like').click(function () {
        debugger;
        var likeStatus = false;
        var btnLike = $(this);
        var id = $(btnLike).data('id');
        if (id)
        {
            if ($(btnLike).parent().find('i').hasClass('fa fa-thumbs-o-up')) {
                likeStatus = true;
            }

            $.ajax({
                url: "/Home/AddLike",
                type: "Post",
                data: {id:id,status:likeStatus},
                dataType: "json",
                success: function () {
                    if (likeStatus) {
                        $(btnLike).parent().find('i').removeClass('fa fa-thumbs-o-up');
                        $(btnLike).parent().find('i').addClass('fa fa-thumbs-up');
                        $(btnLike).attr('title', 'UnLike');
                    }
                    else {
                        $(btnLike).parent().find('i').removeClass('fa fa-thumbs-up');
                        $(btnLike).parent().find('i').addClass('fa fa-thumbs-o-up');
                        $(btnLike).attr('title', 'Like');
                    }

                    
                }
                


            })

        }
       
    })

})