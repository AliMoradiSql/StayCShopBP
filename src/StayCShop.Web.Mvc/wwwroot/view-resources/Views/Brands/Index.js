(function ($) {

    console.log("Test");
    var _mService = abp.services.app.brand;
    var _$dTable = $('#DataTable');


    var dataTable = _$dTable.DataTable({
        paging: true,
        serverSide: true,
        processing: true,
        listAction: {
            ajaxFunction: _mService.getAll,
            inputFilter: function () {
                return {
                    filter: $('#TableFilter').val(),
                };
            }
        },
        columnDefs: [
            {
                className: 'control responsive',
                orderable: false,
                render: function () {
                    return '';
                },
                targets: 0
            },
            {
                targets: 1,
                data: null,
                orderable: false,
                autoWidth: false,
                defaultContent: '',
                rowAction: {
                    text: '<i class="fa fa-cog"></i> ' + app.localize('Actions') + ' <span class="caret"></span>',
                    items: [{
                        text: app.localize('Edit'),

                        action: function (data) {
                            _createOrEditModal.open({ id: data.record.id });
                        }
                    },
                    {
                        text: app.localize('Delete'),
                        action: function (data) {
                            DeleteObj(data.record);
                        }
                    },
                    ]
                }
            },
            {
                targets: 2,
                data: "brandName",
            },

        ],
        "drawCallback": function (settings) { }
    });

    //var _createOrEditModal = new app.ModalManager({
    //    viewUrl: abp.appPath + 'Brands/CreateOrEditBrandModal',
    //    scriptUrl: abp.appPath + 'view-resources/Views/Brands/_CreateOrEditBrandModal.js',
    //    modalClass: 'CreateOrEditBrandModal',
    //});


    //function getData() {
    //    dataTable.ajax.reload();
    //}

    //$('#TableFilter').on('keydown', function (e) {
    //    if (e.keyCode !== 13) {
    //        return;
    //    }

    //    e.preventDefault();
    //    getData();
    //});

    //$('#CreateNewBtn').click(function (e) {
    //    e.preventDefault();
    //    _createOrEditModal.open({});
    //});

    //$('#GetButton').click(function (e) {
    //    e.preventDefault();
    //    getData();
    //});

    //abp.event.on('app.createOrEditBrandModalSaved', function () {
    //    dataTable.ajax.reload();
    //});

    //function DeleteObj(obj) {
    //    abp.message.confirm(
    //        app.localize('DeleteWarningMessage', obj.name),
    //        app.localize('AreYouSure'),
    //        function (isConfirmed) {
    //            if (isConfirmed) {
    //                _mService.delete({
    //                    id: obj.id
    //                }).done(function () {
    //                    getData();
    //                    abp.notify.success(app.localize('SuccessfullyDeleted'));
    //                });
    //            }
    //        }
    //    );
    //}

});


