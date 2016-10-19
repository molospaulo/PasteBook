


$("#postBtn").click(function () {
    //alert('lol');
    AddPost();
});
$("#btnRefresh").click(function () {
    //alert('refresh');
    RefreshNewsFeed();

})
function AddOrDeleteLike(id) {
        var data = {
            postID: id,
            ID : $("#UserID").val()
        }
        $.ajax({
            url: UrlAddLike,
            data: data,
            type: 'GET',
            success: function (data) {
                if (data.status == "deletelike") {
                    $(this).css("color","")
                    $(this).css("color","")
                } else if (data.status == "addlike") {
                    $(this).css("color","blue")
                    $(this).css("color","blue")
                }
            }
                ,
            error: function (data) {
                alert(data)
            }

        })
    }
    function AddPost() {
        var data = {
            userId : $("#UserID").val(),
            post: $("#txtAreaPost").val(),
            profileOwnerID: $("#UserID").val(),
        }

        $.ajax({
            url: UrlAddPost,
            data :data,
            type: 'GET',
            
            success: function(data){
                $("#txtAreaPost").val("");
            },
            error: function(data){

            }
        })
}
    function RefreshNewsFeed() {
        $.ajax({
            url: UrlRefreshNewsFeed,
            type: 'GET',
            success: function (data) {
                //alert('success')
                $("#newsFeed").html(data)
            },
            error: function (data) {
                alert('error')
            }
        })
    }
