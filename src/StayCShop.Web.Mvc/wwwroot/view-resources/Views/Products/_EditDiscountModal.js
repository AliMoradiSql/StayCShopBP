(function ($) {
    l = abp.localization.getSource('StayCShop');
    var _mService = abp.services.app.productDiscount;

    _$modal = $('#EditModal');
    _$form = _$modal.find('form');
    console.log("test");
    var defaultDiscountId = $('#DefaultDiscountId').val();
    function save() {

        if (!_$form.valid()) {
            return;
        }

        var info = _$form.serializeFormToObject();


        abp.ui.setBusy(_$modal);
        _mService.createOrUpdate(info).done(function () {
            _$modal.modal('hide');
            _$form[0].reset();
            abp.notify.info(l('SavedSuccessfully'));
            abp.event.trigger('DiscountProduct.edited', info);
        }).always(function () {
            abp.ui.clearBusy(_$modal);
        });

    }

    _$form.closest('div.modal-content').find(".save-button").click(function (e) {
        e.preventDefault();
        save();
    });

    _$form.find('input').on('keypress', function (e) {
        if (e.which === 13) {
            e.preventDefault();
            save();
        }
    });

    _$modal.on('shown.bs.modal', function () {
        _$form.find('input[type=text]:first').focus();
    });

    $('#EditDiscountId').select2({
        placeholder: l('SelectYourDiscountName'),
        allowClear: true,
        /*        theme: 'default',*/
        selectionCssClass: 'form-select',
        dropdownParent: _$modal,
        ajax: {
            url: abp.appPath + "api/services/app/Discount/GetAll",
            dataType: 'json',
            delay: 250,
            data: function (params) {

                return {
                    //searchTerm: params.term, // search term
                    //page: params.page,
                    filter: params.term, // search term
                    skipCount: params.page,
                    maxResultCount: 20
                };
            },
            processResults: function (data, params) {
                params.page = params.page || 1;

                return {
                    results: $.map(data.result.items, function (item) {
                        return {
                            text: item.discountName,
                            id: item.id
                        }
                    }),
                    pagination: {
                        more: (params.page * 10) <= data.result.totalCount
                    }
                };
            },
            cache: true
        },
        escapeMarkup: function (markup) {
            return markup;
        },
        minimumInputLength: 1,
        /*        language: abp.localization.currentCulture.name,*/
        width: '100%'
    }).val(defaultDiscountId);
    if (defaultDiscountId != null) {
        var $option = $('<option selected>Loading...</option>').val(defaultDiscountId);
        $('#EditDiscountId').append($option);
        $.ajax({
            type: 'GET',
            url: abp.appPath + "api/services/app/Discount/GetForEdit?Id=" + defaultDiscountId,
            dataType: 'json'
        }).then(function (data) {
            var $option = $('<option selected>' + data.result.discountName + '</option>').val(data.result.id);
            $('#EditDiscountId').append($option);
        });
    }


})(jQuery);
