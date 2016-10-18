


$("#postBtn").click(function () {
    AddPost();
});

getUser();
function getUser() {
    var data = {
        emailAddress: $('#EmailAddress').val()
    };
        $.ajax({
            url: UrlGetUserID,
            data : data,
            type: 'GET',
            success: function (data) {
                $("#UserID").val(data.result);
            },
            error: function(data){
                alert('error');
            }
        })
    }
    function AddLike(id) {
        var data = {
            postID: id,
            ID : $("#UserID").val()
        }
        $.ajax({
            url: UrlAddLike,
            data: data,
            type: 'GET',
            success: function (data) {
              
            },
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
