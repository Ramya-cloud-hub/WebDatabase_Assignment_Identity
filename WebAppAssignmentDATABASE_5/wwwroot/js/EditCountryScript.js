
$(".edit-country-row").hide();

$(".edit-submit-btn").click(function () {
    let id = $(this).attr("name");
    let editedCountry = getEditedCountry(id);

    $.post(`/Countries/UpdateCountry/`, editedCountry).done(res => {
        $("#edit-country-" + id).hide();
        $("#country-row-" + id).show();
        $("#country-row-" + id).html(res);
    })
        .fail(() => {
            $("#error-msg").html("Something went wrong!");
        })
})

function getEditedCountry(id) {

    return {
        Name: $(`#Name-${id}`).val(),
        Id: id
    }
}

$(".country-row").on("click", ".edit-btn", function () {
    let id = $(this).attr("id");

    if ($("#edit-country-" + id).is(":visible")) {
        $("#edit-country-" + id).hide();
        $("#country-row-" + id).show();
    } else {
        $("#edit-country-" + id).show();
        $("#country-row-" + id).hide();
    }

});

