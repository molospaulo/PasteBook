
function AddFriend(userID,friendID) {

    var data = {
        userID: userID,
        friendID,friendID
    }
    $.ajax({
        url: '/Home/AddFriend',
        data: data,
        type: 'GET',
        success: function (data) {
          alert(data.result)
        },
        error: function (data) {
            alert('error')
        }

    })


}
function AcceptFriend(userID, friendID) {

    var data = {
        userID: userID,
        friendID, friendID
    }
    $.ajax({
        url: '/Home/AcceptFriend',
        data: data,
        type: 'GET',
        success: function (data) {

        },
        error: function (data) {

        }

    })


}
function RejectFriend(userID, friendID) {

    var data = {
        userID: userID,
        friendID, friendID
    }
    $.ajax({
        url: '/Home/RejectFriend',
        data: data,
        type: 'GET',
        success: function (data) {

        },
        error: function (data) {

        }

    })


}
  
    function UploadImage() {

        var data = { image: $("#image").val() }
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
