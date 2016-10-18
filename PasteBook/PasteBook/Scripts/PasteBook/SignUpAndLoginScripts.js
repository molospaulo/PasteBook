
$(document).ready(function () {
   

    $('#txtEmailAddress').blur(function () {

        CheckEmail();
    })
    $('#txtUserName').blur(function () {
        CheckUserName();
    })





    function CheckEmail(){
    
        var data = {
            email: $('#txtEmailAddress').val()
        }

        $.ajax({
            url : CheckEmailUrl,
            data: data,
            type: 'GET',
            success: function (data) {
                if (data.result == true) {
                    $('#emailChecker').addClass('glyphicon glyphicon-align-remove');
                    $('#emailChecker').text("E-mail is already taken");
                } else {
                    $('#emailChecker').addClass('glyphicon glyphicon-align-ok');
                    $('#emailChecker').text("E-mail is available");
                }
            },
            error: function () {
                alert('error');
            }
        })
    }
    function CheckUserName() {
      
        var data = {
            userName: $('#txtUserName').val()
        }

        $.ajax({
            url: CheckUserNameUrl,
            data: data,
            type: 'GET',
            success: function (data) {
                if (data.result == true) {
                    $('#userNameChecker').addClass('glyphicon glyphicon-align-remove');
                    $('#userNameChecker').text("User name is already taken");
                } else {
                    $('#userNameChecker').addClass('glyphicon glyphicon-align-ok');
                    $('#userNameChecker').text("User name is available");
                }
            },
            error: function () {
                alert('error');
            }
        })
    }

    });

