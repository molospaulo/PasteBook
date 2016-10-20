
//$(document).ready(function () {
   
    $('#userNameCheckerFail').hide();
    $('#userNameCheckerSuccess').hide();
    $('#emailCheckerSuccess').hide();
    $('#emailCheckerFail').hide();
    $('#txtEmailAddress').blur(function () {

        CheckEmail();
    })
    $('#txtUserName').blur(function () {
        CheckUserName();
    })
    $('#SignUpForm').submit(function () {
        ('#SignUpForm')[0].reset();
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
                    $('#emailCheckerFail').show();
                    $('#emailCheckerSuccess').hide();
                } else {
                    $('#emailCheckerFail').hide();
                    $('#emailCheckerSuccess').show();
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
                    $('#userNameCheckerFail').show();
                    $('#userNameCheckerSuccess').hide()
                } else {
                    $('#userNameCheckerFail').hide();
                    $('#userNameCheckerSuccess').show()
                }
            },
            error: function () {
                alert('error');
            }
        })
    }

    //});

