(function () {
    app.modals.CreateOrEditBrandModal = function () {

        var _modalManager;
        var _mService = abp.services.app.brand;
        var _$InformationForm = null;

        this.init = function (modalManager) {
            _modalManager = modalManager;

            _$InformationForm = _modalManager.getModal().find('form[name=InformationsForm]');
            _$InformationForm.validate({ ignore: "", });


        };

        this.save = function () {
            if (!_$InformationForm.valid())
                return;
            _modalManager.setBusy(true);
            var info = _$InformationForm.serializeJSON({ useIntKeysAsArrayIndex: true });
            _mService.createOrUpdate(info).done(function () {
                abp.notify.info(app.localize('SavedSuccessfully'));
                _modalManager.close();
                abp.event.trigger('app.createOrEditBrandModalSaved');
            }).always(function () {
                _modalManager.setBusy(false);
            });
        };
    };
})();
