$(function () {
    $("#fh5co-trainer.fshirje-btn").click(function () {
        if (confirm("Jeni te sigurt qe doni te fshini produktin?")) {
            var element = $(this);
            var del_id = element.attr("id");
            var info = "id=" + del_id;
            $.ajax({
                type: "POST",
                url: "/Products/Fshi",
                data: info,
                success: function (data) {
                    if (data) {
                        $('#kurse' + del_id).fadeOut();
                    }
                    else {
                        alert('Rekordi nuk mund te fshihet.');
                    }
                }
            })
        } return false;
    })
})