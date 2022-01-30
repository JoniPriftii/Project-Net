$(function () {
    $(".row .fshirje-btn").click(function () {
        if (confirm("Jeni te sigurt qe doni te fshini produktin?")) {
            var element = $(this);
            var del_id = element.attr("id");
            var info = "id=" + del_id;
            $.ajax({
                type: "POST",
                url: "/DietPlans/Fshi",
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