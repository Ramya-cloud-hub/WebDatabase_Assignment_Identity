
$(".edit-person").hide();

$(".edit-submit-btn").click(function () {
    let id = $(this).attr("name");
    let editedPerson = getEditedPerson(id);

    $.post(`/People/UpdatePerson/`, editedPerson).done(res => {
        $("#edit-person-" + id).hide();
        $("#person-row-" + id).show();
        $("#person-row-" + id).html(res);
    })
        .fail(() => {
            console.log("Something went wrong");
        })
})

function getEditedPerson(id) {

    return {
        FirstName: $(`#firstName-${id}`).val(),
        LastName: $(`#lastName-${id}`).val(),
        PhoneNr: $(`#phoneNr-${id}`).val(),
        CityId: $(`#cityId-${id}`).val(),
        LanguageIds: $("#languageIds-" + id).val(),
        Id: id
    }
}

$(".person-row").on("click", ".edit-btn", function () {
    let id = $(this).attr("id");
    console.log("Bleh")
    if ($("#edit-person-" + id).is(":visible")) {
        $("#edit-person-" + id).hide();
        $("#person-row-" + id).show();
    } else {
        $("#edit-person-" + id).show();
        $("#person-row-" + id).hide();
    }

});

