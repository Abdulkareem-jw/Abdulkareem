document.addEventListener("DOMContentLoaded", function (event) {

   
    const showNavbar = (toggleId, navId, bodyId, headerId) => {
        const toggle = document.getElementById(toggleId),
            nav = document.getElementById(navId),
            bodypd = document.getElementById(bodyId),
            headerpd = document.getElementById(headerId)

        // Validate that all variables exist
        if (toggle && nav && bodypd && headerpd) {
            toggle.addEventListener('click', () => {
                // show navbar
                nav.classList.toggle('show')
                // change icon
                toggle.classList.toggle('bx-x')
                // add padding to body
                bodypd.classList.toggle('body-pd')
                // add padding to header
                headerpd.classList.toggle('body-pd')
            })
        }
    }

    showNavbar('header-toggle', 'nav-bar', 'body-pd', 'header')

    /*===== LINK ACTIVE =====*/
    const linkColor = document.querySelectorAll('.nav_link')

    function colorLink() {
        if (linkColor) {
            linkColor.forEach(l => l.classList.remove('active'))
            this.classList.add('active')
        }
    }
    linkColor.forEach(l => l.addEventListener('click', colorLink))

    // Your code to run since DOM is loaded and ready
});


$(document).ready(function () {
    var name = $("#body-pd").find("#Name").val();
    var userName = sessionStorage.getItem("UserName");
    if (userName != "") {
        userName = "Welecom " + userName.split("@")[0];
        $("#UserNameProfile").text(userName);
    }
    
    
    
    var path = sessionStorage.getItem("path");
    
    $("#SetPath").find("img").attr("src", path);
    
    $("#here").text(name);
    
    
   
    

    $("#nav-bar").mousemove(function () {
        $(this).addClass("l-navbar show");
        $("#header").addClass("header body-pd");
        $("#body-pd").addClass("body-pd");
    });
    $("#nav-bar").mouseout(function () {
        $(this).removeClass("show");
        $("#header").removeClass("body-pd");
        $("#body-pd").removeClass("body-pd");
    });

    //152px
    $("#SetPath").find("img").eq(0).mousemove(function () {
        $(this).parent().attr("style","width: 152px;height: 152px;float: right;")
    });
    $("#SetPath").find("img").eq(0).mouseout(function () {
        $(this).parent().removeAttr("style");
        $(this).parent().attr("style", "float: right;")
    });

    $("#edit").click(function () {
        
        var id = $(this).parent().parent().find("input").val();
        
        $.ajax({
            type:'get',
            url:'/BookShop/Category/edit?id=' + id,
            success: function (data) {
                debugger;
                $("#forspan").val(data.code)
                $("#forspan1").val(data.name)
                $("#forspan2").val(data.goal)
                
                
            },
            error: function () {
                alert("Error")
            }
                
        })
        
        $("#staticBackdrop").modal('show')
            
    });

    $("#btn").click(function () {
        
        $("#key").find("input").each(function () {

            if ($(this).val() != "Update" && $(this).val() != "Save")
            $(this).val("");
        })
    });
});
  



