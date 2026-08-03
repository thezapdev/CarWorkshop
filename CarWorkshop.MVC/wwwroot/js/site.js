const RenderCarWorkshopServices = (services, container) => {
    container.empty();

    for (const service of services) {
        container.append(
            `<div class="card mb-3">
                    <div class="card-body">
                        <p class="card-text">${service.description}</p>
                    </div>
                </div>`
        );
    }
};
const LoadCarWorkshopServices = () => {
    const container = $("#service");
    const carWorkshopEncodedName = container.data("encoded-name");

    $.ajax({
        type: "GET",
        url: `/CarWorkshop/${carWorkshopEncodedName}/CarWorkshopService`,
        success: function (data) {
            if (!data.length) {
                container.html("There are no services available for this car workshop.");
            } else {
                RenderCarWorkshopServices(data, container);
            }
        },
        error: function () {
            toastr["error"]("Error loading services.");
        }
    });
};