
function AddFriend(userID,friendID) {

    var data = {
        userID: userID,
        friendID,friendID
    }
    $.ajax({
        url: UrlAddFriend,
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
        url: UrlAcceptFriend,
        data: data,
        type: 'GET',
        success: function (data) {

        },
        error: function (data) {
            alert('error')
        }

    })


}