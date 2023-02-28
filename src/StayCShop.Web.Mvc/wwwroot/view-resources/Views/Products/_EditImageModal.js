(function ($) {
    l = abp.localization.getSource('StayCShop');
    var _mService = abp.services.app.image;

    _$modal = $('#EditModal');
    _$form = _$modal.find('form');
console.log("test");
    $('#ImageInputEdit').change(function (event) {
        $('#imageViewrEdit').attr("src", "");
        var files = event.target.files;
        $('#imageViewrEdit').attr("src", window.URL.createObjectURL(files[0]));

    });


    function save() {

        if (!_$form.valid()) {
            return;
        }

        var files = $('#ImageInputEdit')[0].files;
        var fd = new FormData();
        if (files.length > 0)
            fd.append('file', files[0]);

        var info = _$form.serializeFormToObject();

        if (files[0] != null) {
            abp.ui.setBusy(_$modal);
            abp.ajax({
                url: '/api/services/app/image/ConvertIamgeToByte',
                type: 'post',
                processData: false,
                contentType: false,
                data: fd
            }).done(function (data) {
                info.Image = data;
                _mService.createOrUpdate(info).done(function () {
                    _$modal.modal('hide');
                    _$form[0].reset();
                    abp.notify.info(l('SavedSuccessfully'));
                    abp.event.trigger('Image.edited', info);
                });
            }).always(function () {
                abp.ui.clearBusy(_$modal);
            });
        }
        else {
            abp.ui.setBusy(_$modal);
            _mService.createOrUpdate(info).done(function () {
                _$modal.modal('hide');
                _$form[0].reset();
                abp.notify.info(l('SavedSuccessfully'));
                abp.event.trigger('Image.edited', info);
            }).always(function () {
                abp.ui.clearBusy(_$modal);
            });
        }
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


})(jQuery);
