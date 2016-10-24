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

    function AddComment(postID, posterID, button) {
        var lol = $("#lol").text()  
        var result = $('#txtAreaComment_'.concat(button.value)).val();
        alert(result)
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
                //$("#txtAreaComment_".concat(button.value)).val()
                RefreshNewsFeed();
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
                alert("error")
            }



        })
    }
    $("#btnUpload").click(function () {
        UploadImage();
    });
    

    function RefreshNewsFeed() {
        $("#newsFeed").load(UrlRefreshNewsFeed)
         
    }
    function PreviewImage() {
        var filename = $('input[type=file]')[0].files[0].name;
        $("#imageContent").attr("src", filename);

    }