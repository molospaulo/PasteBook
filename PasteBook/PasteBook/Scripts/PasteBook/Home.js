$("#postBtn").click(function () {
    AddPost();
});
$("#btnRefresh").click(function () {
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
                RefreshNewsFeed()
            }
                ,
            error: function (data) {
                alert(data)
            }

        })
    }
    function AddPost(profileID,userID) {
        var data = {
            userId : userID,
            post: $("#txtAreaPost").val(),
            ProfileOwnerID: profileID,
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

    function AddComment(postID, posterID,button) {
       
        alert();
        var data = {
            postID: postID,
            posterID: posterID,
            content: $("#txtAreaComment_".concat(button.value)).val()
        }
        $.ajax({
            url: UrlAddComment,
            data: data,
            type: 'GET',
            success: function (data) {
                alert(data.result)
            },
            error: function (data) {
                alert('lol')
            }



        });
    }
    function RefreshNewsFeed() {
                $("#newsFeed").load(UrlRefreshNewsFeed)
         
    }
