$(function () {

    $(document).on("click", ".delete-basket-item", function (event) {
  
        event.preventDefault();
       
        alert($(this).attr('basketId'));


        $.ajax({
            url: "DeleteBasketItem",
            type: 'POST',
            data: { itemId: $(this).attr('basketId') },
            success: function (data) {
                if (data.result == 1) {
                   alert(data.countProduct);

                }
            }, error: function (error) {
                console.log(error);
            }
        });
    })


});