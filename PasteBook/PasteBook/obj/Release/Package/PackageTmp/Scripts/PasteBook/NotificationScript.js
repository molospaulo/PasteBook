
function showNotifs() {
    $("#notifDropdown").load(UrlNotificationView);
    $.ajax({
        url:UrlSeenNotif,
        type: 'GET',
        success: function (data) {
            
        },
        error: function (data) {
            
        }
    })

    
    }

    
function GetNotificationCount() {

        $.ajax({
            url: UrlGetNotificationCount,
            type: 'GET',
            success: function (data) {
                $("#notifCount").text(data.result);
            },
            error: function (data) {

            }
        });
    }


function RefreshNewsFeed() {
    $("#newsFeed").load(UrlRefreshNewsFeed)

}
 
        setInterval(function () {
            GetNotificationCount();
        }, 2000)
        setInterval(function () {
            RefreshNewsFeed()
        },60000)