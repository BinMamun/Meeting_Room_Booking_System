$(function () {
    $('#createForm').validate({
        rules: {
            meetingRoomTitle: {
                required: true,
            },
            capacity: {
                required: true
            },
            location: {
                required: true
            },
            facilities: {
                required: true
            }
        },
        messages: {
            meetingRoomTitle: {
                required: "Meeting Room Title is required",
            },
            capacity: {
                required: "Capacity is required",
            },
            location: {
                required: "Location is required",
            },
            facilities: {
                required: "Location is required",
            }
        },
        errorElement: 'span',
        errorPlacement: function (error, element) {
            error.addClass('invalid-feedback');
            element.closest('.form-group').append(error);
        },
        highlight: function (element, errorClass, validClass) {
            $(element).addClass('is-invalid');
        },
        unhighlight: function (element, errorClass, validClass) {
            $(element).removeClass('is-invalid');
        }
    });

    $('#updateForm').validate({
        rules: {
            meetingRoomTitle: {
                required: true,
            },
            capacity: {
                required: true
            },
            location: {
                required: true
            },
            facilities: {
                required: true
            }
        },
        messages: {
            meetingRoomTitle: {
                required: "Meeting Room Title is required",
            },
            capacity: {
                required: "Capacity is required",
            },
            location: {
                required: "Location is required",
            },
            facilities: {
                required: "Location is required",
            }
        },
        errorElement: 'span',
        errorPlacement: function (error, element) {
            error.addClass('invalid-feedback');
            element.closest('.form-group').append(error);
        },
        highlight: function (element, errorClass, validClass) {
            $(element).addClass('is-invalid');
        },
        unhighlight: function (element, errorClass, validClass) {
            $(element).removeClass('is-invalid');
        }
    });

    $("#generate-barcode").on('click', function () {
        var randomNumber = Date.now();
        $("#barcode-field").val(randomNumber);
    });

    const preview = document.querySelector('.preview');
    const imageInput = document.querySelector('#image');
    const imagePreview = document.querySelector('#imagePreview');
    const previousImagePath = document.querySelector('#previousImagePath');

    $('#image').on('change', function (e) {
        if (e.target.files && e.target.files[0]) {
            const reader = new FileReader();

            reader.onload = function (e) {
                imagePreview.src = e.target.result;
                preview.classList.remove('hidden');
            };

            reader.readAsDataURL(e.target.files[0]);
        }
        else {
            imagePreview.src = "#";
            preview.classList.add('hidden');
        }
    });
    $('#close-preview').on('click', function () {
        imageInput.value = "";
        imagePreview.src = "#";
        preview.classList.add('hidden');
        previousImagePath.value = "";
    });
});