$(document).ready(function () {

    LoadCarWorkshopServices();

    $(document).on("submit", "#createCarWorkshopServiceModal form", function (event) {
        event.preventDefault();

        const $form = $(this);

        $.ajax({
            type: "POST",
            url: $form.attr("action"),
            data: $form.serialize(),

            success: function () {
                toastr["success"]("Service created successfully!");
                LoadCarWorkshopServices();

                const modalElement = document.getElementById('createCarWorkshopServiceModal');
                const modal = bootstrap.Modal.getInstance(modalElement);

                if (modal) {
                    modal.hide();
                }

                $form[0].reset();
            },

            error: function () {
                toastr["error"]("Error creating service.");
            }
        });
    });

});