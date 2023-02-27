(function ($) {
    l = abp.localization.getSource('StayCShop');
    var _mService = abp.services.app.product;

    _$modal = $('#EditModal');
    _$form = _$modal.find('form');
    var defaultBrandId = $('#DefaultBrandId').val();

    $('#textFileEdit').change(function (event) {
        //$('#imageViewrEdit').attr("src", "");
        var files = event.target.files;
        $('#imageViewrEdit').attr("src", window.URL.createObjectURL(files[0]));

    });


    function save() {

        if (!_$form.valid()) {
            return;
        }

        var files = $('#textFileEdit')[0].files;
        var fd = new FormData();
        if (files.length > 0)
            fd.append('file', files[0]);

        var info = _$form.serializeFormToObject();


        abp.ui.setBusy(_$modal);
        abp.ajax({
            url: '/api/services/app/product/ConvertIamgeToByte',
            type: 'post',
            processData: false,
            contentType: false,
            data: fd
        }).done(function (data) {
            info.CoverImage = data;
            _mService.createOrUpdate(info).done(function () {
                _$modal.modal('hide');
                _$form[0].reset();
                abp.notify.info(l('SavedSuccessfully'));
                abp.event.trigger('Brand.edited', info);
            });
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

    $('#EditBrandId').select2({
        selectionCssClass: 'form-select',
        allowClear: true,
        dropdownParent: _$modal,
        ajax: {
            url: abp.appPath + "api/services/app/brand/GetAll",
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
                            text: item.brandName,
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
        width: '100%'
    }).val(defaultBrandId);
    if (defaultBrandId != null) {
        var $option = $('<option selected>Loading...</option>').val(defaultBrandId);
        $('#EditBrandId').append($option);
        $.ajax({
            type: 'GET',
            url: abp.appPath + "api/services/app/brand/GetForEdit?Id=" + defaultBrandId,
            dataType: 'json'
        }).then(function (data) {
            var $option = $('<option selected>' + data.result.brandName + '</option>').val(data.result.id);
            $('#EditBrandId').append($option);
        });
    }

})(jQuery);
