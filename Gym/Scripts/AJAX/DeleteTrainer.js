$(function () {
    $(".row .fshirje-btn").click(function () {
        if (confirm("Jeni te sigurt ")) {
            var element = $(this);
            var del_id = element.attr("id");
            var info = "id=" + del_id;
            console.log(info);
            $.ajax({
                type: "POST",
                url: "/Trainers/Fshi",
                data: info,
                success: function (data) {
                    if (data) {
                        $("#" + del_id + "item").fadeOut();
                    }
                    else {
                        alert('Rekordi nuk mund te fshihet.');
                    }
                }
            })
        } return false;
    })
})