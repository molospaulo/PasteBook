
ConvertDate();
function ConvertDate() {
    $(".date").each(function () {
        var date = $(this).text();
        var result = moment(date).format('LLLL');

        $(this).text(result);

    })
}
function showNotifs() {
    $("#notifDropdown").load('/Home/NotificationView');
    ConvertDate();
    $.ajax({
        url: '/Home/SeenNotif',
        type: 'GET',
        success: function (data) {

        },
        error: function (data) {
            
        }
    })

    
    }
function showFriendNotifs() {
    $("#frienNotifDropdown").load('/Home/FriendRequestView')
    }
    
function GetNotificationCount() {

        var data = { user: $("#UserID").val() }
        $.ajax({
            url: '/Home/GetNotifCount',
            data: data,
            type: 'GET',
            success: function (data) {
                $("#notifCount").text(data.result);
            },
            error: function (data) {

            }
        });
    }
function GetFriendRequestCount() {
 
                var data = {user : $("#UserID").val()}
                $.ajax({
                    url: '/Home/GetFriendRequestCount',
                    data:data,
                    type: 'GET',
                    success: function (data) {
                        $("#friendRequestCount").text(data.result);
                    },
                    error: function (data) {

                    }
                });
          
            }
         GetFriendRequestCount();
        GetNotificationCount();
        //var i = setInterval(function () { GetNotification() }, 2000);
//});