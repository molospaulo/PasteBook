$("#postBtn").click(function () {
    AddPost();
});
$("#btnRefresh").click(function () {
    RefreshNewsFeed();

})
$("#txtAreaPost").click(function () {
    $("#txtAreaPost").css('border-color', 'blue');
})
$("#txtAreaPost").blur(function () {
    $("#txtAreaPost").css('border-color', '');
})
var activeTab = $("#activeTab").data("activeTab")

function AddOrDeleteLike(id) {
        var data = {
            postID: id,
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
function AddPost(profileID, userID) {
    var post = $("#txtAreaPost").val().trim();
    if (post == "") {
        $("#txtAreaPost").css('border-color', 'red');
    } else {
        var data = {
            userId: userID,
            post: post,
            ProfileOwnerID: profileID,
        }

        $.ajax({
            url: UrlAddPost,
            data: data,
            type: 'GET',

            success: function (data) {
                $("#txtAreaPost").val("");
                $("#txtAreaPost").css('border-color', ' ');
                RefreshNewsFeed();
                RefreshTimeline();
            
            },
            error: function (data) {

            }
        })
    }
    }

    function AddComment(postID, posterID, button) {
        var result = $('#txtAreaComment_'.concat(button.value)).val();
        if (result.trim() != "") {
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
                
                }
            });
        } else {
            $('#txtAreaComment_'.concat(button.value)).css('border-color', 'red');
        }
    }
    function AddCommentPost(postID, posterID, button) {
        var result = $('#txtAreaComment_'.concat(button.value)).val();
        if (result.trim != "") {
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
        } else {
            $('#txtAreaComment_'.concat(button.value)).css('border-color', 'red');
        }
    }

    

    function RefreshNewsFeed() {
        $("#newsFeed").load(UrlRefreshNewsFeed)
         
    }
    function RefreshTimeline() {
        $("#timelineFeed").load(UrlRefreshTimeline)

    }