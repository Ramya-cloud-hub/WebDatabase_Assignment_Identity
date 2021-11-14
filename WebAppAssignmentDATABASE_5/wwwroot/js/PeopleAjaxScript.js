let baseUrl = window.location.protocol + window.location.hostname + ":" + window.location.port + "/Ajax";
let getPeoplePath = "Ajax/LoadPeople/"

$("#load-people-btn")
    .click(function () {
        loadPeople();
        resetResponseText();
    });

$("#delete-btn")
    .click(function () {
        resetResponseText();
        let id = getId()
        $.post(`/Ajax/Delete/${id}`).done(() => { changeResponseText(`Person with id '${id}' deleted.`); loadPeople(); })
            .fail(() =>
                changeResponseText(`Person with id '${id}' failed to be deleted.`))
    });

$("#details-btn")
    .click(function () {
        resetResponseText();
        let id = getId()
        $.post(`/Ajax/Details/${id}`, res =>
            $("#people").html(res))
            .fail(() => {
               changeResponseText(`Person with id '${id}' does not exist.`)
            })
    });


function changeResponseText(text) {
    $("#response").html(text)
}

function resetResponseText() {
    changeResponseText("");
}

function getId() {
    return $("#id-input").val();
}

function loadPeople() {
    $.get("/Ajax/LoadPeople", res =>
        $("#people").html(res));
}