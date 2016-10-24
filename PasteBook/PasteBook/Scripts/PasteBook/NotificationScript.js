$(document).ready(function () {
    //var date = moment();
    //var NowMoment = moment(date, "YYYYMMDD").fromNow(); // 5 years ago;
    //$("#date").text(NowMoment);
   
    
        function GetNotification() {
            var data = {user : 9}
            $.ajax({
                url: '/Home/GetNotifCount',
                data:data,
                type: 'GET',
                success: function (data) {
                    $("#notifCount").text(data.result);
                },
                error: function (data) {

                }
            });

            $("#notifBox").load('/Home/NotificationView');
          
        }
        GetNotification();
        //var i = setInterval(function () { GetNotification() }, 2000);
});