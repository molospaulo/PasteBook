
   
    $('#userNameCheckerFail').hide();
    $('#userNameCheckerSuccess').hide();
    $('#emailCheckerSuccess').hide();
    $('#emailCheckerFail').hide();

    $('#txtEmailAddress').blur(function () {
        var result =$("#txtEmailAddress").val()
        if (result.trim() == "") {
            $('#emailCheckerSuccess').hide();
            $('#emailCheckerFail').hide();
        } else {
            CheckEmail();
        }
    })
    $('#txtUserName').blur(function () {
        var result =$("#txtUserName").val()
        if (result.trim() == "") {
            $('#userNameCheckerFail').hide();
            $('#userNameCheckerSuccess').hide();
        } else {
            CheckUserName();
        }
    })

    $('#conPassword').on('blur', function () {
        var confirmPassword = $('#conPassword').val();
        var password = $('#txtPassword').val();

        if (password != confirmPassword) {
            $('#errorConfirmPassword').text('Password did not match');
        } else {
            $('#errorConfirmPassword').text('')
        }


    })
    $('#SignUpForm').submit(function () {
        ('#SignUpForm')[0].reset();
    })

    

function CheckEmail(){
    
        var data = {
            email: $('#txtEmailAddress').val()
        }

        $.ajax({
            url: '/PasteBook/CheckEmail',
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
            url: '/PasteBook/CheckUsername',
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

