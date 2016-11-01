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
    $("#errorMessagePost").text("")

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
    var postLength = post.length;
    if (post != "") {
       
        if (postLength > 1000) {
            $("#errorMessagePost").text("You cannot post more than 1000 characters text")
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
    } else {
        $("#errorMessagePost").text("You cannot post an empty field")
        $("#txtAreaPost").css('border-color', 'red');
    }
    }

function AddComment(postID, posterID, button) {
   
        var result = $('#txtAreaComment_'.concat(button.value)).val();
        if (result.trim() != "") {
            if (result.length > 1000) {
                $("#errorMessageComment_".concat(button.value)).text("You cannot comment more than 1000 characters text");
        
            } else {
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
                        $("#errorMessageComment_".concat(button.value)).text("ErrorProcessing");
                    
                    }
                });
            }
        } else {
      
            $("#errorMessageComment_".concat(button.value)).text("You cannot comment an empty field");
        }
}

function AddCommentPost(postID, posterID, button) {

    var result = $('#txtAreaComment_'.concat(button.value)).val();
    if (result.trim() != "") {
        if (result.length > 1000) {
            $("#errorMessageComment_".concat(button.value)).text("You cannot comment more than 1000 characters text");
        
        } else {
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
                    $("#errorMessageComment_".concat(button.value)).text("ErrorProcessing");
              
                }
            });
        }
    } else {

        $("#errorMessageComment_".concat(button.value)).text("You cannot comment an empty field");
     
    }
}
   
    

    function RefreshNewsFeed() {
        $("#newsFeed").load(UrlRefreshNewsFeed)
         
    }
    function RefreshTimeline() {
        $("#timelineFeed").load(UrlRefreshTimeline)

    }

    function CommentValidate(postID, receiverID) {
        var test = $('#textarea_'.concat(postID)).val();
        if (jQuery.test.length > 0) {
            if (jQuery.test.length > 1000) {
                $('#comment-validation_'.concat(postID)).text('You cannot comment more than 1000 characters');
            }
            else {
                CreateComment(postID, receiverID);
            }
        }
        else {
            $('#comment-validation_'.concat(postID)).text('You cannot comment an empty field');
        }
    }