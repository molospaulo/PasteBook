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
    function RefreshNewsFeed() {
                $("#newsFeed").load(UrlRefreshNewsFeed)
         
    }
