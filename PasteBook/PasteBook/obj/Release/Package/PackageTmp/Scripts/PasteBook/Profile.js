$('#btnUploadImage').prop('disabled', true);
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
    if (this.files[0].size <= 2097152) {
        var fileExtension = ['jpeg', 'jpg', 'png'];
        if ($.inArray($(this).val().split('.').pop().toLowerCase(), fileExtension) == -1) {
            $('#errorUploadImage').text('File extension is invalid, it only accept jpeg,jpg and png extensions')
            $('#btnUploadImage').prop('disabled', true);
        } else {
            $('#btnUploadImage').prop('disabled', false);
            $('#errorUploadImage').text('')
            var reader = new FileReader();
            reader.onload = function (e) {
                $('#imagePreview').attr('src', e.target.result);
            }
            reader.readAsDataURL($(this)[0].files[0]);
        }
    } else {
        $('#errorUploadImage').text('File size is too large, maximum size is 2 Mb')
    }

});
$('#btnAddProfilePic').click(function () {
    $('#modalUploadPic').modal('show');
    $('#myFile').val("");
    $('#imagePreview').attr('src', '#');
});