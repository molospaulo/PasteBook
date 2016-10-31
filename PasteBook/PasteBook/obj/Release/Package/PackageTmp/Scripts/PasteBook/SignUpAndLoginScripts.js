$('#txtEmailAddressEdit').on('blur',function () {
    var email= $('#txtEmailAddressEdit').val()
    var oldEmail = $('#hiddenEmail').val()
    if (email == oldEmail) {

    } else {
        CheckEmail()
    }
});


$('#txtUserName').on('blur',function () {
        var result =$("#txtUserName").val()
        if (result.trim() == "") {
        } else {
            CheckUserName();
        }
    })

    $('#conPassword').on('blur', function () {
        var confirmPassword = $('#conPassword').val();
        var password = $('#txtPassword').val();

        if (password != confirmPassword) {
            $('#errorMessConfirmPassword').text('Password did not match');
        } else {
            $('#errorMessConfirmPassword').text('')
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
            url: UrlCheckEmail,
            data: data,
            type: 'GET',
            success: function (data) {
                if (data.result == true) {
                    $("#errorMessEmail").text("Email address is already taken");
                } else {
     
                }
            },
            error: function () {
                
            }
        })
    }
    function CheckUserName() {
      
        var data = {
            userName: $('#txtUserName').val()
        }

        $.ajax({
            url: UrlCheckUsername,
            data: data,
            type: 'GET',
            success: function (data) {
                if (data.result == true) {
                    $("#errorMessUsername").text("Username is already taken");
                } else {
            
                }
            },
            error: function () {
  
            }
        })
    }
    $('#txtUserNameEdit').blur(function () {
        var username = $('#txtUserNameEdit').val()
        var oldUsername = $('#hiddenUsername').val()
        if (username == oldUsername) {

        } else {
            CheckUsername()
        }
    });

    $('#txtEmailAddress').blur(function () {
        var result = $("#txtEmailAddress").val()
        if (result.trim() == "") {
        } else {
            CheckEmail();
        }
    })
