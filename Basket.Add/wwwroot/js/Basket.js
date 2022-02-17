$(function () {

    $(document).on("click", ".basket", function (event) {
  
        event.preventDefault();

   

        var model = { id: $(this).attr('id'), price: 2};
        $.ajax({
            url: "Home/AddBasket",
            type: 'POST',
            dataType: "json",
            contentType: 'application/json',
            data: JSON.stringify(model),
            success: function (data) {
                if (data.result == 1) {
                    $('#lblCartCount').text(data.countProduct);

                }
            }, error: function (error) {
                console.log(error);
            }
        });
    })


});