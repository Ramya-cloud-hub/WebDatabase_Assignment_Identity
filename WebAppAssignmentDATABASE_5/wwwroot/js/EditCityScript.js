
$(".edit-city-row").hide();

$(".edit-submit-btn").click(function () {
    let id = $(this).attr("name");
    let editedCity = getEditedCity(id);

    $.post(`/Cities/UpdateCity/`, editedCity).done(res => {
        $("#edit-city-" + id).hide();
        $("#city-row-" + id).show();
        $("#city-row-" + id).html(res);
    })
        .fail(() => {
            $("#error-msg").html("Something went wrong!");
        })
})

function getEditedCity(id) {

    return {
        Name: $(`#Name-${id}`).val(),
        CountryId: $(`#CountryId-${id}`).val(),
        Id: id
    }
}

$(".city-row").on("click", ".edit-btn", function () {
    let id = $(this).attr("id");

    if ($("#edit-city-" + id).is(":visible")) {
        $("#edit-city-" + id).hide();
        $("#city-row-" + id).show();
    } else {
        $("#edit-city-" + id).show();
        $("#city-row-" + id).hide();
    }

});

