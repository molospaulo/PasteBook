
function AddFriend(userID, friendID) {
var data = {
        userID: userID,
        friendID, friendID
    }
    $.ajax({
        url:UrlAddFriend,
        data: data,
        type: 'GET',
        success: function (data) {
            $("#friendRequestBtn").load(UrlRefreshRequest);
        },
        error: function (data) {
           
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
            $("#friendRequestBtn").load(UrlRefreshRequest);
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
        url: UrlRejectFriend,
        data: data,
        type: 'GET',
        success: function (data) {
            $("#friendRequestBtn").load(UrlRefreshRequest);
        },
        error: function (data) {

        }

    })

}
$('#myFile').bind('change', function () {
    alert(this.files[0].size);
    var fileExtension = ['jpeg', 'jpg', 'png', 'gif', 'bmp'];
    if ($.inArray($(this).val().split('.').pop().toLowerCase(), fileExtension) == -1) {
        alert("Only formats are allowed : " + fileExtension.join(', '));
    } else {
        var reader = new FileReader();
        reader.onload = function (e) {
            $('#imagePreview').attr('src', e.target.result);
        }
        reader.readAsDataURL($(this)[0].files[0]);
    }

});