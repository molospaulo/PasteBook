$("#postBtn").click(function () {
    AddPost();
});
$("#btnRefresh").click(function () {
    RefreshNewsFeed();

})
var activeTab = $("#activeTab").data("activeTab")

function AddOrDeleteLike(id) {
        var data = {
            postID: id,
            //ID : $("#UserID").val()
        }
        $.ajax({
            url: UrlAddLike,
            data: data,
            type: 'GET',
            success: function (data) {
                RefreshNewsFeed()
                RefreshTimeline()
            }
                ,
            error: function (data) {
                alert(data)
            }

        })
}
function AddOrDeleteLikePost(id) {
    var data = {
        postID: id,
        //ID : $("#UserID").val()
    }
    $.ajax({
        url: UrlAddLike,
        data: data,
        type: 'GET',
        success: function (data) {
            location.reload();
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

    function AddComment(postID, posterID, button) {
        var result = $('#txtAreaComment_'.concat(button.value)).val();
        
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
                RefreshNewsFeed();
                RefreshTimeline();
            },
            error: function (data) {
                alert('lol')
            }
        });
    }
    function AddCommentPost(postID, posterID, button) {
        var result = $('#txtAreaComment_'.concat(button.value)).val();

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
               location.reload()
            },
            error: function (data) {
                alert('lol')
            }
        });
    }
    function UploadImage() {
        var filename = $('input[type=file]')[0].files[0].name;
        var data = { image: filename}
        $.ajax({
            url: '/Home/AddPic',
            data: data,
            type: 'GET',
            success: function (data) {
                $("#imageContent").src("");
            },
            error: function (data) {
            }



        })
    }

    $("#btnUpload").click(function () {
        UploadImage();
    });
    

    function RefreshNewsFeed() {
        $("#newsFeed").load(UrlRefreshNewsFeed)
         
    }
    function RefreshTimeline() {
        $("#timelineFeed").load(UrlRefreshTimeLine)

    }
    function PreviewImage() {
        var filename = $('input[type=file]')[0].files[0].name;
        $("#imageContent").attr("src", filename);

    }
    function GetValue(a) {
        var result = a.value
    }