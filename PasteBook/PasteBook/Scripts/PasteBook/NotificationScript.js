function showNotifs() {
    $("#notifDropdown").load('/Home/NotificationView');
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
    $.ajax({
        url: '/Home/SeenFriendNotif',
        type: 'GET',
        success: function (data) {

        },
        error: function (data) {

        }



    })

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