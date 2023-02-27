(function ($) {
    l = abp.localization.getSource('StayCShop');
    var _mService = abp.services.app.discount;

    _$modal = $('#EditModal');
    _$form = _$modal.find('form');

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
            abp.event.trigger('Discount.edited', info);
        }).always(function () {
            abp.ui.clearBusy(_$modal);
        });

    }

    $('#datetimepicker1').datetimepicker({ theme: 'dark' });

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
