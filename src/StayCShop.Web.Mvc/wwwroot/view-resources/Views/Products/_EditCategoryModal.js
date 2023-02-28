(function ($) {
    l = abp.localization.getSource('StayCShop');
    var _mService = abp.services.app.productCategory;

    _$modal = $('#EditModal');
    _$form = _$modal.find('form');
    console.log("test");
    var defaultCategoryId = $('#DefaultCategoryId').val();
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
            abp.event.trigger('CategoryProduct.edited', info);
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

    $('#EditCategoryId').select2({
        placeholder: l('SelectYourCategoryName'),
        allowClear: true,
        /*        theme: 'default',*/
        selectionCssClass: 'form-select',
        dropdownParent: _$modal,
        ajax: {
            url: abp.appPath + "api/services/app/Category/GetAll",
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
                            text: item.categoryName,
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
    }).val(defaultCategoryId);
    if (defaultCategoryId != null) {
        var $option = $('<option selected>Loading...</option>').val(defaultCategoryId);
        $('#EditCategoryId').append($option);
        $.ajax({
            type: 'GET',
            url: abp.appPath + "api/services/app/Category/GetForEdit?Id=" + defaultCategoryId,
            dataType: 'json'
        }).then(function (data) {
            var $option = $('<option selected>' + data.result.categoryName + '</option>').val(data.result.id);
            $('#EditCategoryId').append($option);
        });
    }


})(jQuery);
